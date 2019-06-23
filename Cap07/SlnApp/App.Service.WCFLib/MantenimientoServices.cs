using App.Data.Repository;
using App.Entities.Base;
using App.ServiceWCFLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Service.WCFLib
{
    public class MantenimientoServices : IMantenimientoServices
    {

        #region Artist

        public bool deleteArtist(int id)
        {
            var result = false;
            var entity = new Artist();
            entity.ArtistId = id;

            using (var Uw = new AppUnitOfWork())
            {
                Uw.ArtistRepository.Remove(entity);
              
                Uw.complete();

                result = true;
                
            }

            return result;
        }

        public int GetArtist()
        {
           var result = 0;
           
            using (var Uw = new AppUnitOfWork())
            {
                result = Uw.ArtistRepository.count();
            }
            return result;
        }

        public IEnumerable<Artist> GetArtistAll(string nombre)
        {
            var result=new List<Artist>();
            using (var Uw = new AppUnitOfWork())
            {
                result = Uw.ArtistRepository.GetAll(
                    item=>item.Name.Contains(nombre));
            }
            return result;
        }

        public int InsertArtist(Artist entity)
        {
            var result = 0;

            using (var Uw = new AppUnitOfWork())
            {
                Uw.ArtistRepository.Add(entity);
                Uw.complete();

                result = entity.ArtistId;
            }

            return result;
        }

        public bool updateArtist(Artist entity)
        {
            var result = false;
         

            using (var Uw = new AppUnitOfWork())
            {
                Uw.ArtistRepository.Update(entity);
                Uw.complete();

                result = true;
            }

            return result;
        }
        #endregion

        #region Customer
        public bool deleteCustomer(int id)
        {
            var result = false;
            var entity = new Customer();
            entity.CustomerId = id;

            using (var Uw = new AppUnitOfWork())
            {
                Uw.CustomerRepository.Remove(entity);

                Uw.complete();

                result = true;

            }

            return result;
        }

        public int GetCustomer()
        {
            var result = 0;

            using (var Uw = new AppUnitOfWork())
            {
                result = Uw.CustomerRepository.count();
            }
            return result;
        }

        public IEnumerable<Customer> GetCustomerAll(string nombre)
        {
            var result = new List<Customer>();
            using (var Uw = new AppUnitOfWork())
            {
                result = Uw.CustomerRepository.GetAll(
                    item => item.FirstName.Contains(nombre));
            }
            return result;
        }

        public int InsertCustomer(Customer entity)
        {
            var result = 0;

            using (var Uw = new AppUnitOfWork())
            {
                Uw.CustomerRepository.Add(entity);
                Uw.complete();

                result = entity.CustomerId;
            }

            return result;
        }

        public bool updateCustomer(Customer entity)
        {
            var result = false;


            using (var Uw = new AppUnitOfWork())
            {
                Uw.CustomerRepository.Update(entity);
                Uw.complete();

                result = true;
            }

            return result;
        }
        #endregion

        #region Employee
        public bool deleteEmployee(int id)
        {
            var result = false;
            var entity = new Employee();
            entity.EmployeeId = id;

            using (var Uw = new AppUnitOfWork())
            {
                Uw.EmployeeRepository.Remove(entity);

                Uw.complete();

                result = true;

            }

            return result;
        }

        public int GetEmployee()
        {
            var result = 0;

            using (var Uw = new AppUnitOfWork())
            {
                result = Uw.EmployeeRepository.count();
            }
            return result;
        }

        public IEnumerable<Employee> GetEmployeeAll(string nombre)
        {
            var result = new List<Employee>();
            using (var Uw = new AppUnitOfWork())
            {
                result = Uw.EmployeeRepository.GetAll(
                    item => item.FirstName.Contains(nombre));
            }
            return result;
        }

        public int InsertEmployee(Employee entity)
        {
            var result = 0;

            using (var Uw = new AppUnitOfWork())
            {
                Uw.EmployeeRepository.Add(entity);
                Uw.complete();

                result = entity.EmployeeId;
            }

            return result;
        }

        public bool updateEmployee(Employee entity)
        {
            var result = false;


            using (var Uw = new AppUnitOfWork())
            {
                Uw.EmployeeRepository.Update(entity);
                Uw.complete();

                result = true;
            }

            return result;
        }
        #endregion

        #region Album
        public bool deleteAlbum(int id)
        {
            var result = false;
            var entity = new Album();
            entity.AlbumId = id;

            using (var Uw = new AppUnitOfWork())
            {
                Uw.AlbumRepository.Remove(entity);

                Uw.complete();

                result = true;

            }

            return result;
        }

        public int GetAlbum()
        {
            var result = 0;

            using (var Uw = new AppUnitOfWork())
            {
                result = Uw.AlbumRepository.count();
            }
            return result;
        }

        public IEnumerable<Album> GetAlbumAll(string nombre)
        {
            var result = new List<Album>();
            using (var Uw = new AppUnitOfWork())
            {
                result = Uw.AlbumRepository.GetAll(
                    item => item.Title.Contains(nombre));
            }
            return result;
        }

        public int InsertAlbum(Album entity)
        {
            var result = 0;

            using (var Uw = new AppUnitOfWork())
            {
                Uw.AlbumRepository.Add(entity);
                Uw.complete();

                result = entity.AlbumId;
            }

            return result;
        }

        public bool updateAlbum(Album entity)
        {
            var result = false;


            using (var Uw = new AppUnitOfWork())
            {
                Uw.AlbumRepository.Update(entity);
                Uw.complete();

                result = true;
            }

            return result;
        }
        #endregion

        #region Genre
        public bool deleteGenre(int id)
        {
            var result = false;
            var entity = new Genre();
            entity.GenreId = id;

            using (var Uw = new AppUnitOfWork())
            {
                Uw.GenreRepository.Remove(entity);

                Uw.complete();

                result = true;

            }

            return result;
        }

        public int GetGenre()
        {
            var result = 0;

            using (var Uw = new AppUnitOfWork())
            {
                result = Uw.GenreRepository.count();
            }
            return result;
        }

        public IEnumerable<Genre> GetGenreAll(string nombre)
        {
            var result = new List<Genre>();
            using (var Uw = new AppUnitOfWork())
            {
                result = Uw.GenreRepository.GetAll(
                    item => item.Name.Contains(nombre));
            }
            return result;
        }

        public int InsertGenre(Genre entity)
        {
            var result = 0;

            using (var Uw = new AppUnitOfWork())
            {
                Uw.GenreRepository.Add(entity);
                Uw.complete();

                result = entity.GenreId;
            }

            return result;
        }

        public bool updateGenre(Genre entity)
        {
            var result = false;


            using (var Uw = new AppUnitOfWork())
            {
                Uw.GenreRepository.Update(entity);
                Uw.complete();

                result = true;
            }

            return result;
        }
        #endregion

        #region Invoice
        public bool deleteInvoice(int id)
        {
            var result = false;
            var entity = new Invoice();
            entity.InvoiceId = id;

            using (var Uw = new AppUnitOfWork())
            {
                Uw.InvoiceRepository.Remove(entity);

                Uw.complete();

                result = true;

            }

            return result;
        }

        public int GetInvoice()
        {
            var result = 0;

            using (var Uw = new AppUnitOfWork())
            {
                result = Uw.InvoiceRepository.count();
            }
            return result;
        }

        public IEnumerable<Invoice> GetInvoiceAll(string nombre)
        {
            var result = new List<Invoice>();
            using (var Uw = new AppUnitOfWork())
            {
                result = Uw.InvoiceRepository.GetAll(
                    item => item.BillingCountry.Contains(nombre));
            }
            return result;
        }

        public int InsertInvoice(Invoice entity)
        {
            var result = 0;

            using (var Uw = new AppUnitOfWork())
            {
                Uw.InvoiceRepository.Add(entity);
                Uw.complete();

                result = entity.InvoiceId;
            }

            return result;
        }

        public bool updateInvoice(Invoice entity)
        {
            var result = false;


            using (var Uw = new AppUnitOfWork())
            {
                Uw.InvoiceRepository.Update(entity);
                Uw.complete();

                result = true;
            }

            return result;
        }
        #endregion

        #region InvoiceLine
        public bool deleteInvoiceLine(int id)
        {
            var result = false;
            var entity = new InvoiceLine();
            entity.InvoiceLineId = id;

            using (var Uw = new AppUnitOfWork())
            {
                Uw.InvoiceLineRepository.Remove(entity);

                Uw.complete();

                result = true;

            }

            return result;
        }

        public int GetInvoiceLine()
        {
            var result = 0;

            using (var Uw = new AppUnitOfWork())
            {
                result = Uw.InvoiceLineRepository.count();
            }
            return result;
        }

        public IEnumerable<InvoiceLine> GetInvoiceLineAll()
        {
            var result = new List<InvoiceLine>();
            using (var Uw = new AppUnitOfWork())
            {
                result = Uw.InvoiceLineRepository.GetAll();
            }
            return result;
        }

        public int InsertInvoiceLine(InvoiceLine entity)
        {
            var result = 0;

            using (var Uw = new AppUnitOfWork())
            {
                Uw.InvoiceLineRepository.Add(entity);
                Uw.complete();

                result = entity.InvoiceLineId;
            }

            return result;
        }

        public bool updateInvoiceLine(InvoiceLine entity)
        {
            var result = false;


            using (var Uw = new AppUnitOfWork())
            {
                Uw.InvoiceLineRepository.Update(entity);
                Uw.complete();

                result = true;
            }

            return result;
        }
        #endregion

        #region MediaType
        public bool deleteMediaType(int id)
        {
            var result = false;
            var entity = new MediaType();
            entity.MediaTypeId = id;

            using (var Uw = new AppUnitOfWork())
            {
                Uw.MediaTypeRepository.Remove(entity);

                Uw.complete();

                result = true;

            }

            return result;
        }

        public int GetMediaType()
        {
            var result = 0;

            using (var Uw = new AppUnitOfWork())
            {
                result = Uw.MediaTypeRepository.count();
            }
            return result;
        }

        public IEnumerable<MediaType> GetMediaTypeAll(string nombre)
        {
            var result = new List<MediaType>();
            using (var Uw = new AppUnitOfWork())
            {
                result = Uw.MediaTypeRepository.GetAll(
                    item => item.Name.Contains(nombre));
            }
            return result;
        }

        public int InsertMediaType(MediaType entity)
        {
            var result = 0;

            using (var Uw = new AppUnitOfWork())
            {
                Uw.MediaTypeRepository.Add(entity);
                Uw.complete();

                result = entity.MediaTypeId;
            }

            return result;
        }

        public bool updateMediaType(MediaType entity)
        {
            var result = false;


            using (var Uw = new AppUnitOfWork())
            {
                Uw.MediaTypeRepository.Update(entity);
                Uw.complete();

                result = true;
            }

            return result;
        }
        #endregion

        #region Playlist
        public bool deletePlaylist(int id)
        {
            var result = false;
            var entity = new Playlist();
            entity.PlaylistId = id;

            using (var Uw = new AppUnitOfWork())
            {
                Uw.PlaylistRepository.Remove(entity);

                Uw.complete();

                result = true;

            }

            return result;
        }

        public int GetPlaylist()
        {
            var result = 0;

            using (var Uw = new AppUnitOfWork())
            {
                result = Uw.PlaylistRepository.count();
            }
            return result;
        }

        public IEnumerable<Playlist> GetPlaylistAll(string nombre)
        {
            var result = new List<Playlist>();
            using (var Uw = new AppUnitOfWork())
            {
                result = Uw.PlaylistRepository.GetAll(
                    item => item.Name.Contains(nombre));
            }
            return result;
        }

        public int InsertPlaylist(Playlist entity)
        {
            var result = 0;

            using (var Uw = new AppUnitOfWork())
            {
                Uw.PlaylistRepository.Add(entity);
                Uw.complete();

                result = entity.PlaylistId;
            }

            return result;
        }

        public bool updatePlaylist(Playlist entity)
        {
            var result = false;


            using (var Uw = new AppUnitOfWork())
            {
                Uw.PlaylistRepository.Update(entity);
                Uw.complete();

                result = true;
            }

            return result;
        }
        #endregion
        
        #region Track
        public bool deleteTrack(int id)
        {
            var result = false;
            var entity = new Track();
            entity.TrackId = id;

            using (var Uw = new AppUnitOfWork())
            {
                Uw.TrackRepository.Remove(entity);

                Uw.complete();

                result = true;

            }

            return result;
        }

        public int GetTrack()
        {
            var result = 0;

            using (var Uw = new AppUnitOfWork())
            {
                result = Uw.TrackRepository.count();
            }
            return result;
        }

        public IEnumerable<Track> GetTrackAll(string nombre)
        {
            var result = new List<Track>();
            using (var Uw = new AppUnitOfWork())
            {
                result = Uw.TrackRepository.GetAll(
                    item => item.Name.Contains(nombre));
            }
            return result;
        }

        public int InsertTrack(Track entity)
        {
            var result = 0;

            using (var Uw = new AppUnitOfWork())
            {
                Uw.TrackRepository.Add(entity);
                Uw.complete();

                result = entity.TrackId;
            }

            return result;
        }

        public bool updateTrack(Track entity)
        {
            var result = false;


            using (var Uw = new AppUnitOfWork())
            {
                Uw.TrackRepository.Update(entity);
                Uw.complete();

                result = true;
            }

            return result;
        }
        #endregion

    }
}
