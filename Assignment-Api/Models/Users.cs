using System.ComponentModel.DataAnnotations;

namespace Assignment_Api.Models
{
    public class Users
    {
        public int Id {  get; set; }
        public string CustName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string ICNumber { get; set; } = string.Empty;
        public string PhoneNumber {  get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsBiometricEnabled { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool IsPolicyAccepted { get; set; }
        public DateTime PolicyAcceptedAt { get; set; }
        public ICollection<OtpRequest> Otp {  get; set; } = new List<OtpRequest>();
    }
}
