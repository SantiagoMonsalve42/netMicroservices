using Bussines.inventoryBussines.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace inventoryService.Controllers
{
    public class CategoriaController : BaseController
    {
        private ICategoriaBussines _bussines;
        public CategoriaController(ICategoriaBussines bussines)
        {
            _bussines = bussines;
        }
        [HttpGet]
        public async Task<ObjectResult> getAsync()
        {
            return await GetReponseAnswer(await _bussines.GetAsync());
        }
    }
}
