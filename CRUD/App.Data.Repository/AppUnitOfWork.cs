using App.Data.DataAccess;
using App.Data.Repository.Interface;
using System;
using System.Data.Entity;

namespace App.Data.Repository
{
    public class AppUnitOfWork : IAppUnitOfWork
    {
        private readonly DbContext _context;

        public AppUnitOfWork() {
            _context = new CnxBDEmpresaEntities();


        this.ClienteRepository = new ClienteRepository(_context);
        this.Detalle_OrdenRepository =new Detalle_OrdenRepository (_context);
        this.EstatuRepository =new EstatuRepository (_context);
        this.MonedaRepository =new MonedaRepository (_context);
        this.OrdenRepository =new OrdenRepository (_context);
        this.ProductoRepository=new  ProductoRepository (_context);
        this.Producto_TipoRepository =new Producto_TipoRepository (_context);
        this.Tipo_ComprobanteRepository =new Tipo_ComprobanteRepository (_context);
        this.Tipo_DocumentoRepository =new Tipo_DocumentoRepository (_context);


    }


        public IClienteRepository ClienteRepository { get; set; }
        public IDetalle_OrdenRepository Detalle_OrdenRepository { get; set; }
        public IEstatuRepository EstatuRepository { get; set; }
        public IMonedaRepository MonedaRepository { get; set; }
        public IOrdenRepository OrdenRepository { get; set; }
        public IProductoRepository ProductoRepository { get; set; }
        public IProducto_TipoRepository Producto_TipoRepository { get; set; }
        public ITipo_ComprobanteRepository Tipo_ComprobanteRepository { get; set; }
        public ITipo_DocumentoRepository Tipo_DocumentoRepository { get; set; }

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
