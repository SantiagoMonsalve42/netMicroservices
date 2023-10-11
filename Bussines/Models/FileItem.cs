namespace Utilities.Models
{
    public class FileItem
    {
        public FileItem(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; set; }
        public string Type { get; set; }

    }
}
