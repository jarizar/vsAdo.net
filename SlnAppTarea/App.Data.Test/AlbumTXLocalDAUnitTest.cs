using System;
using App.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Test
{
    [TestClass]
    public class AlbumTXLocalDAUnitTest: BaseConnection
    {
        [TestMethod]
        public void GetAllSP()
        {
            var da = new AlbumTXLocalDA();

            var listado = da.GetAllSP("%");

            Assert.IsTrue(listado.Count > 0);
        }

        [TestMethod]
        public void InsertSP()
        {
            var da = new AlbumTXLocalDA();
            var album = new Album();

            album.Title = "Paradise";
            album.ArtistId = 20;

            var id = da.Insert(album);

            Assert.IsTrue(id > 0, "El nombre del album ya existe");
        }


        [TestMethod]
        public void UpdateSP()
        {
            var da = new AlbumTXLocalDA();
            var album = new Album();

            album.Title = "Photograph";
            album.ArtistId = 25;
            album.AlbumId =348;

            var registrosAfectados = da.Update(album);


            Assert.IsTrue(registrosAfectados > 0, "El nombre del álbum ya existe");
        }

        [TestMethod]
        public void DeleteSP()
        {
            var da = new AlbumTXLocalDA();
            var album = new Album();

            album.AlbumId = 348;

            var registrosAfectados = da.delete(album);

            Assert.IsTrue(registrosAfectados > 0, "El álbum no fue eliminado");
        }

    }
}
