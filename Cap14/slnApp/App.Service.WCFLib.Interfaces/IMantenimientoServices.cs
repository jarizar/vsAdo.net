using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.WCFLib.Interfaces
{
    [ServiceContract]
    public interface IMantenimientoServices
    {

        #region Artist

        IEnumerable< Artist> GetArtistAll(string nombre);

        [OperationContract]
        int InsertArtist(Artist entity);

        #endregion

        #region albums

        #endregion
    }
}
