using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTO.UserDTO
{
    public class UserDto
    {
        public int Id { get; set; }
        
        public string Username { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;
    }
}