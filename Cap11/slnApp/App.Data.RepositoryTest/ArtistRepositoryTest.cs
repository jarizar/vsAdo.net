using System;
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
            int totalAlbumRows = 0;

            using (var repository = new AppUnitOfWork())
            {
                totalRows = repository.ArtistRepository.GetAll().Count;
                totalAlbumRows = repository.AlbumRepository.GetAll().Count;
            }

            Assert.IsTrue(totalRows > 0 && totalAlbumRows>0);

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

                result = uw.Complete()>0;

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
                    Title="Album nuevo",
                    Artist= newArtist
                };

                uw.AlbumRepository.Add(newAlbum);

                result = uw.Complete() > 0;

            }

            Assert.IsTrue(result);
        }
    }
}
