using App.Data.Repository;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace App.WebApi.Controllers
{
    public class ArtistController : ApiController
    {
        public List<Artist> Get()
        {
            var uw = new AppUnitOfWork();
            var artistas = uw.ArtistRepository.GetAll();

            return artistas;        
        }

    }
}
