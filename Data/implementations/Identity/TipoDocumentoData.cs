using Data.Models;
using Data.Models.Identity;
using DTO.identityDTO.response;
using Microsoft.EntityFrameworkCore;

namespace Data.interfaces.Identity
{
    public class TipoDocumentoData : ITipoDocumentoData { 
        public readonly IRepository<TblTipoDocumento> Repository;
        public TipoDocumentoData(IRepository<TblTipoDocumento> repository)
        {
            Repository = repository;
        }
        public async Task<ICollection<TipoDocumentoResponse>> GetDocumentAsync()
        {
            List<TipoDocumentoResponse> respuesta= new List<TipoDocumentoResponse>();
            var result = await(from row in Repository.Entity select row).ToListAsync();
            foreach(var item in result)
            {
                respuesta.Add(new TipoDocumentoResponse { IdTipoDocumento = item.IdTipoDocumento, TipoDocumento = item.TipoDocumento });
            }
            return respuesta;
        } 
    }
}
