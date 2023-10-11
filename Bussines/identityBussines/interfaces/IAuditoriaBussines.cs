using Data.Models.Identity;

namespace Bussines.inventoryBussines.interfaces
{
    public interface IAuditoriaBussines
    {
        public Task<TblLogAuditoria> createRegistro(long IdUsuario,string Descripcion);

        public Task<TblLogAuditoria> updateRegistro(long idLog,long IdUsuario, string Descripcion, int estadoError,string mensajeError = null);
    }
}
