using System;
using System.Collections.Generic;

namespace Data.Models.Inventory;

public partial class TblProducto
{
    public long IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public long Cantidad { get; set; }

    public long? IdCategoriaProducto { get; set; }

    public virtual TblCategoriaProducto? IdCategoriaProductoNavigation { get; set; }
}
