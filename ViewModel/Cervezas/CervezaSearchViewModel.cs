using Microsoft.AspNetCore.Mvc.Rendering;

namespace BirrasBares.ViewModel
{
    public class CervezaSearchViewModel
    {
        public string MarcaNombre { get; set; }
        public string Estilo { get; set; }
        public decimal? GraduacionMin { get; set; }
        public decimal? GraduacionMax { get; set; }
        public int? IBUMin { get; set; }
        public int? IBUMax { get; set; }
        public bool? EsArtesanal { get; set; }
        public List<CervezaListViewModel> Cervezas { get; set; }
        public SelectList Marcas { get; set; }
        public SelectList Estilos { get; set; }
    }
}
