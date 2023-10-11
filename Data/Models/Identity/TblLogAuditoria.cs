using System;
using System.Collections.Generic;

namespace Data.Models.Identity;

public partial class TblLogAuditoria
{
    public long IdLog { get; set; }

    public long IdUsuario { get; set; }

    public DateTime FechaInicioOperacion { get; set; }

    public DateTime FechaFinOperacion { get; set; }

    public string Descripcion { get; set; } = null!;

    public long IdEstadoTransaccion { get; set; }

    public string? MensajeError { get; set; }

    public virtual TblEstadoTransaccion IdEstadoTransaccionNavigation { get; set; } = null!;

    
}
