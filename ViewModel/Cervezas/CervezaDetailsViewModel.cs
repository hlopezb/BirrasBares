namespace BirrasBares.ViewModel
{
    public class CervezaDetailsViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string MarcaNombre { get; set; }
        public string Estilo { get; set; }
        public decimal Graduacion { get; set; }
        public int IBU { get; set; }
        public string Descripcion { get; set; }
        public string Color { get; set; }
        public string Aroma { get; set; }
        public string Sabor { get; set; }
        public string Maridaje { get; set; }
        public bool EsArtesanal { get; set; }
        public bool DisponibleTodoElAño { get; set; }
        public string ImagenUrl { get; set; }
    }
}
