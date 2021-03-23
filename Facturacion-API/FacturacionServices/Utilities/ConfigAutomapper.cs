using AutoMapper;
using ConectarDatos;
using FacturacionServices.Models;


namespace FacturacionServices.Utilities
{
    public static class ConfigAutomapper
    {
        public static IMapper mapper { get; set; }
        public static void Config()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CompraModel, Compra>().ReverseMap();
                cfg.CreateMap<CompraModel, Compras>().ReverseMap();
                cfg.CreateMap<CompraProductoModel, CompraProducto>().ReverseMap();
                cfg.CreateMap<CompraProductoModel, CompraProductos>().ReverseMap();
                cfg.CreateMap<ProductoModel, Producto>().ReverseMap();
                cfg.CreateMap<ClienteModel, Cliente>().ReverseMap();
            });
            mapper = config.CreateMapper();
        }
    }
}
