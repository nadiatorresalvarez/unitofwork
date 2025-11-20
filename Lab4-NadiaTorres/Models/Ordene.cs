using System;
using System.Collections.Generic;

namespace Lab4_NadiaTorres.Models;

public partial class Ordene
{
    public int Ordenid { get; set; }

    public int? Clienteid { get; set; }

    public DateTime? Fechaorden { get; set; }

    public decimal Total { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<Detallesorden> Detallesordens { get; set; } = new List<Detallesorden>();

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
