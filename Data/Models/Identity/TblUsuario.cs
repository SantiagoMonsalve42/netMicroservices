using System;
using System.Collections.Generic;

namespace Data.Models.Identity;

public partial class TblUsuario
{
    public long IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
    public string NumeroDocumento { get; set; } = null!;

    public long IdTipoDocumento { get; set; }
    public DateTime? UltimaSesion { get; set; }
    public string? UltimoToken { get; set; }
    public virtual TblTipoDocumento IdTipoDocumentoNavigation { get; set; } = null!;
}
