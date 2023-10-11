using Data.Models;
using Data.Models.Inventory;
using DTO.inventoryDTO.response;
using Microsoft.EntityFrameworkCore;

namespace Data.interfaces.Inventory
{
    public class CategoriaData : ICategoriaData
    {
        public readonly IRepository<TblCategoriaProducto> Repository;
        public CategoriaData(IRepository<TblCategoriaProducto> repository)
        {
            Repository = repository;
        }
        public async Task<ICollection<CategoriaResponse>> GetAsync()
        {
            List<CategoriaResponse> respuesta = new List<CategoriaResponse>();
            var result = await (from row in Repository.Entity select row).ToListAsync();
            foreach (var item in result)
            {
                respuesta.Add(new CategoriaResponse { IdCategoriaProducto = item.IdCategoriaProducto, CategoriaProductoDesc=item.CategoriaProductoDesc});
            }
            return respuesta;
        }
    }
}
