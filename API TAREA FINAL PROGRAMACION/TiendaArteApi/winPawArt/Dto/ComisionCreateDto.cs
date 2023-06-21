using System.ComponentModel.DataAnnotations;

namespace TiendaArteApi.Models.Dto
{
    public class ComisionCreateDto
    {
        [Required]
        public string? ClienteName { get; set; }
        [Required]
        public string? Descripcion { get; set; }
        [Required]
        public string? Direccion { get; set; }
        [Required]
        public DateTime FechaEntrega { get; set; }
    }
}
