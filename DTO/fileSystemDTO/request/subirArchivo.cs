using Microsoft.AspNetCore.Http;

namespace DTO.fileSystemDTO.request
{
    public class subirArchivoDTO
    {
        public string? ruta { get; set; }
        public IFormFile archivo { get; set; }
    }
}
