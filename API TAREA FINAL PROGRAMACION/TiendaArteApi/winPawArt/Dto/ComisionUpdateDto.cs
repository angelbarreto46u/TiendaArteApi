using System.ComponentModel.DataAnnotations;

namespace TiendaArteApi.Models.Dto
{
    public class ComisionUpdateDto
    {
        public int ComisionCode { get; set; }
        public string? ClienteName { get; set; }
        public string? Descripcion { get; set; }
        public string? Direccion { get; set; }
        public DateTime FechaEntrega { get; set; }
    }
}
