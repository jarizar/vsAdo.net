using System;
using App.Data.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccessTest
{
    [TestClass]
    public class ArtistTest
    {
        [TestMethod]
        public void GetAll()
        {
            var da = new ArtistDA();

            var lista=da.GetAll();

            Assert.IsTrue(lista.Count > 0);

        }
    }
}
