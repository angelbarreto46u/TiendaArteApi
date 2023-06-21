using System.ComponentModel.DataAnnotations;

namespace TiendaArteApi.Models.Dto
{
    //DATA TRANSFER OBJECT
    //envoltura entre la entidad o modelo y la exposicion de la API
    //Se escriben los parametros especificos a mostrarse cuando consultemos los datos
    public class InventarioDto
    {
        [Required]
        public string? ProductCode { get; set; }

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
