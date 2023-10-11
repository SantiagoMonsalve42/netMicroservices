using DTO.inventoryDTO.response;

namespace Data.interfaces.Inventory
{
    public interface ICategoriaData
    {
        Task<ICollection<CategoriaResponse>> GetAsync();
    }
}
