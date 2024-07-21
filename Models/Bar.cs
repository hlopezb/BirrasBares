using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirrasBares.Models;

public class Bar
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nombre { get; set; }

    [Required]
    [StringLength(200)]
    public string Direccion { get; set; }

    [StringLength(20)]
    public string Telefono { get; set; }

    [StringLength(100)]
    [EmailAddress]
    public string Email { get; set; }

    [StringLength(200)]
    public string SitioWeb { get; set; }

    [StringLength(500)]
    public string Descripcion { get; set; }

    public int Capacidad { get; set; }

    public int AñoApertura { get; set; }

    [StringLength(100)]
    public string TipoBar { get; set; } // Ej: Pub, Cervecería artesanal, Sports Bar, etc.

    public bool TieneTerraza { get; set; }

    public bool PermiteReservas { get; set; }

    [StringLength(200)]
    public string ServiciosAdicionales { get; set; } // Ej: "WiFi gratis, Dardos, Billar"

    [StringLength(100)]
    public string Ambiente { get; set; } // Ej: "Relajado", "Animado", "Elegante"

    [StringLength(200)]
    public string RangoPrecios { get; set; } // Ej: "€€" o "Económico"

    public decimal CalificacionPromedio { get; set; }

    [StringLength(200)]
    public string ImagenUrl { get; set; }

    [StringLength(200)]
    public string RedesSociales { get; set; } // Ej: "Facebook: /mibar, Instagram: @mibar"

    [StringLength(100)]
    public string Propietario { get; set; }

    public bool AccesibilidadDiscapacitados { get; set; }

    [StringLength(200)]
    public string Especialidades { get; set; } // Ej: "Cervezas belgas, Tapas gourmet"

    public ICollection<HorarioBar> Horarios { get; set; }

    public ICollection<BarCerveza> BaresCervezas { get; set; }

    public ICollection<Evento> Eventos { get; set; }

    public ICollection<PlatoMenu> PlatosMenu { get; set; }
    
    public virtual ICollection<BarClasificacion> Clasificaciones { get; set; }

    public Bar()
    {
        Clasificaciones = new HashSet<BarClasificacion>();
    }
}