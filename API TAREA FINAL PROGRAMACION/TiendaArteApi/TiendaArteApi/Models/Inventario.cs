using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiendaArteApi.Models
{
    public class Inventario
    {
        /*MODELO DE INVENTARIO
         *Se declaran los atributos principales que compondran la informacion de las tablas de INVENTARIO*/
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public string? ProductCode { get; set; }
        [Required]
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        [Required]
        public int ProductUnit { get; set; }
        [Required]
        public double ProductPrice { get; set; }
    }
}
