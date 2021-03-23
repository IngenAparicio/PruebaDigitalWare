using System;


namespace FacturacionServices.Models
{
    public class CompraProductoModel
    {
        public int Id { get; set; }
        public int? CompraId { get; set; }
        public int? ProductoId { get; set; }
        public int? Cantidad { get; set; }
        public int? ValorProducto { get; set; }
        public DateTime? FechaCompra { get; set; }
        // extendida
        public string NombreProducto { get; set; }
    }
}
