using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SportFutbolWeb.Domain.Entities;

namespace SportFutbolWeb.ViewModels
{
    public class CanchaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor, ingresar la descripción.")]
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Por favor, ingresar el tipo de cancha.")]
        [Display(Name = "TipoCancha")]
        public int? TipoRefId { get; set; }
        [ForeignKey("TipoRefId")]
        public virtual TipoCancha? TipoCancha { get; set; }


        [Display(Name = "Imagen cancha")]
        public IFormFile Imagen { get; set; }

        [Display(Name = "Imagen")]
        public string? ImagenCancha { get; set; }
    }
}
