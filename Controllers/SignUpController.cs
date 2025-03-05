using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.DTO.UserDTO;
using Backend.Models;
using Backend.DTO.CreateUserDto;

namespace Backend.Controllers
{

    [Route("api/user")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SignUpController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var userlist = await _context.User.ToListAsync();

            var users = userlist.Select( user => new UserDto {

                Id = user.Id,
                Username = user.UserName,
                Email= user.Email
               
                
                
            }).ToList();
            return Ok(users);
    }

    [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id) 
        {
             var user = await _context.User.Where(u => u.Id == id)
             .Select(user => new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email= user.Email
                   
                })
                .FirstOrDefaultAsync();

             if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto) 
        {   
            var olduser = await _context.User.ToListAsync();

            foreach (var user in olduser){

                if (user.UserName == userDto.UserName ) {

                    return BadRequest();
                }
            }

            var newUser = new User
            {
                UserName = userDto.UserName,
                Email= userDto.Email,
                Password =userDto.Password
            };

            try
            {
                await _context.User.AddAsync(newUser);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, userDto);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto userDto)
        {

           var registeredUser = await _context.User.FindAsync(id);
            if (registeredUser  == null)
            {
                return NotFound();
            }

                registeredUser.UserName = userDto.Username;
                registeredUser.Email= userDto.Email;
                registeredUser.Password =userDto.Password;

            _context.Entry(registeredUser ).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.User.Any(u => u.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
            }
            }
            catch (Exception ex)
            {
              
                return StatusCode(500, ex);
            }

            return StatusCode(200," User updated " );
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id) 
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, ex);
            }

            return NoContent();
        }

}
}