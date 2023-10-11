namespace DTO.identityDTO.request
{
    public class LoginRequestDTO
    {
        public string Email { get; set; }
        public string? Pass { get; set; }

        public string? Token { get; set; }
    }
}
