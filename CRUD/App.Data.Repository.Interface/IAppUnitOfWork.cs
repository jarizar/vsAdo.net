using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repository.Interface
{
    public interface IAppUnitOfWork :IDisposable
    {
        IClienteRepository ClienteRepository { get; set; }
        IDetalle_OrdenRepository Detalle_OrdenRepository { get; set; }
        IEstatuRepository EstatuRepository { get; set; }
        IMonedaRepository MonedaRepository { get; set; }
        IOrdenRepository OrdenRepository { get; set; }
        IProductoRepository ProductoRepository { get; set; }
        IProducto_TipoRepository Producto_TipoRepository { get; set; }
        ITipo_ComprobanteRepository Tipo_ComprobanteRepository { get; set; }
        ITipo_DocumentoRepository Tipo_DocumentoRepository { get; set; }

        int Complete();
    }
}
