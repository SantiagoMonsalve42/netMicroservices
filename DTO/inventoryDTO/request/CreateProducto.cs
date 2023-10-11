namespace DTO.inventoryDTO.request
{
    public class CreateProducto
    {
        public long? IdProducto { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public long Cantidad { get; set; }
        public long? IdCategoriaProducto { get; set; }
    }
}
