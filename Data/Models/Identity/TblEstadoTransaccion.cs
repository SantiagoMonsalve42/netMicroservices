using System;
using System.Collections.Generic;

namespace Data.Models.Identity;

public partial class TblEstadoTransaccion
{
    public long IdEstadoTransaccion { get; set; }

    public string EstadoTransaccionId { get; set; } = null!;
}
