using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Test
{
    [TestClass]

    public class ArtistDAUnitTest: BaseConnection
    {
        [TestMethod]
        public void Count()
        {
            var da = new ArtistDA();

            Assert.IsTrue(da.GetCount() > 0);

        }

               
        [TestMethod]
        public void GetAll()
        {
            var da = new ArtistDA();

            var listado = da.GetAll();
                
            Assert.IsTrue(listado.Count>0);            
        }

        [TestMethod]
        public void Get()
        {
            var da = new ArtistDA();

            var entity = da.Get(1);

            Assert.IsTrue(entity.ArtistID > 0);

        }

        [TestMethod]
        public void GetAllfilter()
        {
            var da = new ArtistDA();

            var listado = da.GetAllfilter("Aerosmith");

            Assert.IsTrue(listado.Count > 0);
        }

        [TestMethod]
        public void GetAllSP()
        {
            var da = new ArtistDA();

            var listado = da.GetAllSP("Aerosmith");

            Assert.IsTrue(listado.Count > 0);
        }

    }
}
