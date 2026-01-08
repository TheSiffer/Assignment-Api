using Microsoft.AspNetCore.SignalR;

namespace Assignment_Api.Interfaces
{
    public interface IOtpService
    {
        public Task<string?> GenerateOtp(string icNumber);
        public Task<bool> ValidateOtp(string code, string icNumber);
    }
}
