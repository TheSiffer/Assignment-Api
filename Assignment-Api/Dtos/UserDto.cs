using System.ComponentModel.DataAnnotations;

namespace Assignment_Api.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string CustName { get; set; } = string.Empty;
        public string ICNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsBiometricEnabled { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool IsPolicyAccepted { get; set; }
        public DateTime? PolicyAcceptedAt { get; set; }
    }
}
