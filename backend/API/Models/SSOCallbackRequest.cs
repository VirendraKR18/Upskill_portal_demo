using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class SSOCallbackRequest
    {
        [Required]
        public string Code { get; set; } = string.Empty;

        public string? State { get; set; }

        public string? Nonce { get; set; }

        [Required]
        public string RedirectUri { get; set; } = string.Empty;
    }
}