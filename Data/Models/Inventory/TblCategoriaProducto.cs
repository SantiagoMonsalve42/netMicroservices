using System;
using System.Collections.Generic;

namespace Data.Models.Inventory;

public partial class TblCategoriaProducto
{
    public long IdCategoriaProducto { get; set; }

    public string CategoriaProductoDesc { get; set; } = null!;

    public virtual ICollection<TblProducto> TblProductos { get; set; } = new List<TblProducto>();
}
