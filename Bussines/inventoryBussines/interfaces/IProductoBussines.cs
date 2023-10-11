using Data.Models.Inventory;
using DTO.inventoryDTO.request;

namespace Bussines.inventoryBussines.interfaces
{
    public interface IProductoBussines
    {
        Task<ICollection<CreateProducto>> GetAsync();
        Task<CreateProducto> GetAsync(int id);
        Task<TblProducto> CreateAsync(CreateProducto product);
        Task<TblProducto> UpdateAsync(CreateProducto product);
    }
}
