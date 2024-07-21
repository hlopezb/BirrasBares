using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirrasBares.Models;

public class HorarioBar
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int BarId { get; set; }
    public Bar Bar { get; set; }

    [Required]
    [Range(1, 7)]
    public int DiaSemana { get; set; } //  1 = Lunes, ..., 6 = Sábado

    public TimeSpan HoraApertura { get; set; }
    public TimeSpan HoraCierre { get; set; }

    public DateTime? FechaInicio { get; set; } // Para horarios estacionales
    public DateTime? FechaFin { get; set; } // Para horarios estacionales

    [StringLength(100)]
    public string Descripcion { get; set; } // Por ejemplo, "Horario de verano", "Horario de invierno", etc.
}