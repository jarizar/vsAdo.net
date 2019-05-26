using System;
using App.Data.DataAccess;
using App.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccessTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void GetAll()
        {
            var da = new CustomerDA();

            var lista = da.GetAll("");

            Assert.IsTrue(lista.Count > 0);
        }

        [TestMethod]
        public void Get()
        {
            var da = new CustomerDA();

            var entity = da.Get(72);

            Assert.IsTrue(entity.CustomerId > 0);
        }

        [TestMethod]
        public void Insert()
        {
            var da = new CustomerDA();
            var entity = new Customer();

            
            entity.FirstName = "ANTONIO";
            entity.LastName = "ARIZA RAMIREZ";
            entity.Company = "JAAR";
            entity.Address = "NOSE";
            entity.City = "LIMA";
            entity.State = "LIMA";
            entity.Country = "PERU";
            entity.PostalCode = "01";
            entity.Phone = "999999";
            entity.Fax = "NOSE";
            entity.Email = "JAAR@HOTMAIL.COM";
            entity.SupportRepId = 1002;

            var id = da.Insert(entity);

            Assert.IsTrue(id > 0);
        }


        [TestMethod]
        public void Update()
        {
            var da = new CustomerDA();
            var entity = new Customer();
            entity.FirstName = "jose Test";
            entity.LastName = "ARIZA RAMIREZ";
            entity.Company = "JAAR";
            entity.Address = "NOSE";
            entity.City = "LIMA";
            entity.State = "LIMA";
            entity.Country = "PERU";
            entity.PostalCode = "01";
            entity.Phone = "999999";
            entity.Fax = "NOSE";
            entity.Email = "JAAR@HOTMAIL.COM";
            entity.CustomerId = 1004;

            var result = da.Update(entity);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Delete()
        {
            var da = new CustomerDA();
            var entity = new Customer();

            //Agregando un registro      
            entity.FirstName = "ANTONIO";
            entity.LastName = "ARIZA RAMIREZ";
            entity.Company = "JAAR";
            entity.Address = "NOSE";
            entity.City = "LIMA";
            entity.State = "LIMA";
            entity.Country = "PERU";
            entity.PostalCode = "01";
            entity.Phone = "999999";
            entity.Fax = "NOSE";
            entity.Email = "JAAR@HOTMAIL.COM";
            entity.SupportRepId = 1002;
            var id = da.Insert(entity);

            //Eliminando el registro
            var result = da.Delete(id);

            Assert.IsTrue(result);
        }

    }
}
