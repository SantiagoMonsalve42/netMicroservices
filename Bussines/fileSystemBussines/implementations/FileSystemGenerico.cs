using Microsoft.AspNetCore.Http;
using Utilities.Models;

namespace Utilities
{
    public class FileSystemGenerico
    {
        public FileSystemGenerico()
        {
        }
        public FileSystemGenerico(string basePath)
        {
            this.basePath = basePath;
        }

        public string basePath { get; set; }

        public ICollection<FileItem> getAllItems()
        {
            List<FileItem> items = new List<FileItem>();
            string[] files = Directory.GetFiles(basePath);
            string[] directories = Directory.GetDirectories(basePath);
            foreach (string file in files)
            {
                items.Add(new(file, "file"));
            }
            foreach (string dir in directories)
            {
                items.Add(new(dir, "dir"));
            }
            return items;
        }
        public string subirArchivo(IFormFile archivo)
        {
            try
            {
                DateTime date = DateTime.Now;
                var nameFile = date.Year + date.Month + date.Day + date.Hour + date.Minute + date.Second + System.IO.Path.GetExtension(archivo.FileName);
                var fileSavePath = Path.Combine(this.basePath, nameFile);
                using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(basePath));
                    archivo.CopyToAsync(stream);
                    stream.Close();
                }
                
                
                return "";
            }catch (Exception ex)
            {
                return ex.Message;
            }
            
        }
        public byte[] descargarArchivo(string fileName)
        {
            byte[] fileBytes = null;
            try
            {
                fileBytes = System.IO.File.ReadAllBytes(Path.Combine(this.basePath, fileName));
            }
            catch (Exception ex)
            {
                
            }
            return fileBytes;
        }

    }
}
