using System.Collections.Generic;
using FacturacionServices.Models;

namespace FacturacionServices.Response
{
    public sealed class CompraProductoResponse : BaseGatewayResponse
    {
        public CompraProductoModel CompraProducto { get; set; }

        public CompraProductoResponse(CompraProductoModel compraProductoModel, bool success = false, IEnumerable<Mensaje> mensajes = null) : base(success, mensajes)
        {
            CompraProducto = compraProductoModel;
        }
    }

    public sealed class CompraProductosResponse : BaseGatewayResponse
    {
        public List<CompraProductoModel> CompraProducto { get; set; }

        public CompraProductosResponse(List<CompraProductoModel> compraProductoModel, bool success = false, IEnumerable<Mensaje> mensajes = null) : base(success, mensajes)
        {
            CompraProducto = compraProductoModel;
        }
    }
}
