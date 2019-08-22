using App.Data.DataAccess;
using App.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository
{
    public class AppUnitOfWork : IAppUnitOfWork
    {
        private readonly DbContext _context;

        public AppUnitOfWork()
        {
            _context = new DBModel();

            this.ArtistRepository = new ArtistRepository(_context);
            this.AlbumRepository = new AlbumRepository(_context);
            this.TrackRepository = new TrackRepository(_context);
            this.GenreRepository = new GenreRepository(_context);
            this.MediaTypeRepository = new MediaTypeRepository(_context);
            this.InvoiceRepository = new InvoiceRepository(_context);
            this.UsuarioRepository = new UsuarioRepository(_context);
        }

        public IArtistRepository ArtistRepository { get; set; }
        public IAlbumRepository AlbumRepository { get; set; }
        public ITrackRepository TrackRepository { get; set; }
        public IGenreRepository GenreRepository { get; set; }
        public IMediaTypeRepository MediaTypeRepository { get; set; }
        public IInvoiceRepository InvoiceRepository { get; set; }
        public IUsuarioRepository UsuarioRepository { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
