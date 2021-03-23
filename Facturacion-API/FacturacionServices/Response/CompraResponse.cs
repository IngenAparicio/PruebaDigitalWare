using System.Collections.Generic;
using FacturacionServices.Models;

namespace FacturacionServices.Response
{
    public sealed class CompraResponse : BaseGatewayResponse
    {
        public CompraModel Compra { get; set; }

        public CompraResponse(CompraModel compraModel, bool success = false, IEnumerable<Mensaje> mensajes = null) : base(success, mensajes)
        {
            Compra = compraModel;
        }
    }

    public sealed class ComprasResponse : BaseGatewayResponse
    {
        public List<CompraModel> Compra { get; set; }

        public ComprasResponse(List<CompraModel> compraModel, bool success = false, IEnumerable<Mensaje> mensajes = null) : base(success, mensajes)
        {
            Compra = compraModel;
        }
    }
}
