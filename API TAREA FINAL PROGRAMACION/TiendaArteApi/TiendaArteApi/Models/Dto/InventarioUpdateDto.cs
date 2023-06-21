using System.ComponentModel.DataAnnotations;

namespace TiendaArteApi.Models.Dto
{
    public class InventarioUpdateDto
    {
        public string? ProductCode { get; set; }
        [MaxLength(20)]
        public string? ProductName { get; set; }

        public string? ProductDescription { get; set; }
        public int ProductUnit { get; set; }
        public double ProductPrice { get; set; }
    }
}
