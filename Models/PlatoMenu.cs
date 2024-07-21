using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirrasBares.Models;

public class PlatoMenu
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nombre { get; set; }

    [StringLength(500)]
    public string Descripcion { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Precio { get; set; }

    [StringLength(50)]
    public string Categoria { get; set; } // Por ejemplo: Entrantes, Platos principales, Postres, etc.

    public bool Disponible { get; set; }

    [StringLength(200)]
    public string ImagenUrl { get; set; }

    public bool EsVegano { get; set; }
    public bool EsVegetariano { get; set; }
    public bool EsSinGluten { get; set; }

    [StringLength(500)]
    public string Alergenos { get; set; } // Por ejemplo: "Contiene: lácteos, frutos secos, huevo"

    [StringLength(200)]
    public string Ingredientes { get; set; }

    [Range(0, 5000)]
    public int? Calorias { get; set; }

    [StringLength(50)]
    public string TamañoPorcion { get; set; } // Por ejemplo: "Grande", "Mediano", "Individual"

    public bool EsEspecialidad { get; set; }

    [StringLength(100)]
    public string Temporada { get; set; } // Por ejemplo: "Todo el año", "Verano", "Navidad"

    public int Popularidad { get; set; } // Podría ser un número del 1 al 5

    [StringLength(200)]
    public string Preparacion { get; set; } // Por ejemplo: "A la parrilla", "Frito", "Al horno"

    public int BarId { get; set; }
    public Bar Bar { get; set; }
}