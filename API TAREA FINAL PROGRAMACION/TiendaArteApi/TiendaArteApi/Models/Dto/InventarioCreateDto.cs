using System.ComponentModel.DataAnnotations;

namespace TiendaArteApi.Models.Dto
{
    public class InventarioCreateDto
    {
        [Required]
        [MaxLength(20)]
        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }

        [Required]
        public int ProductUnit { get; set; }

        [Required]
        public double ProductPrice { get; set; }
    }
}
