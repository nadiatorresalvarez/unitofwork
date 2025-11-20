namespace Lab4_NadiaTorres.Models.DTOS;

public class ProductoDTO
{
    public string Nombre { get; set; } = null!;
    public string Descripcion { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }
}