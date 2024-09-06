using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyInventoryApp.Models;
using MongoDB.Driver;

namespace MyInventoryApp.Controllers
{

   

    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly MongoDBContext _context;

        public InventoryController(MongoDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryModel>>> Get()
        {
            var items = await _context.InventoryItems.Find(_ => true).ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryModel>> Get(string id)
        {
            var item = await _context.InventoryItems.Find(i => i.Id == id).FirstOrDefaultAsync();
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create(InventoryModel item)
        {
            await _context.InventoryItems.InsertOneAsync(item);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, InventoryModel updatedItem)
        {
            var item = await _context.InventoryItems.ReplaceOneAsync(i => i.Id == id, updatedItem);
            if (item.MatchedCount == 0)
                return NotFound(new { Message = "Item not found." });

            return Ok(new { Message = "Item updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _context.InventoryItems.DeleteOneAsync(i => i.Id == id);
            if (result.DeletedCount == 0)
                return NotFound(new { Message = "Item not found." });

            return Ok(new { Message = $"Item deleted successfully. Id is {id}" });
        }
    }


}
