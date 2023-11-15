using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportFutbolWeb.Domain.Entities;

[Table("Cancha")]
public class Cancha
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }


    [Display(Name = "Descripción")]
    [StringLength(50)]
    public string? Descripcion { get; set; }

    [Display(Name = "TipoCancha")]
    public int? TipoRefId { get; set; }
    [ForeignKey("TipoRefId")]
    public virtual TipoCancha? TipoCancha { get; set; }

    [Display(Name = "Imagen")]
    public string? ImagenCancha { get; set; }

}
