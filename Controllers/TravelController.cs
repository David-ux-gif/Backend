using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Data;
using Backend.Models;


namespace Backend.Controllers
{ 
    [Route("Backend/travel")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TravelController(ApplicationDbContext context) {
            _context = context;
        }

        [HttpGet]

        public IActionResult GetAll(){
            var travels = _context.Travel.ToList();
            return Ok(travels);
        }

        [HttpGet("{id}")]

        public IActionResult GetById ([FromRoute] int id){
            var travel = _context.Travel.Find(id);

            if (travel == null){
                return NotFound();
            }
            return Ok(travel);
        }
        
        [HttpPost]
        public IActionResult CreateTravel ([FromBody] Travel travel){

            if (travel == null)
            {
                return NotFound();
            }

            _context.Travel.Add(travel);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit ([FromBody] Travel travel, int id){

            var updateData = _context.Travel.Find(id);
            if (updateData == null){
                return NotFound();
            }

            updateData.Name = travel.Name;

            _context.Travel.Update(travel);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete ([FromBody] Travel travel, int id){
            var deleteTravel = _context.Travel.Find(id);
            if(deleteTravel == null){
                return NotFound();
            }

            _context.Travel.Remove(travel);
            _context.SaveChanges();

            return Ok();
        }
        
    }
}