using DTO.inventoryDTO.response;

namespace Bussines.inventoryBussines.interfaces
{
    public interface ICategoriaBussines
    {
        Task<ICollection<CategoriaResponse>> GetAsync();
    }
}
