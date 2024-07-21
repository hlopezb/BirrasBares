using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirrasBares.Models;

public class Cerveza
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nombre { get; set; }

    [Required]
    [StringLength(50)]
    public string Marca { get; set; }

    [Required]
    [StringLength(50)]
    public string Estilo { get; set; }

    [Required]
    [Range(0, 100)]
    public decimal Graduacion { get; set; }

    [Range(0, 100)]
    public int IBU { get; set; }

    [StringLength(500)]
    public string Descripcion { get; set; }

    [StringLength(50)]
    public string PaisOrigen { get; set; }

    public int? AñoLanzamiento { get; set; }

    [Range(0, 1000)]
    public int? Calorias { get; set; }

    [StringLength(50)]
    public string Color { get; set; }

    [StringLength(100)]
    public string Aroma { get; set; }

    [StringLength(100)]
    public string Sabor { get; set; }

    [StringLength(100)]
    public string Maridaje { get; set; }

    public bool EsArtesanal { get; set; }

    public bool DisponibleTodoElAño { get; set; }

    [StringLength(200)]
    public string ImagenUrl { get; set; }

    public ICollection<BarCerveza> BaresCervezas { get; set; }

    public virtual ICollection<CervezaClasificacion> Clasificaciones { get; set; }

    public Cerveza()
    {
        Clasificaciones = new HashSet<CervezaClasificacion>();
    }
}