using System;
using System.Linq;
using App.Data.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccessTest
{
    [TestClass]
    public class TrackDATest
    {
        [TestMethod]
        public void ConsultarTracks()
        {
            var da = new TackDA();
            var listado = da.ConsultarTracks("%VOLTA%");

            Assert.IsTrue(listado.Count() > 0);
        }

        [TestMethod]
        public void ConsultarTracksQ()
        {
            var da = new TackDA();
            var listado = da.ConsultarTracksQ("%",0,0);

            Assert.IsTrue(listado.Count() > 0);
        }

    }
}
