using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models
{
    [Table("Hotel")]
    public class Hotel
    {
        [Key]

        public int Id  {get; set;}

        public string Name{get; set;} = String.Empty;

        public decimal Price{get; set;}

        public List<string> Image {get; set;} = new List<string>();

        public string Description {get; set;} = String.Empty;

        public int Rating {get; set;}

        public bool FreeCancellation {get; set;}

        public bool ReserveNow {get; set;}

        public HotelInfo hotelInfo {get; set;}

        public List <Review> Reviews {get; set;} = new List <Review> ();
        
        public List<HotelBooking> HotelBooking {get; set;} =new List<HotelBooking>();
    }
}