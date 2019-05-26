using App.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlnAppTxDistribuidas;

namespace App.Data.TestTXD
{
    [TestClass]
    public class GenreTXDistribuidaDAUnitTest
    {
        [TestMethod]
        public void InsertSP()
        {
            var da = new GenreTXDistribuidaDA();
            var genero = new Genre2();
            genero.Name = "Musica Modernas";

            var id = da.Insert(genero);

            Assert.IsTrue(id > 0, "El nombre del artista ya existe");
        }
    }
}
