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
    class MediaTypeRepository : GenericRepository<MediaType>, IMediaTypeRepository
    {
        public MediaTypeRepository(DbContext context) : base(context)
        {
        }

    }
}
