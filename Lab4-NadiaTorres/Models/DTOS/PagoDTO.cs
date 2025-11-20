namespace Lab4_NadiaTorres.Models.DTOS;

public class PagoDTO
{
    public int? Ordenid { get; set; }

    public decimal Monto { get; set; }
    
    public string? Metodopago { get; set; }
}