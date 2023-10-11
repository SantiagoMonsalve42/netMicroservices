using Bussines.identityBussines.interfaces;
using Bussines.inventoryBussines.interfaces;
using Data.interfaces.Identity;
using Data.Models.Identity;

namespace Bussines.identityBussines.implementations
{
    public class AuditoriaBussines : IAuditoriaBussines
    {
        private IAuditoriaData _data;
        public AuditoriaBussines(IAuditoriaData data)
        {
            _data = data;
        }

        public async Task<TblLogAuditoria> createRegistro(long IdUsuario, string Descripcion)
        {
            var idLog = new TblLogAuditoria
            {
                Descripcion = Descripcion,
                FechaFinOperacion = DateTime.Now,
                FechaInicioOperacion = DateTime.Now,
                IdEstadoTransaccion = 1,
                IdUsuario = IdUsuario,
                MensajeError = ""
            };
            return await _data.CreateAsync(idLog);

        }

        public async Task<TblLogAuditoria> updateRegistro(long idLog, long IdUsuario, string Descripcion, int estadoError = 0,string mensajeError = null)
        {
            var idLogExiste = new TblLogAuditoria
            {
                Descripcion = Descripcion,
                FechaFinOperacion = DateTime.Now,
                FechaInicioOperacion = DateTime.Now,
                IdEstadoTransaccion = estadoError,
                IdUsuario = IdUsuario,
                MensajeError = mensajeError,
                IdLog = idLog
            };
            return await _data.UpdateAsync(idLogExiste);
        }
    }
}
