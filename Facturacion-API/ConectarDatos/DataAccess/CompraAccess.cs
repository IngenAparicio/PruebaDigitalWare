using ConectarDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectarDatos.DataAccess
{
   public static class CompraAccess
    {

        public static List<Compra> ObtenerCompras()
        {
            try
            {
                using (var dbContextScope = new DBFacturacionEntities())
                {
                    return dbContextScope.Compra.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Compras> ObtenerComprasSP()
        {
            try
            {
                using (var dbContextScope = new DBFacturacionEntities())
                {
                    return dbContextScope.ObtenerCompras().ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CrearCompra(Compra compra)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DBFacturacionEntities())
                {
                    dbContextScope.Compra.Add(compra);
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

        public static bool EditarCompra(Compra compra)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DBFacturacionEntities())
                {
                    var CompraExistente = dbContextScope.Compra.Where(x => x.Id == compra.Id).FirstOrDefault();
                    if (CompraExistente != null)
                    {
                        CompraExistente.ClienteId = compra.ClienteId != null ? compra.ClienteId : CompraExistente.ClienteId;

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

        public static bool EliminarCompra(Compra compra)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DBFacturacionEntities())
                {
                    var comprabuscado = dbContextScope.Compra.Where(x => x.Id == compra.Id).FirstOrDefault();
                    if (comprabuscado != null)
                    {
                        dbContextScope.Compra.Remove(comprabuscado);
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
