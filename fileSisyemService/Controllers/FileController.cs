using Contabilidad_api.Controllers;
using DTO.fileSystemDTO.request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Utilities;

namespace fileSisyemService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : BaseController
    {
        public FileSystemGenerico file;
        private readonly IConfiguration _configuration;
        private string urlBase;
        public FileController(IConfiguration configuratio)
        {
            file = new FileSystemGenerico();
            _configuration = configuratio;
            urlBase=_configuration.GetValue<string>("RutaDisco");
        }
        [HttpGet("GetElements")]
        public Task<ObjectResult> getElements(string? rutaRelativa )
        {
            file.basePath=Path.Combine(urlBase, rutaRelativa??"");
            var elementos=this.file.getAllItems();
            return base.GetReponseAnswer(elementos);
        }
        
        [HttpPost("UploadElement")]
        public Task<ObjectResult> subir([FromForm] subirArchivoDTO request)
        {

            if (request.ruta == null)
            {
                file.basePath = Path.Combine(urlBase);
            }
            else
            {
                file.basePath = Path.Combine(urlBase, request.ruta ?? "");
            }
            string resultado=file.subirArchivo(request.archivo);
           
            var elementos = this.file.getAllItems();
            return base.GetReponseAnswer(resultado==""?elementos:resultado);
        }

        [HttpGet("Download")]
        public IActionResult descargar(string rutaRelativa,string fileName)
        {
            file.basePath = Path.Combine(urlBase, rutaRelativa ?? "");
            var filebits=file.descargarArchivo(fileName);
            return File(filebits, "application/x-msdownload", fileName);
        }
    }
}
