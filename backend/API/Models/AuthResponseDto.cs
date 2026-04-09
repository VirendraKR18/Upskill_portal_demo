namespace API.Models
{
    public class AuthResponseDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public int ExpiresInMinutes { get; set; }
        public string Role { get; set; } = string.Empty;
        public string RedirectUrl { get; set; } = "/individual/dashboard";
    }
}