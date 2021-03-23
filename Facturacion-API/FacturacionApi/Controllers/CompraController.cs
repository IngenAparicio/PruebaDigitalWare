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
    [Route("api/Compra/{action}", Name = "Compra")]
    public class CompraController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage ObtenerCompras()
        {
            var response = CompraServices.ObtenerCompras();
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }

        [HttpPost]
        public HttpResponseMessage ObtenerComprasSP()
        {
            var response = CompraServices.ObtenerComprasSP();
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }

        [HttpPost]
        public HttpResponseMessage CrearCompra([FromBody] CompraModel request)
        {
            var response = CompraServices.CrearCompra(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }

        [HttpPost]
        public HttpResponseMessage EditarCompra([FromBody] CompraModel request)
        {
            var response = CompraServices.EditarCompra(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }

        [HttpPost]
        public HttpResponseMessage EliminarCompra([FromBody] CompraModel request)
        {
            var response = CompraServices.EliminarCompra(request);
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK, response);
            return result;
        }

    }
}
