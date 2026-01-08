using Assignment_Api.Data;
using Assignment_Api.Dtos;
using Assignment_Api.Interfaces;
using Assignment_Api.Mappers;
using Assignment_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Api.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Users?> CreateUser(CreateUserDto userDto)
        {
            var existing = await _context.Users.FirstOrDefaultAsync(x => x.ICNumber == userDto.ICNumber);
            if (existing != null)
                return existing;

            var user = userDto.ToUserFromCreateDto();
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Users?> DeleteUser(string id)
        {
            var user = await GetByICNumber(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
            
        }

        public async Task<List<Users>> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<Users?> GetByICNumber(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.ICNumber == id);
        }

        public async Task<Users?> UpdateUser(string ICNumber, UpdateUserDto userDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.ICNumber == ICNumber);
            if(existingUser == null)
            {
                return null;
            }

            if (userDto.CustName != null) existingUser.CustName = userDto.CustName;
            if (userDto.PhoneNumber != null) existingUser.PhoneNumber = userDto.PhoneNumber;
            if (userDto.Email != null) existingUser.Email = userDto.Email;
            if (userDto.IsBiometricEnabled.HasValue) existingUser.IsBiometricEnabled = userDto.IsBiometricEnabled.Value;
            if (userDto.IsPolicyAccepted.HasValue) existingUser.IsPolicyAccepted =  userDto.IsPolicyAccepted.Value;
            if (userDto.PolicyAcceptedAt.HasValue) existingUser.PolicyAcceptedAt = userDto.PolicyAcceptedAt; 

            await _context.SaveChangesAsync();
            return existingUser;
        }
        public async Task<bool> UpdateUserPin(string ICnumber, string Pin)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.ICNumber == ICnumber);
            if (user == null)
            {
                return false;
            }
            user.Pin = Pin;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UserExists(string id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(s => s.ICNumber ==  id);
            if(user != null)
            {
                return true;
            }
            return false;
        }
    }
}
