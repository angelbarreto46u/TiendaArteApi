using System.ComponentModel.DataAnnotations;

namespace TiendaArteApi.Models.Dto
{
    public class VentasCreateDto
    {
        [Required]
        public string? ClienteName { get; set; }
        [Required]
        public string? Solicitud { get; set; }
        [Required]
        public double PrecioVenta { get; set; }
        [Required]
        public string? Direccion { get; set; }
        [Required]
        public DateTime FechaEntrega { get; set; }
    }
}
