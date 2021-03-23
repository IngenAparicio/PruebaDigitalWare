using System.Collections.Generic;
using FacturacionServices.Models;

namespace FacturacionServices.Response
{
    public sealed class ClienteResponse : BaseGatewayResponse
    {
        public ClienteModel Cliente { get; set; }

        public ClienteResponse(ClienteModel clienteModel, bool success = false, IEnumerable<Mensaje> mensajes = null) : base(success, mensajes)
        {
            Cliente = clienteModel;
        }
    }

    public sealed class ClientesResponse : BaseGatewayResponse
    {
        public List<ClienteModel> Cliente { get; set; }

        public ClientesResponse(List<ClienteModel> clienteModel, bool success = false, IEnumerable<Mensaje> mensajes = null) : base(success, mensajes)
        {
            Cliente = clienteModel;
        }
    }
}
