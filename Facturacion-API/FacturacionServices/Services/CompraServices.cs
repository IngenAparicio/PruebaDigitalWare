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
    public class CompraServices
    {

        public static ComprasResponse ObtenerCompras()
        {
            var mensajes = new List<Mensaje>();
            try
            {
                List<Compra> compras = CompraAccess.ObtenerCompras();
                List<CompraModel> comprasModel = ConfigAutomapper.mapper.Map<List<CompraModel>>(compras);

                mensajes.Add(new Mensaje("1", "Consulta Correcta"));

                return new ComprasResponse(comprasModel, true, mensajes);

            }
            catch (Exception ex)
            {

                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new ComprasResponse(null, false, mensajes);
            }
        }

        public static ComprasResponse ObtenerComprasSP()
        {
            var mensajes = new List<Mensaje>();
            try
            {
                List<Compras> compras = CompraAccess.ObtenerComprasSP();
                List<CompraModel> comprasModel = ConfigAutomapper.mapper.Map<List<CompraModel>>(compras);

                mensajes.Add(new Mensaje("1", "Consulta Correcta"));

                return new ComprasResponse(comprasModel, true, mensajes);

            }
            catch (Exception ex)
            {

                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new ComprasResponse(null, false, mensajes);
            }
        }



        public static CompraResponse CrearCompra(CompraModel request)
    {
        var mensajes = new List<Mensaje>();

        try
        {
            
            Compra compra = ConfigAutomapper.mapper.Map<Compra>(request);
            CompraAccess.CrearCompra(compra);
            CompraModel compraModel = ConfigAutomapper.mapper.Map<CompraModel>(compra);

            mensajes.Add(new Mensaje("1", "Registro Creado"));
            return new CompraResponse(compraModel, true, mensajes);
          
        }
        catch (Exception ex)
        {
            //Captura de errores
            mensajes.Add(new Mensaje("Error", ex.Message));

            return new CompraResponse(null, false, mensajes);
        }
    }

    public static CompraResponse EditarCompra(CompraModel request)
    {
        var mensajes = new List<Mensaje>();

        try
        {
            Compra compra = ConfigAutomapper.mapper.Map<Compra>(request);
            CompraAccess.EditarCompra(compra);
            CompraModel compraModel = ConfigAutomapper.mapper.Map<CompraModel>(compra);

            mensajes.Add(new Mensaje("1", "Registro actualizado"));
            return new CompraResponse(compraModel, true, mensajes);
           
        }
        catch (Exception ex)
        {
            //Captura de errores
            mensajes.Add(new Mensaje("Error", ex.Message));

            return new CompraResponse(null, false, mensajes);
        }
    }

    public static CompraResponse EliminarCompra(CompraModel request)
    {
        var mensajes = new List<Mensaje>();

        try
        {

            Compra compra = ConfigAutomapper.mapper.Map<Compra>(request);
            CompraAccess.EliminarCompra(compra);
            CompraModel compraModel = ConfigAutomapper.mapper.Map<CompraModel>(compra);

            mensajes.Add(new Mensaje("1", "Registro Eliminado"));
            return new CompraResponse(compraModel, true, mensajes);
           
        }
        catch (Exception ex)
        {
            //Captura de errores
            mensajes.Add(new Mensaje("Error", ex.Message));

            return new CompraResponse(null, false, mensajes);
        }
    }

    }

}
