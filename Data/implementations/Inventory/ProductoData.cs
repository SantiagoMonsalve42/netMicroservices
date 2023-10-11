using Data.Models;
using Data.Models.Inventory;
using DTO.inventoryDTO.request;
using Microsoft.EntityFrameworkCore;

namespace Data.interfaces.Inventory
{
    public class ProductoData : IProductoData
    {
        public readonly IRepository<TblProducto> Repository;
        public ProductoData(IRepository<TblProducto> repository)
        {
            Repository = repository;
        }

        public async Task<TblProducto> CreateAsync(CreateProducto product)
        {
            return await Repository.CreateAsync(new TblProducto
            {
                Cantidad = product.Cantidad,
                Descripcion = product.Descripcion,
                IdCategoriaProducto = product.IdCategoriaProducto,
                Nombre = product.Nombre,
            });
        }

        public async Task<ICollection<CreateProducto>> GetAsync()
        {
            List<CreateProducto> resultado = new List<CreateProducto>();
            var resultadoBd = await (from row in Repository.Entity select row).ToListAsync();
            resultadoBd.ForEach(x =>
            {
                resultado.Add(new CreateProducto
                {
                    Cantidad = x.Cantidad,
                    Descripcion=x.Descripcion,
                    IdCategoriaProducto=x.IdCategoriaProducto,
                    IdProducto=x.IdProducto,
                    Nombre = x.Nombre
                }); 
            });
            return resultado;
        }

        public async Task<CreateProducto> GetAsync(int id)
        {
            var resultadoBd = await(from row in 
                                        Repository.Entity 
                                        select row)
                                    .Where(x=> x.IdProducto == id)
                                    .FirstOrDefaultAsync();
            if(resultadoBd == null)
            {
                return null;
            }
            else
            {
                return new CreateProducto
                {
                    Nombre = resultadoBd.Nombre,
                    IdProducto = resultadoBd.IdProducto,
                    Cantidad = resultadoBd.Cantidad,
                    Descripcion = resultadoBd.Descripcion,
                    IdCategoriaProducto = resultadoBd.IdCategoriaProducto
                };
            }
        }

        public async Task<TblProducto> UpdateAsync(CreateProducto product)
        {
            var resultadoBd = await (from row in
                                        Repository.Entity
                                    select row)
                                    .Where(x => x.IdProducto == product.IdProducto)
                                    .FirstOrDefaultAsync();
            if(resultadoBd == null)
            {
                throw new Exception("No existe el producto");
            }
            else
            {
                resultadoBd.Descripcion = product.Descripcion;
                resultadoBd.Nombre = product.Nombre;
                resultadoBd.Cantidad = product.Cantidad;
                return await Repository.Put(resultadoBd);
            }
        }
    }
}
