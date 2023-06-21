using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TiendaArteApi.Models.Dto
{
    public class ComisionDto
    {
        [Required]
        public int ComisionCode { get; set; }
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
