using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SportFutbolWeb.Domain.Entities;

[Table("Tarifa")]
public class Tarifa
{

    [Key]
    [Column("Id")]
    public int Id { get; set; }


    [Display(Name = "Precio")]
    [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Precio { get; set; }
}
