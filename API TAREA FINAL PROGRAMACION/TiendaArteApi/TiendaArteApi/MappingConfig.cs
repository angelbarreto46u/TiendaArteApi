using AutoMapper;
using TiendaArteApi.Models;
using TiendaArteApi.Models.Dto;

namespace TiendaArteApi
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Comisiones, ComisionCreateDto>().ReverseMap();
            CreateMap<Comisiones, ComisionDto>().ReverseMap();
            CreateMap<Comisiones, ComisionUpdateDto>().ReverseMap();

            CreateMap<Inventario, InventarioCreateDto>().ReverseMap();
            CreateMap<Inventario, InventarioDto>().ReverseMap();
            CreateMap<Inventario, InventarioUpdateDto>().ReverseMap();

            CreateMap<Ventas, VentasCreateDto>().ReverseMap();
            CreateMap<Ventas, VentasDto>().ReverseMap();
            CreateMap<Ventas, VentasUpdateDto>().ReverseMap();
        }
    }
}
