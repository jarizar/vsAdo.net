using System;
using App.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.Test
{
    [TestClass]
    public class GenreTXLocalDAUnitTest : BaseConnection
    {
        [TestMethod]
        public void GetAllSP()
        {
            var da = new GenreTXLocalDA();

            var listado = da.GetAllSP("%");

            Assert.IsTrue(listado.Count > 0);
        }

        [TestMethod]
        public void InsertSP()
        {
            var da = new GenreTXLocalDA();
            var genero = new Genre();

            genero.Name = "Hard Rock";
           

            var id = da.Insert(genero);

            Assert.IsTrue(id > 0, "El nombre del album ya existe");
        }


        [TestMethod]
        public void UpdateSP()
        {
            var da = new GenreTXLocalDA();
            var genero = new Genre();

            genero.Name = "Musica Moderna";
            genero.GenreId =26;

            var registrosAfectados = da.Update(genero);


            Assert.IsTrue(registrosAfectados > 0, "El nombre del álbum ya existe");
        }

        [TestMethod]
        public void DeleteSP()
        {
            var da = new GenreTXLocalDA();
            var genero = new Genre();

            genero.GenreId = 26;

            var registrosAfectados = da.delete(genero);

            Assert.IsTrue(registrosAfectados > 0, "El álbum no fue eliminado");
        }

    }
}
