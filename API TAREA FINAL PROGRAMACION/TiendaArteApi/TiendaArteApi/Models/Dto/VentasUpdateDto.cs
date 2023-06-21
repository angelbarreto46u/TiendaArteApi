using System.ComponentModel.DataAnnotations;

namespace TiendaArteApi.Models.Dto
{
    public class VentasUpdateDto
    {
        public int VentasCode { get; set; }
        public string? ClienteName { get; set; }
        public string? Solicitud { get; set; }
        public double PrecioVenta { get; set; }
        public string? Direccion { get; set; }
        public DateTime FechaEntrega { get; set; }
    }
}
