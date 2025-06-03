using ExamApplication.Data;
using ExamApplication.Entity;
using ExamApplication.Migrations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitController : ControllerBase
    {

        private readonly AppDBContext _context;

        public FruitController (AppDBContext context)
        {
            _context = context;
        }


        [HttpGet("FetchFruits")]
        public async Task<ActionResult> GetFruits ()
        {

            var getFruits = await _context.FruitInventories.ToListAsync();
            if (getFruits == null || !getFruits.Any())
            {
                return NotFound("No fruits found in the inventory.");
            }
            return Ok(getFruits);

        }

        [HttpPost("AddFruit")]
        public async Task<ActionResult> AddFruits([FromBody] FruitInventoryDTO fruitInventory)
        {

            var addFruit = new FruitInventory
            {
                Name = fruitInventory.Name,
                Type = fruitInventory.Type,
                Price = fruitInventory.Price,
                Stock = fruitInventory.Stock
            };

            _context.FruitInventories.Add(addFruit);
             await _context.SaveChangesAsync();
    
            return Ok("Fruit added successfully.");



        }

        [HttpDelete("DeleteFruit/{id}")]
        public async Task <ActionResult> DeleteFruit([FromRoute] int id)
        {
            var deleteFruit = await _context.FruitInventories.FindAsync(id);
            if (deleteFruit == null)
            {
                return NotFound($"Fruit with ID {id} not found.");
            }
            await _context.SaveChangesAsync();
            return Ok("Fruit deleted successfully.");
        }

        [HttpPut("UpdateFruit/{id}")]

        public async Task <ActionResult> UpdateFruit([FromRoute] int id , [FromBody] FruitInventoryDTO fruitInventory)
        {

            var updateFruit = await _context.FruitInventories.FindAsync(id);
            if (updateFruit == null)
            {
                return NotFound($"Fruit with ID {id} not found.");
            }
            updateFruit.Name = fruitInventory.Name;
            updateFruit.Price = fruitInventory.Price;
            updateFruit.Type = fruitInventory.Type;
            updateFruit.Stock = fruitInventory.Stock;

             await _context.SaveChangesAsync();
             return Ok("Fruit updated successfully.");   


        }
      
    }
}
