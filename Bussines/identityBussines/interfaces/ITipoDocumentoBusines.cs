using Data.Models.Identity;
using DTO.identityDTO.response;

namespace Bussines.identityBussines.interfaces
{
    public interface ITipoDocumentoBusines
    {
        Task<ICollection<TipoDocumentoResponse>> GetDocumentAsync();
    }
}
