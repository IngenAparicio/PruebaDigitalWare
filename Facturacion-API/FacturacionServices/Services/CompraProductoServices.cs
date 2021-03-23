using FacturacionServices.Models;
using FacturacionServices.Response;
using FacturacionServices.Utilities;
using ConectarDatos;
using ConectarDatos.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionServices.Services
{
    public class CompraProductoServices
    {

        public static CompraProductosResponse ObtenerCompraProductos()
        {
            var mensajes = new List<Mensaje>();
            try
            {
                List<CompraProducto> compraProductos = CompraProductoAccess.ObtenerCompraProductos();
                List<CompraProductoModel> compraProductosModel = ConfigAutomapper.mapper.Map<List<CompraProductoModel>>(compraProductos);

                mensajes.Add(new Mensaje("1", "Consulta Correcta"));

                return new CompraProductosResponse(compraProductosModel, true, mensajes);

            }
            catch (Exception ex)
            {

                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new CompraProductosResponse(null, false, mensajes);
            }
        }

        public static CompraProductosResponse ObtenerCompraProductosSP()
        {
            var mensajes = new List<Mensaje>();
            try
            {
                List<CompraProductos> compraProductos = CompraProductoAccess.ObtenerCompraProductosSP();
                List<CompraProductoModel> compraProductosModel = ConfigAutomapper.mapper.Map<List<CompraProductoModel>>(compraProductos);

                mensajes.Add(new Mensaje("1", "Consulta Correcta"));

                return new CompraProductosResponse(compraProductosModel, true, mensajes);

            }
            catch (Exception ex)
            {

                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new CompraProductosResponse(null, false, mensajes);
            }
        }



        public static CompraProductoResponse CrearCompraProducto(CompraProductoModel request)
    {
        var mensajes = new List<Mensaje>();

        try
        {

            CompraProducto compraProducto = ConfigAutomapper.mapper.Map<CompraProducto>(request);
            CompraProductoAccess.CrearCompraProducto(compraProducto);
            CompraProductoModel compraProductoModel = ConfigAutomapper.mapper.Map<CompraProductoModel>(compraProducto);

            mensajes.Add(new Mensaje("1", "Registro Creado"));
            return new CompraProductoResponse(compraProductoModel, true, mensajes);
          
        }
        catch (Exception ex)
        {
            //Captura de errores
            mensajes.Add(new Mensaje("Error", ex.Message));

            return new CompraProductoResponse(null, false, mensajes);
        }
    }

    public static CompraProductoResponse EditarCompraProducto(CompraProductoModel request)
    {
        var mensajes = new List<Mensaje>();

        try
        {
                CompraProducto compraProducto = ConfigAutomapper.mapper.Map<CompraProducto>(request);
                CompraProductoAccess.EditarCompraProducto(compraProducto);
                CompraProductoModel compraProductoModel = ConfigAutomapper.mapper.Map<CompraProductoModel>(compraProducto);

            mensajes.Add(new Mensaje("1", "Registro actualizado"));
            return new CompraProductoResponse(compraProductoModel, true, mensajes);
           
        }
        catch (Exception ex)
        {
            //Captura de errores
            mensajes.Add(new Mensaje("Error", ex.Message));

            return new CompraProductoResponse(null, false, mensajes);
        }
    }

    public static CompraProductoResponse EliminarCompraProducto(CompraProductoModel request)
    {
        var mensajes = new List<Mensaje>();

        try
        {

                CompraProducto compraProducto = ConfigAutomapper.mapper.Map<CompraProducto>(request);
                CompraProductoAccess.EliminarCompraProducto(compraProducto);
                CompraProductoModel compraProductoModel = ConfigAutomapper.mapper.Map<CompraProductoModel>(compraProducto);

            mensajes.Add(new Mensaje("1", "Registro Eliminado"));
            return new CompraProductoResponse(compraProductoModel, true, mensajes);
           
        }
        catch (Exception ex)
        {
            //Captura de errores
            mensajes.Add(new Mensaje("Error", ex.Message));

            return new CompraProductoResponse(null, false, mensajes);
        }
    }

    }

}
