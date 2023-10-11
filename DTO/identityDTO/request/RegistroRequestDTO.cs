namespace DTO.identityDTO.request
{
    public class RegistroRequestDTO
    {
        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public long IdTipoDocumento { get; set; }
    }
}
