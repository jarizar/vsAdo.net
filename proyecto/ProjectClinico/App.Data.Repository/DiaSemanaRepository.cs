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
    public class DiaSemanaRepository:GenericRepository<DiaSemana>, IDiaSemanaRepository
    {
        public DiaSemanaRepository(DbContext context) : base(context)
        {

        }
    }
}
