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
   public class ProductoServices
    {

        public static ProductosResponse ObtenerProductos()
        {
            var mensajes = new List<Mensaje>();
            try
            {
                List<Producto> productos = ProductoAccess.ObtenerProductos();
                List<ProductoModel> productosModel = ConfigAutomapper.mapper.Map<List<ProductoModel>>(productos);

                mensajes.Add(new Mensaje("1", "Consulta Correcta"));

                return new ProductosResponse(productosModel, true, mensajes);

            }
            catch (Exception ex)
            {

                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new ProductosResponse(null, false, mensajes);
            }
        }

    

    public static ProductoResponse CrearProducto(ProductoModel request)
    {
        var mensajes = new List<Mensaje>();

        try
        {

            Producto producto = ConfigAutomapper.mapper.Map<Producto>(request);
            ProductoAccess.CrearProducto(producto);
            ProductoModel productoModel = ConfigAutomapper.mapper.Map<ProductoModel>(producto);

            mensajes.Add(new Mensaje("1", "Registro Creado"));
            return new ProductoResponse(productoModel, true, mensajes);
          
        }
        catch (Exception ex)
        {
            //Captura de errores
            mensajes.Add(new Mensaje("Error", ex.Message));

            return new ProductoResponse(null, false, mensajes);
        }
    }

    public static ProductoResponse EditarProducto(ProductoModel request)
    {
        var mensajes = new List<Mensaje>();

        try
        {
                Producto producto = ConfigAutomapper.mapper.Map<Producto>(request);
                ProductoAccess.EditarProducto(producto);
                ProductoModel productoModel = ConfigAutomapper.mapper.Map<ProductoModel>(producto);

            mensajes.Add(new Mensaje("1", "Registro actualizado"));
            return new ProductoResponse(productoModel, true, mensajes);
           
        }
        catch (Exception ex)
        {
            //Captura de errores
            mensajes.Add(new Mensaje("Error", ex.Message));

            return new ProductoResponse(null, false, mensajes);
        }
    }

    public static ProductoResponse EliminarProducto(ProductoModel request)
    {
        var mensajes = new List<Mensaje>();

        try
        {

                Producto producto = ConfigAutomapper.mapper.Map<Producto>(request);
                ProductoAccess.EliminarProducto(producto);
                ProductoModel productoModel = ConfigAutomapper.mapper.Map<ProductoModel>(producto);

            mensajes.Add(new Mensaje("1", "Registro Eliminado"));
            return new ProductoResponse(productoModel, true, mensajes);
           
        }
        catch (Exception ex)
        {
            //Captura de errores
            mensajes.Add(new Mensaje("Error", ex.Message));

            return new ProductoResponse(null, false, mensajes);
        }
    }

    }

}
