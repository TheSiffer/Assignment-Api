using Assignment_Api.Dtos;
using Assignment_Api.Models;

namespace Assignment_Api.Mappers
{
    /// <summary>
    /// Manual mapping used due to third party restrictions on assignment
    /// </summary>
    public static class UserMapper
    {
        /// <summary>
        /// Maps user model to UserDto
        /// </summary>
        /// <param name="user">User Model</param>
        /// <returns>UserDto</returns>
        public static UserDto ToUserDto(this Users user)
        {
            return new UserDto
            {
                Id = user.Id,
                CustName = user.CustName,
                ICNumber = user.ICNumber,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                IsBiometricEnabled = user.IsBiometricEnabled,
                CreatedDate = user.CreatedDate,
                IsPolicyAccepted = user.IsPolicyAccepted,
                PolicyAcceptedAt = user.PolicyAcceptedAt,
            };
        }
        /// <summary>
        /// Only for new users. Sets some fields as default
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        public static Users ToUserFromCreateDto(this CreateUserDto userDto)
        {
            return new Users
            {
                CustName = userDto.CustName,
                ICNumber = userDto.ICNumber,
                PhoneNumber = userDto.PhoneNumber,
                Email = userDto.Email,
                IsBiometricEnabled = false,
                CreatedDate = DateTime.UtcNow, //already utcnow
                IsPolicyAccepted = false,
            };
        }

    }
}
