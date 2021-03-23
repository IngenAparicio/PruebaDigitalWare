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
    public static class ClienteServices
    {

        public static ClientesResponse ObtenerClientes()
        {
            var mensajes = new List<Mensaje>();
            try
            {
                List<Cliente> clientes = ClienteAccess.ObtenerClientes();
                List<ClienteModel> clientesModel = ConfigAutomapper.mapper.Map<List<ClienteModel>>(clientes);

                mensajes.Add(new Mensaje("1", "Consulta Correcta"));

                return new ClientesResponse(clientesModel, true, mensajes);

            }
            catch (Exception ex)
            {

                //Captura de errores
                mensajes.Add(new Mensaje(null, ex.Message));
                return new ClientesResponse(null, false, mensajes);
            }
        }

    

    public static ClienteResponse CrearCliente(ClienteModel request)
    {
        var mensajes = new List<Mensaje>();

        try
        {
            
            Cliente cliente = ConfigAutomapper.mapper.Map<Cliente>(request);
            ClienteAccess.CrearCliente(cliente);
            ClienteModel clienteModel = ConfigAutomapper.mapper.Map<ClienteModel>(cliente);

            mensajes.Add(new Mensaje("1", "Registro Creado"));
            return new ClienteResponse(clienteModel, true, mensajes);
            
        }
        catch (Exception ex)
        {
            //Captura de errores
            mensajes.Add(new Mensaje("Error", ex.Message));

            return new ClienteResponse(null, false, mensajes);
        }
    }

    public static ClienteResponse EditarCliente(ClienteModel request)
    {
        var mensajes = new List<Mensaje>();

        try
        {
          
            Cliente cliente = ConfigAutomapper.mapper.Map<Cliente>(request);
            ClienteAccess.EditarCliente(cliente);
            ClienteModel clienteModel = ConfigAutomapper.mapper.Map<ClienteModel>(cliente);

            mensajes.Add(new Mensaje("1", "Registro Actualizado"));
            return new ClienteResponse(clienteModel, true, mensajes);
            
        }
        catch (Exception ex)
        {
            //Captura de errores
            mensajes.Add(new Mensaje("Error", ex.Message));

            return new ClienteResponse(null, false, mensajes);
        }
    }

    public static ClienteResponse EliminarCliente(ClienteModel request)
    {
        var mensajes = new List<Mensaje>();

        try
        {
           
            Cliente cliente = ConfigAutomapper.mapper.Map<Cliente>(request);
            ClienteAccess.EliminarCliente(cliente);
            ClienteModel clienteModel = ConfigAutomapper.mapper.Map<ClienteModel>(cliente);

            mensajes.Add(new Mensaje("1", "Registro Eliminado"));
            return new ClienteResponse(clienteModel, true, mensajes);
            
        }
        catch (Exception ex)
        {
            //Captura de errores
            mensajes.Add(new Mensaje("Error", ex.Message));

            return new ClienteResponse(null, false, mensajes);
        }
    }

    }

}
