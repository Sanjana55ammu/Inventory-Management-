using InventoryManagementAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatabaseTestController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public DatabaseTestController(InventoryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> TestDatabase()
        {
            try
            {
                bool connected = await _context.Database.CanConnectAsync();

                if (connected)
                {
                    return Ok("Database connection successful!");
                }

                return StatusCode(500, "Database connection failed.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "Database connection failed.",
                    Error = ex.Message
                });
            }
        }
    }
}