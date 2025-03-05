using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    [Table("User")]
    public class User
    {
        [Key]

        public int Id { get; set; }
        
        public string UserName { get; set; } = String.Empty;

        public string Email { get; set; } = String.Empty;

        public string Password { get; set; } = String.Empty;
        
        public List<HotelBooking> HotelBooking {get; set;} =new List<HotelBooking>();
    }
}