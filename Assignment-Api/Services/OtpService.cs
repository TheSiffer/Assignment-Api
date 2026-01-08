using Assignment_Api.Data;
using Assignment_Api.Interfaces;
using Assignment_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Api.Services
{
    /// <summary>
    /// Placeholder/proof of concept class for otp.
    /// </summary>
    public class OtpService : IOtpService
    {
        private readonly ApplicationDbContext _context;
        private static readonly Random _random = new();
        public OtpService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string?> GenerateOtp(string icNumber)
        {
            string code = _random.Next(1000, 10000).ToString();
            var user = await _context.Users.FirstOrDefaultAsync(x => x.ICNumber ==  icNumber);
            if (user != null)
            {
                var otp = new OtpRequest
                {
                    ICnumber = user.ICNumber,
                    UserId = user.Id,
                    Code = code,
                    CreatedAt = DateTime.UtcNow,
                    ExpiresAt = DateTime.UtcNow.AddMinutes(1),
                    IsUsed = false
                };
                await _context.OtpRequests.AddAsync(otp);
                await _context.SaveChangesAsync();
                return code;
            }
            return null;
        }

        public async Task<bool> ValidateOtp(string code, string icNumber)
        {
            var otp = await _context.OtpRequests.Where(x => x.ICnumber == icNumber && !x.IsUsed)
                .OrderByDescending(x=> x.CreatedAt)
                .FirstOrDefaultAsync();
            if (otp == null)
                return false;

            if (otp.ExpiresAt >= DateTime.UtcNow)
            {
                if (string.Equals(otp.Code, code))
                {
                    otp.IsUsed = true;
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }
    }
}
