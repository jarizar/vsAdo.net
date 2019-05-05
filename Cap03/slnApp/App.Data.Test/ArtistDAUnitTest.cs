using System;
using App.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Test
{
    [TestClass]
    public class ArtistDAUnitTest
    {
        [TestMethod]
        public void Count()
        {
            var da = new ArtistDA();

            Assert.IsTrue(da.GetCount()>0);

        }

        [TestMethod]
        public void GetAll()
        {
            var da = new ArtistDA();
            var listado = da.GetAll("Aerosmith");

            Assert.IsTrue(listado.Count > 0);

        }

        [TestMethod]
        public void Get()
        {
            var da = new ArtistDA();
            var entity = da.Get(8);

            Assert.IsTrue(entity.ArtistId>0);

        }

        [TestMethod]
        public void GetAllSP()
        {
            var da = new ArtistDA();
            var listado = da.GetAllSP("Aerosmith");

            Assert.IsTrue(listado.Count > 0);

        }


        [TestMethod]
        public void InsertSP()
        {
            var da = new ArtistDA();

            var artist = new Artist();
            artist.Name = "Aero-2";
            var id = da.Insert(artist);

            Assert.IsTrue(id > 0,"El nombre del artista ya existe");

        }

        [TestMethod]
        public void UpdateSP()
        {
            var da = new ArtistDA();

            var artist = new Artist();
            artist.Name = "Aero 69";
            artist.ArtistId = 278;
            var registrosAfectados = da.Update(artist);

            Assert.IsTrue(registrosAfectados > 0, "El nombre del artista ya existe");

        }
    }


}
