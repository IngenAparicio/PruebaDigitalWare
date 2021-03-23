using System;


namespace FacturacionServices.Models
{
    public class CompraModel
    {
        public int Id { get; set; }
        public int? ClienteId { get; set; }

        //extendidas
        public string NombreCliente { get; set; }
        public string NombreProducto { get; set; }
        public int? CantidadVenta { get; set; }
        public int? ValorCompra { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
