namespace Lab4_NadiaTorres.Models.DTOS;

public class DetallesordenDTO
{
    public int? Ordenid { get; set; }

    public int? Productoid { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }
}