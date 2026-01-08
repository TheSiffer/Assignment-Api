using Assignment_Api.Dtos;
using Assignment_Api.Models;

namespace Assignment_Api.Interfaces
{
    public interface IUserService
    {
        public Task<List<Users>> GetAllAsync();
        public Task<Users?> GetByICNumber(string id);
        public Task<Users?> CreateUser(CreateUserDto userDto);
        public Task<Users?> UpdateUser(string ICNumber, UpdateUserDto userDto);
        public Task<bool> UpdateUserPin(string ICnumber, string Pin);
        public Task<Users?> DeleteUser(string id);
        public Task<bool> UserExists(string id);
    }
}
