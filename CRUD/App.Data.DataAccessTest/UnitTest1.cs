using System;
using App.Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.DataAccessTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Getall()
        {
            int TotalRows = 0;

            using (var repository = new AppUnitOfWork()) {
                TotalRows = repository.Tipo_ComprobanteRepository.All().Count;

            }

            Assert.IsTrue(TotalRows > 0);

        }
    }
}
