using System;
using App.Data.DataAccess;
using App.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataAccessTest
{
    [TestClass]
    public class ArtistTest
    {
        [TestMethod]
        public void GetAll()
        {
            var da = new ArtistDA();
            
            var lista=da.GetAll("");

            Assert.IsTrue(lista.Count > 0);
        }

        [TestMethod]
        public void Get()
        {
            var da = new ArtistDA();
     
            var entity = da.Get(1);

            Assert.IsTrue(entity.ArtistId > 0);
        }

        [TestMethod]
        public void Insert()
        {
            var da = new ArtistDA();
            var entity = new Artist();

            entity.Name = "Artista Test";

            var id = da.Insert(entity);

            Assert.IsTrue(id> 0);
        }


        [TestMethod]
        public void Update()
        {
            var da = new ArtistDA();
            var entity = new Artist();
            entity.Name = "Artista Update Test";
            entity.ArtistId = 294;
                      
            var result = da.Update(entity);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Delete()
        {
            var da = new ArtistDA();
            var entity = new Artist();

            //Agregando un registro      
            entity.Name = "Artista Test";
            var id = da.Insert(entity);

            //Eliminando el registro
            var result = da.Delete(id);

            Assert.IsTrue(result);
        }

    }
}
