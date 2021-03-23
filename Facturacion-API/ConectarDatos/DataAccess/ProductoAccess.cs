using ConectarDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectarDatos.DataAccess
{
   public static class ProductoAccess
    {

        public static List<Producto> ObtenerProductos()
        {
            try
            {
                using (var dbContextScope = new DBFacturacionEntities())
                {
                    return dbContextScope.Producto.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CrearProducto(Producto Producto)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DBFacturacionEntities())
                {
                    dbContextScope.Producto.Add(Producto);
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

        public static bool EditarProducto(Producto producto)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DBFacturacionEntities())
                {
                    var productoExistente = dbContextScope.Producto.Where(x => x.Id == producto.Id).FirstOrDefault();
                    if (productoExistente != null)
                    {
                        productoExistente.NombreProducto = !string.IsNullOrEmpty(producto.NombreProducto) ? producto.NombreProducto : productoExistente.NombreProducto;
                        productoExistente.Precio = producto.Precio != null ? producto.Precio : productoExistente.Precio;
                        productoExistente.Inventario = producto.Inventario != null ? producto.Inventario : productoExistente.Inventario;

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

        public static bool EliminarProducto(Producto producto)
        {
            bool response = false;
            try
            {
                using (var dbContextScope = new DBFacturacionEntities())
                {
                    var productobuscado = dbContextScope.Producto.Where(x => x.Id == producto.Id).FirstOrDefault();
                    if (productobuscado != null)
                    {
                        dbContextScope.Producto.Remove(productobuscado);
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
