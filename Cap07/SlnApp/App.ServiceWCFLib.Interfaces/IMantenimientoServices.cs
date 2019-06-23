using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace App.ServiceWCFLib.Interfaces
{ 
    [ServiceContract]
    public interface IMantenimientoServices
    {
        #region Artist
        [OperationContract]
        IEnumerable<Artist> GetArtistAll(string nombre);

        [OperationContract]
        int InsertArtist(Artist entity);

        [OperationContract]
        bool updateArtist(Artist entity);

        [OperationContract]
        bool deleteArtist(int id);

        [OperationContract]
        int GetArtist();
        #endregion

        #region customer
        [OperationContract]
        IEnumerable<Customer> GetCustomerAll(string nombre);

        [OperationContract]
        int InsertCustomer(Customer entity);

        [OperationContract]
        bool updateCustomer(Customer entity);

        [OperationContract]
        bool deleteCustomer(int id);

        [OperationContract]
        int GetCustomer();
        #endregion
        
        #region Employee
        [OperationContract]
        IEnumerable<Employee> GetEmployeeAll(string nombre);

        [OperationContract]
        int InsertEmployee(Employee entity);

        [OperationContract]
        bool updateEmployee(Employee entity);

        [OperationContract]
        bool deleteEmployee(int id);

        [OperationContract]
        int GetEmployee();
        #endregion
        
        #region Album
        [OperationContract]
        IEnumerable<Album> GetAlbumAll(string nombre);

        [OperationContract]
        int InsertAlbum(Album entity);

        [OperationContract]
        bool updateAlbum(Album entity);

        [OperationContract]
        bool deleteAlbum(int id);

        [OperationContract]
        int GetAlbum();
        #endregion

        #region Genre
        [OperationContract]
        IEnumerable<Genre> GetGenreAll(string nombre);

        [OperationContract]
        int InsertGenre(Genre entity);

        [OperationContract]
        bool updateGenre(Genre entity);

        [OperationContract]
        bool deleteGenre(int id);

        [OperationContract]
        int GetGenre();
        #endregion

        #region Invoice
        [OperationContract]
        IEnumerable<Invoice> GetInvoiceAll(string nombre);

        [OperationContract]
        int InsertInvoice(Invoice entity);

        [OperationContract]
        bool updateInvoice(Invoice entity);

        [OperationContract]
        bool deleteInvoice(int id);

        [OperationContract]
        int GetInvoice();
        #endregion

        #region InvoiceLineLine
        [OperationContract]
        IEnumerable<InvoiceLine> GetInvoiceLineAll();

        [OperationContract]
        int InsertInvoiceLine(InvoiceLine entity);

        [OperationContract]
        bool updateInvoiceLine(InvoiceLine entity);

        [OperationContract]
        bool deleteInvoiceLine(int id);

        [OperationContract]
        int GetInvoiceLine();
        #endregion

        #region MediaType
        [OperationContract]
        IEnumerable<MediaType> GetMediaTypeAll(string nombre);

        [OperationContract]
        int InsertMediaType(MediaType entity);

        [OperationContract]
        bool updateMediaType(MediaType entity);

        [OperationContract]
        bool deleteMediaType(int id);

        [OperationContract]
        int GetMediaType();
        #endregion
                     
        #region Playlist
        [OperationContract]
        IEnumerable<Playlist> GetPlaylistAll(string nombre);

        [OperationContract]
        int InsertPlaylist(Playlist entity);

        [OperationContract]
        bool updatePlaylist(Playlist entity);

        [OperationContract]
        bool deletePlaylist(int id);


        [OperationContract]
        int GetPlaylist();
        #endregion

        #region Track
        [OperationContract]
        IEnumerable<Track> GetTrackAll(string nombre);

        [OperationContract]
        int InsertTrack(Track entity);

        [OperationContract]
        bool updateTrack(Track entity);

        [OperationContract]
        bool deleteTrack(int id);


        [OperationContract]
        int GetTrack();
        #endregion

    }
}
