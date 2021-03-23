using ConectarDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectarDatos.DataAccess
{
   public static class ClienteAccess
    {

        public static List<Cliente> ObtenerClientes()
        {
            try
            {
                using (var dbContextScope = new DBFacturacionEntities())
                {
                    return dbContextScope.Cliente.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CrearCliente(Cliente cliente)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DBFacturacionEntities())
                {
                    dbContextScope.Cliente.Add(cliente);
                    dbContextScope.SaveChanges();
                    response = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return response;
        }

        public static bool EditarCliente(Cliente cliente)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DBFacturacionEntities())
                {
                    var clienteExistente = dbContextScope.Cliente.Where(x => x.Id == cliente.Id).FirstOrDefault();
                    if (clienteExistente != null)
                    {
                        clienteExistente.Edad = cliente.Edad != null ? cliente.Edad : clienteExistente.Edad;
                        clienteExistente.Nombre = !string.IsNullOrEmpty(cliente.Nombre) ? cliente.Nombre : clienteExistente.Nombre;

                        dbContextScope.SaveChanges();
                        response = true;
                    }

                }
            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }

            return response;
        }

        public static bool EliminarCliente(Cliente cliente)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DBFacturacionEntities())
                {
                    var clientebuscado = dbContextScope.Cliente.Where(x => x.Id == cliente.Id).FirstOrDefault();
                    if (clientebuscado != null)
                    {
                        dbContextScope.Cliente.Remove(clientebuscado);
                        dbContextScope.SaveChanges();
                        response = true;
                    }

                }
            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }

            return response;
        }

    }
}
