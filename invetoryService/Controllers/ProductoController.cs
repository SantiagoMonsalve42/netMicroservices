using Bussines.inventoryBussines.interfaces;
using DTO.inventoryDTO.request;
using Microsoft.AspNetCore.Mvc;

namespace inventoryService.Controllers
{
    public class ProductoController: BaseController
    {
        private IProductoBussines _bussines;
        public ProductoController(IProductoBussines bussines) { 
            _bussines = bussines;
        }
        [HttpGet]
        public async Task<ObjectResult> Get() {
            return await GetReponseAnswer(await _bussines.GetAsync());
        }

        [HttpGet]
        public async Task<ObjectResult> GetPorId(int id)
        {
            return await GetReponseAnswer(await _bussines.GetAsync(id));
        }

        [HttpPost]
        public async Task<ObjectResult> Crear(CreateProducto request)
        {
            return await GetReponseAnswer(await _bussines.CreateAsync(request));
        }
        [HttpPost]
        public async Task<ObjectResult> Actualizar(CreateProducto request)
        {
            return await GetReponseAnswer(await _bussines.UpdateAsync(request));
        }
    }
}
