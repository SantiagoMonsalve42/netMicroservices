using System;
using System.Collections.Generic;

namespace Data.Models.Identity;

public partial class TblTipoDocumento
{
    public long IdTipoDocumento { get; set; }

    public string TipoDocumento { get; set; } = null!;

    public virtual ICollection<TblUsuario> TblUsuarios { get; set; } = new List<TblUsuario>();
}
