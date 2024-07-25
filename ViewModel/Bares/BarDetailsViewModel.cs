namespace BirrasBares.ViewModel
{
    public class BarDetailsViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string TipoBar { get; set; }
        public string Descripcion { get; set; }
        public int Capacidad { get; set; }
        public int AñoApertura { get; set; }
        public bool TieneTerraza { get; set; }
        public bool PermiteReservas { get; set; }
        public string ServiciosAdicionales { get; set; }
        public string Ambiente { get; set; }
        public string RangoPrecios { get; set; }
        public decimal CalificacionPromedio { get; set; }
        public string ImagenUrl { get; set; }
        public List<HorarioViewModel> Horarios { get; set; }
        public List<CervezaEnBarViewModel> Cervezas { get; set; }
        public List<PlatoMenuViewModel> PlatosMenu { get; set; }
    }
}
