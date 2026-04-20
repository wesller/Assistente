using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brain.Core.Entities;

public class Item
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(255)]
    public string Titulo { get; set; } = string.Empty;

    [Column(TypeName = "text")]
    public string Descricao { get; set; } = string.Empty;
}
