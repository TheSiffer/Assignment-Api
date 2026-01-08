namespace Assignment_Api.Dtos
{
    public class CreateUserDto
    {
        //Registration - New Customer
        public string CustName { get; set; } = string.Empty;
        public string ICNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
