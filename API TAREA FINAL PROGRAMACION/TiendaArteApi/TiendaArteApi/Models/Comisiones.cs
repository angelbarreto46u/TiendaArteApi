using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaArteApi.Models
{
    public class Comisiones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
