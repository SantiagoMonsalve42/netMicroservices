
using DTO.identityDTO.response;

namespace Data.interfaces.Identity
{
    public interface ITipoDocumentoData
    {
        Task<ICollection<TipoDocumentoResponse>> GetDocumentAsync();

    }
}
