//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConectarDatos
{
    using System;
    
    public partial class CompraProductos
    {
        public int Id { get; set; }
        public Nullable<int> CompraId { get; set; }
        public Nullable<int> ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<int> ValorProducto { get; set; }
        public Nullable<System.DateTime> FechaCompra { get; set; }
    }
}