namespace Assignment_Api.Models
{
    public class OtpRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Code { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public bool IsUsed { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        //navigation
        public Users User { get; set; } = null!;
    }
}
