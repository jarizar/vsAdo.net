﻿using App.Entities;
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

        [TestMethod]
        public void InsertSP()
        {
            var da = new ArtistDA();
            var artist = new Artista();
            artist.Name = "Jose Luis Ariza";

            var id = da.Insert(artist);
            
           Assert.IsTrue(id > 0,"El nombre del artista ya existe");
        }

        [TestMethod]
        public void UpdateSP()
        {
            var da = new ArtistDA();
            var artist = new Artista();
            artist.Name = "Jose Antonio Ariza";
            artist.ArtistID = 282;

            var registrosAfectados = da.Update(artist);


            Assert.IsTrue(registrosAfectados > 0, "El nombre del artista ya existe");
        }

        [TestMethod]
        public void DeleteSP()
        {
            var da = new ArtistDA();
            var artist = new Artista();          
            artist.ArtistID = 282;

            var registrosAfectados = da.delete(artist);

            Assert.IsTrue(registrosAfectados > 0, "El artista no fue eliminado");
        }



    }
}
