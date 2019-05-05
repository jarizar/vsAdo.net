using System;
using System.Collections.Generic;
using App.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Test
{
    [TestClass]
    public class InvoiceTXLocalUnitTest
    {
        [TestMethod]
        public void InsertTXlocal()
        {
            var invoiceDA = new InvoiceDA();
            var invoice = new Invoice();
            invoice.CustomerId = 72;
            invoice.BillingAddress = "AV. Los Alamos 233";
            invoice.BillingCity = "Lima";
            invoice.BillingPostalCode = "01";
            invoice.BillingState = "Limadd";
            invoice.BillingCountry = "Lima";
            invoice.InvoiceDate = DateTime.Now;
            invoice.Total = 300;

            //Agregando los detalles
            invoice.InvoiceLine = new List<InvoiceLine>();
            invoice.InvoiceLine.Add(
                new InvoiceLine()
                {
                    TrackId = 1,
                    Quantity = 2,
                    UnitPrice = 50
                }
        );
            invoice.InvoiceLine.Add(
               new InvoiceLine()
               {
                   TrackId = 2,
                   Quantity = 4,
                   UnitPrice = 150
               }
       );

            var id = invoiceDA.InsertTXLocal(invoice);


            Assert.IsTrue(id > 0);
        }
    }
}
