using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository.Interface
{
    public interface IAppUnitOfWork:IDisposable
    {
        IArtistRepository ArtistRepository { get; set; }

        IAlbumRepository AlbumRepository { get; set; }

        int complete();




    }
}
