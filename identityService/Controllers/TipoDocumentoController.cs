using Bussines.identityBussines.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace identityService.Controllers
{
    public class TipoDocumentoController: BaseController
    {
        private ITipoDocumentoBusines _bussines;
        public TipoDocumentoController(ITipoDocumentoBusines bussines) { 
            _bussines = bussines;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ObjectResult> getDocumentosAsync()
        {
            return await GetReponseAnswer(await _bussines.GetDocumentAsync());
        }

    }
}
