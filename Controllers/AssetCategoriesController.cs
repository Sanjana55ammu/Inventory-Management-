using InventoryManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetCategoriesController : ControllerBase
    {
        private static readonly List<AssetCategory> Categories = new()
        {
            new AssetCategory
            {
                CategoryID = 1,
                CategoryName = "Laptop",
                Description = "Laptop computers",
                IsActive = true
            },
            new AssetCategory
            {
                CategoryID = 2,
                CategoryName = "Printer",
                Description = "Office printers",
                IsActive = true
            },
            new AssetCategory
            {
                CategoryID = 3,
                CategoryName = "Computer",
                Description = "Desktop computers",
                IsActive = true
            }
        };

        // GET: api/AssetCategories
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(Categories);
        }

        // GET: api/AssetCategories/1
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = Categories.FirstOrDefault(c => c.CategoryID == id);

            if (category == null)
            {
                return NotFound("Category not found.");
            }

            return Ok(category);
        }

        // POST: api/AssetCategories
        [HttpPost]
        public IActionResult AddCategory(AssetCategory category)
        {
            int newID = Categories.Count == 0
                ? 1
                : Categories.Max(c => c.CategoryID) + 1;

            category.CategoryID = newID;
            Categories.Add(category);

            return CreatedAtAction(
                nameof(GetCategory),
                new { id = category.CategoryID },
                category);
        }

        // PUT: api/AssetCategories/1
        [HttpPut("{id}")]
        public IActionResult UpdateCategory(
            int id,
            AssetCategory updatedCategory)
        {
            var category = Categories.FirstOrDefault(c => c.CategoryID == id);

            if (category == null)
            {
                return NotFound("Category not found.");
            }

            category.CategoryName = updatedCategory.CategoryName;
            category.Description = updatedCategory.Description;
            category.IsActive = updatedCategory.IsActive;

            return Ok(category);
        }

        // DELETE: api/AssetCategories/1
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var category = Categories.FirstOrDefault(c => c.CategoryID == id);

            if (category == null)
            {
                return NotFound("Category not found.");
            }

            Categories.Remove(category);

            return Ok("Category deleted successfully.");
        }
    }
}