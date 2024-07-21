using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirrasBares.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override string Id { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        public string Apellido { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(256)]
        public override string Email { get; set; }

        [Required]
        [StringLength(256)]
        public override string UserName { get; set; }

        public virtual ICollection<BarClasificacion> BaresClasificados { get; set; }
        public virtual ICollection<CervezaClasificacion> CervezasClasificadas { get; set; }

        public ApplicationUser()
        {
            BaresClasificados = new HashSet<BarClasificacion>();
            CervezasClasificadas = new HashSet<CervezaClasificacion>();
        }
    }
}