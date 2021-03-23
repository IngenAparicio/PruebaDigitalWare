using System;


namespace FacturacionServices.Models
{
    public class ProductoModel
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public Nullable<int> Precio { get; set; }
        public Nullable<int> Inventario { get; set; }
    }
}
