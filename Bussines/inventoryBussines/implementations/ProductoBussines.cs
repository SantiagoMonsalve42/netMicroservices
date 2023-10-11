using Bussines.inventoryBussines.interfaces;
using Data.interfaces.Inventory;
using Data.Models.Inventory;
using DTO.inventoryDTO.request;

namespace Bussines.inventoryBussines.implementations
{
    public class ProductoBussines : IProductoBussines
    {
        private IProductoData _data;
        private int id = 1;
        public ProductoBussines(IProductoData data)
        {
            this._data = data;
        }
        public async Task<TblProducto> CreateAsync(CreateProducto product)
        {
            return await _data.CreateAsync(product);

        }

        public async Task<ICollection<CreateProducto>> GetAsync()
        {
            return await (_data.GetAsync());
        }

        public async Task<CreateProducto> GetAsync(int id)
        {
            return await (_data.GetAsync(id));
        }

        public async Task<TblProducto> UpdateAsync(CreateProducto product)
        {
            return await (_data.UpdateAsync(product));
        }
    }
}
