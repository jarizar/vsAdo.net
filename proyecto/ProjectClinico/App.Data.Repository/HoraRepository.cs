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
    public class HoraRepository:GenericRepository<Hora>,IHoraRepository
    {
        public HoraRepository(DbContext context) : base(context)
        {

        }
    }
}
