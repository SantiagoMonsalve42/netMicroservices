using Data.Models.Inventory;
using DTO.inventoryDTO.request;

namespace Data.interfaces.Inventory
{
    public interface IProductoData
    {
        Task<ICollection<CreateProducto>> GetAsync();
        Task<CreateProducto> GetAsync(int id);
        Task<TblProducto> CreateAsync(CreateProducto product);
        Task<TblProducto> UpdateAsync(CreateProducto product);
    }
}
