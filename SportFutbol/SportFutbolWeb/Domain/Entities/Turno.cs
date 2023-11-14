using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportFutbolWeb.Domain.Entities;

[Table("Turno")]
public class Turno
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }


    [Display(Name = "Descripción")]
    [StringLength(50)]
    public string? Descripcion { get; set; }

    [Display(Name = "Cancha")]
    public int? IdCancha { get; set; }
    [ForeignKey("IdCancha")]
    public virtual Cancha? Cancha { get; set; }

    [Display(Name = "FechaTurno")]
    [Column(TypeName = "smalldatetime")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
    public DateTime? FechaTurno { get; set; }

    [Display(Name = "NombreCliente")]
    [StringLength(50)]
    public string? NombreCliente { get; set; }
}
