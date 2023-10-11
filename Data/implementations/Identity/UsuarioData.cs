using Azure.Core;
using Data.Models;
using Data.Models.Identity;
using DTO.identityDTO.request;
using Microsoft.EntityFrameworkCore;

namespace Data.interfaces.Identity
{
    public class UsuarioData: IUsuarioData
    {
        public readonly IRepository<TblUsuario> Repository;
        public UsuarioData(IRepository<TblUsuario> repository)
        {
            Repository = repository;
        }

        public async Task<TblUsuario> CreateAsync(RegistroRequestDTO user)
        {
            
            return await Repository.CreateAsync
                        (new TblUsuario 
                            { Nombre = user.Nombre,
                              Email = user.Email,
                              IdTipoDocumento = user.IdTipoDocumento,
                              Password = user.Password,
                              Apellido = user.Apellido,
                        });
        }

        public async Task<TblUsuario> GetUsuarioAsync(int id)
        {
            var result = await (from row in Repository.Entity where row.IdUsuario == id select row).FirstOrDefaultAsync();
            return result;
        }

        public async Task<TblUsuario> GetUsuarioAsync(string email)
        {
            var result = await (from row in Repository.Entity where row.Email == email select row).FirstOrDefaultAsync();
            return result;
        }

        public async Task<TblUsuario> UpdateAsync(TblUsuario user)
        {
            return await Repository.Put(user); 
        }
    }
}
