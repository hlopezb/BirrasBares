namespace BirrasBares.Models
{
    public class BarClasificacion
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int BarId { get; set; }
        public int Puntuacion { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Bar Bar { get; set; }
    }

    public class CervezaClasificacion
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CervezaId { get; set; }
        public int Puntuacion { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Cerveza Cerveza { get; set; }
    }
}