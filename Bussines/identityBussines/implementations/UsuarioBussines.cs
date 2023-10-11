using Bussines.identityBussines.interfaces;
using Bussines.inventoryBussines.interfaces;
using Data.interfaces.Identity;
using Data.Models.Identity;
using DTO.identityDTO.request;
using DTO.identityDTO.response;
using Microsoft.Extensions.Configuration;
using System.Drawing;
using Utilidades;

namespace Bussines.identityBussines.implementations
{
    public class UsuarioBussines : IUsuarioBussines
    {
        private int id = 2;
        private IUsuarioData _data;
        private StringUtil stringUtil;
        private IAuditoriaBussines _auditoria;
        public UsuarioBussines(IUsuarioData data,IConfiguration _config, IAuditoriaBussines auditoria)
        {
            _data = data;
            stringUtil = new StringUtil(_config);
            _auditoria = auditoria;
        }

        public async Task<bool> crear(RegistroRequestDTO user)
        {
            user.Password = stringUtil.GetSHA256(user.Password);
            var usuarioPorEmail = await _data.GetUsuarioAsync(user.Email);
            if (usuarioPorEmail != null)
            {
                return false;
            }
            var data= await _data.CreateAsync(user);
            return data != null;
        }

        public async Task<LoginResponseDTO> login(LoginRequestDTO user)
        {

            LoginResponseDTO respuesta = new LoginResponseDTO();
            user.Pass = stringUtil.GetSHA256(user.Pass);
            var usuarioPorEmail = await _data.GetUsuarioAsync(user.Email);
            var objLog = await _auditoria.createRegistro(usuarioPorEmail.IdUsuario, "LOGIN APLICACION");
            if (usuarioPorEmail.Password ==  user.Pass
              && usuarioPorEmail.Email == user.Email)
            {
                string token = stringUtil.GenerateToken(user,usuarioPorEmail.IdUsuario);
                usuarioPorEmail.UltimoToken = token;
                usuarioPorEmail.UltimaSesion = DateTime.Now;
                await _data.UpdateAsync(usuarioPorEmail);
                respuesta.Status = true;
                respuesta.Token = token;
                objLog= await _auditoria.updateRegistro(objLog.IdLog, usuarioPorEmail.IdUsuario, "LOGIN EXITOSO",1);
            }
            else
            {
                respuesta.Status = false;
                respuesta.Token = null;
                objLog= await _auditoria.updateRegistro(objLog.IdLog, 0, "LOGIN FALLO", 2);
            }
            return respuesta;
        }

        public async Task<LoginResponseDTO> tokenRefresh(LoginRequestDTO user)
        {
            LoginResponseDTO respuesta = new LoginResponseDTO();
            var usuarioPorEmail = await _data.GetUsuarioAsync(user.Email);
            var objLog = await _auditoria.createRegistro(usuarioPorEmail.IdUsuario, "TOKEN REFRESH");
            if ( usuarioPorEmail.Email == user.Email
              && usuarioPorEmail.UltimoToken == user.Token)
            {
                string token = stringUtil.GenerateToken(user,usuarioPorEmail.IdUsuario);
                usuarioPorEmail.UltimoToken = token;
                usuarioPorEmail.UltimaSesion = DateTime.Now;
                await _data.UpdateAsync(usuarioPorEmail);
                respuesta.Status = true;
                respuesta.Token = token;
                objLog = await _auditoria.updateRegistro(objLog.IdLog, usuarioPorEmail.IdUsuario, "TOKEN REFRESH EXITOSO", 1);
            }
            else
            {
                respuesta.Status = false;
                respuesta.Token = null;
                objLog = await _auditoria.updateRegistro(objLog.IdLog, usuarioPorEmail.IdUsuario, "TOKEN REFRESH FALLO", 2,"error");
            }
            return respuesta;
        }
    }
}
