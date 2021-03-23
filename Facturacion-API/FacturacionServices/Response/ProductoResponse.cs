using System.Collections.Generic;
using FacturacionServices.Models;

namespace FacturacionServices.Response
{
    public sealed class ProductoResponse : BaseGatewayResponse
    {
        public ProductoModel Producto { get; set; }

        public ProductoResponse(ProductoModel productoModel, bool success = false, IEnumerable<Mensaje> mensajes = null) : base(success, mensajes)
        {
            Producto = productoModel;
        }
    }

    public sealed class ProductosResponse : BaseGatewayResponse
    {
        public List<ProductoModel> Producto { get; set; }

        public ProductosResponse(List<ProductoModel> productoModel, bool success = false, IEnumerable<Mensaje> mensajes = null) : base(success, mensajes)
        {
            Producto = productoModel;
        }
    }
}
