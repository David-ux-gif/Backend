using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Review
    {
        [Key]
        public int Id {get; set;}

        public int Rating {get; set;}

        public string ReviewTest {get; set;} = String.Empty;

        public DateTime CreatedOn {get; set;} = DateTime.UtcNow;

        public int? HotelId {get; set;}
        
        public int? HotelRating {get; set;}
    }
}