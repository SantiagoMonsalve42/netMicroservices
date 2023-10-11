using Data.Models.Identity;
using DTO.identityDTO.request;

namespace Data.interfaces.Identity
{
    public interface IUsuarioData
    {
        Task<TblUsuario> GetUsuarioAsync(int id);
        Task<TblUsuario> CreateAsync(RegistroRequestDTO user);
        Task<TblUsuario> UpdateAsync(TblUsuario user);
        Task<TblUsuario> GetUsuarioAsync(string email);

    }
}
