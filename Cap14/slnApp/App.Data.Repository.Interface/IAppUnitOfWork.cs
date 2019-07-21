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
        ITrackRepository TrackRepository { get; set; }
        IGenreRepository GenreRepository { get; set; }
        IMediaTypeRepository MediaTypeRepository { get; set; }
        IInvoiceRepository InvoiceRepository { get; set; }

        int Complete();
    }
}
