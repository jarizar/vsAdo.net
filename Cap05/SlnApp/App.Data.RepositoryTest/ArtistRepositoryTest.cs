using System;
using System.Linq;
using App.Data.DataAccess;
using App.Data.Repository;
using App.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.RepositoryTest
{
    [TestClass]
    public class ArtistRepositoryTest
    {
        [TestMethod]
        public void GetAll()
        {
            int totalRows = 0;
            int totalAlbum = 0;
            var dbModel = new DBModel();


            using (var Repository = new AppUnitOfWork())
            {

                totalRows = Repository.ArtistRepository.GetAll().Count();
                totalAlbum = Repository.AlbumRepository.GetAll().Count();
            }

            Assert.IsTrue(totalRows > 0 && totalAlbum > 0);
        }

        [TestMethod]
        public void InsertArtist()
        {

            var result = false;

            using (var uw = new AppUnitOfWork())
            {
                var newArtist = new Artist()
                {
                    Name = "Artist nuevo"
                };

                uw.ArtistRepository.Add(newArtist);
                result = uw.complete() > 0;
            }
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void InsertAlbum()
        {
            var result = false;

            using (var uw = new AppUnitOfWork())
            {
                var newArtist = new Artist()
                {
                    Name = "Artist nuevo"                   
                };

                var newAlbum = new Album()
                {
                    Title = "Album nuevo",
                    Artist = newArtist                    
                };

                uw.AlbumRepository.Add(newAlbum);
                result = uw.complete() > 0;
            }
            Assert.IsTrue(result);
        }


    }
}
