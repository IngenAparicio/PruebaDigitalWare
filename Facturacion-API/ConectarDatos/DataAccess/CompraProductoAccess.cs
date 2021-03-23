using ConectarDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectarDatos.DataAccess
{
   public static class CompraProductoAccess
    {

        public static List<CompraProducto> ObtenerCompraProductos()
        {
            try
            {
                using (var dbContextScope = new DBFacturacionEntities())
                {
                    return dbContextScope.CompraProducto.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<CompraProductos> ObtenerCompraProductosSP()
        {
            try
            {
                using (var dbContextScope = new DBFacturacionEntities())
                {
                    return dbContextScope.ObtenerCompraProductos().ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CrearCompraProducto(CompraProducto compraProducto)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DBFacturacionEntities())
                {
                    dbContextScope.CompraProducto.Add(compraProducto);
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

        public static bool EditarCompraProducto(CompraProducto compraProducto)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DBFacturacionEntities())
                {
                    var CompraProductoExistente = dbContextScope.CompraProducto.Where(x => x.Id == compraProducto.Id).FirstOrDefault();
                    if (CompraProductoExistente != null)
                    {
                        CompraProductoExistente.CompraId = compraProducto.CompraId != null ? compraProducto.CompraId : CompraProductoExistente.CompraId;
                        CompraProductoExistente.ProductoId = compraProducto.ProductoId != null ? compraProducto.ProductoId : CompraProductoExistente.ProductoId;
                        CompraProductoExistente.Cantidad = compraProducto.Cantidad != null ? compraProducto.Cantidad : CompraProductoExistente.Cantidad;
                        CompraProductoExistente.ValorProducto = compraProducto.ValorProducto != null ? compraProducto.ValorProducto : CompraProductoExistente.ValorProducto;
                        CompraProductoExistente.FechaCompra = compraProducto.FechaCompra != null ? compraProducto.FechaCompra : CompraProductoExistente.FechaCompra;

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

        public static bool EliminarCompraProducto(CompraProducto compraProducto)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DBFacturacionEntities())
                {
                    var compraProductobuscado = dbContextScope.CompraProducto.Where(x => x.Id == compraProducto.Id).FirstOrDefault();
                    if (compraProductobuscado != null)
                    {
                        dbContextScope.CompraProducto.Remove(compraProductobuscado);
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
