using System;
using System.Collections.Generic;

namespace Lab4_NadiaTorres.Models;

public partial class Producto
{
    public int Productoid { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public int? Categoriaid { get; set; }

    public virtual Categoria? Categoria { get; set; }

    public virtual ICollection<Detallesorden> Detallesordens { get; set; } = new List<Detallesorden>();
}
