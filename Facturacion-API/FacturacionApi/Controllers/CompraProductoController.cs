using FacturacionServices.Models;
using FacturacionServices.Response;
using FacturacionServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FacturacionApi.Controllers
{
    [Route("api/CompraProducto/{action}", Name = "CompraProducto")]
    public class CompraProductoController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage ObtenerCompraProductos()
        {
            var response = CompraProductoServices.ObtenerCompraProductos();
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }

        [HttpPost]
        public HttpResponseMessage ObtenerCompraProductosSP()
        {
            var response = CompraProductoServices.ObtenerCompraProductosSP();
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }

        [HttpPost]
        public HttpResponseMessage CrearCompraProducto([FromBody] CompraProductoModel request)
        {
            var response = CompraProductoServices.CrearCompraProducto(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }

        [HttpPost]
        public HttpResponseMessage EditarCompraProducto([FromBody] CompraProductoModel request)
        {
            var response = CompraProductoServices.EditarCompraProducto(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }

        [HttpPost]
        public HttpResponseMessage EliminarCompraProducto([FromBody] CompraProductoModel request)
        {
            var response = CompraProductoServices.EliminarCompraProducto(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }

    }
}
