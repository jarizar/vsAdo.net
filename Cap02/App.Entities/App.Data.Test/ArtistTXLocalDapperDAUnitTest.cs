using App.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Test
{
    [TestClass]

    public class ArtistTXLocalDapperDApperDAUnitTest : BaseConnection
    {
        [TestMethod]
        public void Count()
        {
            var da = new ArtistTXLocalDapperDA();

            Assert.IsTrue(da.GetCount() > 0);

        }

               
        [TestMethod]
        public void GetAll()
        {
            var da = new ArtistTXLocalDapperDA();

            var listado = da.GetAll();
                
            Assert.IsTrue(listado.Count>0);            
        }

        [TestMethod]
        public void Get()
        {
            var da = new ArtistTXLocalDapperDA();

            var entity = da.Get(275);

            Assert.IsTrue(entity.ArtistID > 0);

        }

        [TestMethod]
        public void GetAllfilter()
        {
            var da = new ArtistTXLocalDapperDA();

            var listado = da.GetAllfilter("Aerosmith");

            Assert.IsTrue(listado.Count > 0);
        }

        [TestMethod]
        public void GetAllSP()
        {
            var da = new ArtistTXLocalDapperDA();

            var listado = da.GetAllSP("%");

            Assert.IsTrue(listado.Count > 0);
        }

        [TestMethod]
        public void InsertSP()
        {
            var da = new ArtistTXLocalDapperDA();
            var artist = new Artista();
            artist.Name = "Jose Luis Ariza";

            var id = da.Insert(artist);
            
           Assert.IsTrue(id > 0,"El nombre del artista ya existe");
        }

        [TestMethod]
        public void UpdateSP()
        {
            var da = new ArtistTXLocalDapperDA();
            var artist = new Artista();
            artist.Name = "Jose Antonio Ariza";
            artist.ArtistID = 282;

            var registrosAfectados = da.Update(artist);


            Assert.IsTrue(registrosAfectados > 0, "El nombre del artista ya existe");
        }

        [TestMethod]
        public void DeleteSP()
        {
            var da = new ArtistTXLocalDapperDA();
            var artist = new Artista();          
            artist.ArtistID = 284;

            var registrosAfectados = da.delete(artist);

            Assert.IsTrue(registrosAfectados > 0, "El artista no fue eliminado");
        }



    }
}
