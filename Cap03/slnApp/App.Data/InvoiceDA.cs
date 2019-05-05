using App.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Transactions;

namespace App.Data
{
    public class InvoiceDA : BaseConnection
    {
        public int InsertTXLocal(Invoice invoice)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(this.ConnectionString))
            {

                //Abriendo la conexion a la base de datos
                cn.Open();
                //Iniciando la transacciones
                var tx = cn.BeginTransaction();
                try
                {
                    var invoiceId = cn.ExecuteScalar<int>("usp_Insertinvoice",
                        new
                        {
                            CustomerId = invoice.CustomerId,
                            InvoiceDate = invoice.InvoiceDate,
                            BillingAddress = invoice.BillingAddress,
                            BillingCity = invoice.BillingCity,
                            BillingState = invoice.BillingState,
                            BillingCountry = invoice.BillingCountry,
                            BillingPostalCode = invoice.BillingPostalCode,
                            Total = invoice.Total
                        }, commandType: CommandType.StoredProcedure,
                        transaction: tx
                        );


                    foreach (var item in invoice.InvoiceLine)
                    {
                        cn.Execute("usp_InsertInvoiceLine",
                            new
                            {
                                InvoiceId = invoiceId,
                                TrackId = item.TrackId,
                                UnitPrice = item.UnitPrice,
                                Quantity = item.Quantity

                            }, commandType: CommandType.StoredProcedure,
                            transaction: tx
                            );
                    }

                    //throw new Exception("ERROR");

                    //Confirmando la transacciòn
                    tx.Commit();

                    result = invoiceId;
                }
                catch (Exception ex)
                {
                    result = 0;
                    //Deshacer la transacciòn
                    tx.Rollback();
                }


            }


            return result;

        }



        public int InsertTXDList(Invoice invoice)
        {
            var result = 0;

            using (var tx = new TransactionScope())
            {
                try
                {
                    using (IDbConnection cn = new SqlConnection(this.ConnectionString))
                    {

                        var invoiceId = cn.ExecuteScalar<int>("usp_InsertInvoice",
                            new
                            {
                                CustomerId = invoice.CustomerId,
                                InvoiceDate = invoice.InvoiceDate,
                                BillingAddress = invoice.BillingAddress,
                                BillingCity = invoice.BillingCity,
                                BillingState = invoice.BillingState,
                                BillingCountry = invoice.BillingCountry,
                                BillingPostalCode = invoice.BillingPostalCode,
                                Total = invoice.Total
                            }, commandType: CommandType.StoredProcedure

                            );


                        foreach (var item in invoice.InvoiceLine)
                        {
                            cn.Execute("usp_InsertInvoiceLine",
                                new
                                {
                                    InvoiceId = invoiceId,
                                    TrackId = item.TrackId,
                                    UnitPrice = item.UnitPrice,
                                    Quantity = item.Quantity

                                }, commandType: CommandType.StoredProcedure

                                );
                        }

                        //throw new Exception("ERROR");

                        //Confirmando la transacciòn
                        result = invoiceId;
                    }

                    tx.Complete();
                }
                catch (Exception)
                {
                    result = 0;
                    throw;
                }
            }

            return result;

        }

    }
}
