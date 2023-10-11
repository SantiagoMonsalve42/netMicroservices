using Bussines.inventoryBussines.interfaces;
using Data.interfaces.Inventory;
using DTO.inventoryDTO.response;

namespace Bussines.inventoryBussines.implementations
{
    public class CategoriaBussines : ICategoriaBussines
    {
        private ICategoriaData _data;
        public CategoriaBussines(ICategoriaData data)
        {
            _data = data;
        }
        public async Task<ICollection<CategoriaResponse>> GetAsync()
        {
            return await _data.GetAsync();
        }
    }
}
