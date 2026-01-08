namespace Assignment_Api.Dtos
{
    public class UpdateUserDto
    {
        public string? CustName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public bool? IsBiometricEnabled { get; set; }
        public bool? IsPolicyAccepted { get; set; }
        public DateTime? PolicyAcceptedAt { get; set; }
    }
}
