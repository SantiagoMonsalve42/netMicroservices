using Bussines.identityBussines.interfaces;
using Bussines.inventoryBussines.interfaces;
using Data.interfaces.Identity;
using Data.Models.Identity;
using DTO.identityDTO.response;

namespace Bussines.identityBussines.implementations
{
    public class TipoDocumentoBussines : ITipoDocumentoBusines
    {
        public ITipoDocumentoData _data;
        public IAuditoriaBussines _auditoria;
        public TipoDocumentoBussines(ITipoDocumentoData data, IAuditoriaBussines auditoria)
        {
            _data = data;
            _auditoria = auditoria;
        }

        public async Task<ICollection<TipoDocumentoResponse>> GetDocumentAsync()
        {
            var objLog = await _auditoria.createRegistro(0, "CONSULTA TIPOS DOCUMENTO");
            return await _data.GetDocumentAsync();
        }
    }
}
