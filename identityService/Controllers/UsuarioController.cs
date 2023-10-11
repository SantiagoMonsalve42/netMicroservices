
using Bussines.identityBussines.interfaces;
using Data.Models.Identity;
using DTO.identityDTO.request;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace identityService.Controllers
{
    public class UsuarioController: BaseController
    {
        public IUsuarioBussines _bussines;
        public UsuarioController(IUsuarioBussines bussines)
        {
            _bussines = bussines;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ObjectResult> Login(LoginRequestDTO request)
        {
            return await GetReponseAnswer(await _bussines.login(request));
        }
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ObjectResult> TokenRefresh(LoginRequestDTO request)
        {
            return await GetReponseAnswer(await _bussines.tokenRefresh(request));
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ObjectResult> Registro(RegistroRequestDTO request)
        {
            return await GetReponseAnswer(await _bussines.crear(request));
        }
    }
}
