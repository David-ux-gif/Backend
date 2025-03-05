using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class HotelInfo
    {
        [Key]
        public int Id {get; set;}

        public string Details {get; set;} = String.Empty;

        [ForeignKey("Hotel")]

        public int HotelId {get; set;}

        public Hotel hotel {get; set;}

        
    }
}