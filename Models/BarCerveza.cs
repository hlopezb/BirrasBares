namespace BirrasBares.Models;

public class BarCerveza
{
    public int BarId { get; set; }
    public Bar Bar { get; set; }

    public int CervezaId { get; set; }
    public Cerveza Cerveza { get; set; }

    public decimal Precio { get; set; }
}