using App.Data.Repository.Interface;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
   public class AlbumRepository:GenericRepository<Album>,IAlbumRepository 
    {
        public AlbumRepository(DbContext context) : base(context) {
        }

    }
}
