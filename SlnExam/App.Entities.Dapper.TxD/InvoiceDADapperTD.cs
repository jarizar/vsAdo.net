using App.Data;
using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace App.Entities.Dapper.TxD
{

    public class InvoiceDADapperTD : BaseConnection
    {

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
