using Assignment_Api.Data;
using Assignment_Api.Dtos;
using Assignment_Api.Interfaces;
using Assignment_Api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Api.Controllers
{
    [ApiController]
    [Route("api/assignment")]
    public class AssignmentController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IOtpService _otpService;
        public AssignmentController(IUserService userService, IOtpService otpService)
        {
            _service = userService;
            _otpService = otpService;
        }
        /// <summary>
        /// Gets all users.
        /// Only for testing.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _service.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByICNumber([FromRoute] string id)
        {
            var user = await _service.GetByICNumber(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);

        }

        [HttpPost("user")]
        public async Task<IActionResult> Create([FromBody]CreateUserDto userDto)
        {
            var user = await _service.CreateUser(userDto);
            if (user == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(GetByICNumber),new {id = user.ICNumber}, user.ToUserDto());
        }

        [HttpPost("generate")]
        public async Task<IActionResult> CreateOtp(string ICnumber)
        {
            var code = await _otpService.GenerateOtp(ICnumber);
            if (code != null)
            {
                return Ok(code);
            }
            return BadRequest();
        }

        [HttpPost("validate")]
        public async Task<IActionResult> ValidateOtp(ValidateOtpDto otpDto)
        {
            if(await _otpService.ValidateOtp(otpDto.Code, otpDto.ICNumber))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPatch("{icNumber}/pin")]
        public async Task<IActionResult> UpdatePin(string icNumber, string Pin)
        {
            var result = await _service.UpdateUserPin(icNumber, Pin);
            if (!result)
                return NotFound();

            return NoContent();
        }
        [HttpPatch("{icNumber}")]
        public async Task<IActionResult> UpdateUser(string icNumber, [FromBody] UpdateUserDto updateUser)
        {
            var updatedUser = await _service.UpdateUser(icNumber, updateUser);
            if (updatedUser == null)
                return NotFound();

            return Ok(updatedUser);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]string id)
        {
            var user = await _service.DeleteUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
