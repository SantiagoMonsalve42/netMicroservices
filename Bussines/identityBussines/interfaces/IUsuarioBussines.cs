using Data.Models.Identity;
using DTO.identityDTO.request;
using DTO.identityDTO.response;

namespace Bussines.identityBussines.interfaces
{
    public interface IUsuarioBussines
    {
        Task<bool> crear(RegistroRequestDTO user);
        Task<LoginResponseDTO> login(LoginRequestDTO user);
        Task<LoginResponseDTO> tokenRefresh(LoginRequestDTO user);
    }
}
