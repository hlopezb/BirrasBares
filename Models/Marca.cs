using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirrasBares.Models
{
    public class Marca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        [StringLength(200)]
        public string PaisOrigen { get; set; }

        [StringLength(200)]
        public string SitioWeb { get; set; }

        public virtual ICollection<Cerveza> Cervezas { get; set; }
    }
}