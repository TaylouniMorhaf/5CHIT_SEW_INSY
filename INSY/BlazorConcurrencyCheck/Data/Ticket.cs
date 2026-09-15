using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorConcurrencyCheck.Data;

[Table("tickets")]
public class Ticket
{
    [Key]
    public int Id { get; set; }

    [ConcurrencyCheck]
    [Column("available")]
    public int Available { get; set; }
}
