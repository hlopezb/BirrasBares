using BirrasBares.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Evento
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nombre { get; set; }

    public DateTime Fecha { get; set; }

    [StringLength(500)]
    public string Descripcion { get; set; }

    public TimeSpan HoraInicio { get; set; }

    public TimeSpan HoraFin { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? Precio { get; set; }

    public int? Capacidad { get; set; }

    public int BarId { get; set; }

    [ForeignKey("BarId")]
    public Bar Bar { get; set; }
}