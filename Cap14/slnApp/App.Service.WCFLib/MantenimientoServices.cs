using App.Data.Repository;
using App.Entities.Base;
using App.Service.WCFLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.WCFLib
{
    public class MantenimientoServices
            : IMantenimientoServices
    {
        public IEnumerable<Artist> GetArtistAll(string nombre)
        {
            var result = new List<Artist>();
            using (var uw = new AppUnitOfWork())
            {
                result = uw.ArtistRepository.GetAll(
                    item=>item.Name.Contains(nombre)
                    );
            }

            return result;
        }

        public int InsertArtist(Artist entity)
        {
            var result = 0;

            using (var uw = new AppUnitOfWork())
            {
                uw.ArtistRepository.Add(entity);
                uw.Complete();

                result = entity.ArtistId;
            }


            return result;
        }
    }
}
