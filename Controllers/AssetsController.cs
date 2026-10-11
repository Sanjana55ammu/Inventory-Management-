using InventoryManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetsController : ControllerBase
    {
        private static readonly List<Asset> Assets = new()
        {
            new Asset
            {
                AssetID = 1,
                AssetName = "Dell Laptop",
                AssetCode = "AST-1001",
                IdentificationNumber = "ID-001",
                SerialNumber = "DL123456",
                Category = new AssetCategory { CategoryName = "Laptop" },
                Description = "Dell laptop for office use",
                Manufacturer = "Dell",
                Model = "Latitude 5420",
                Status = "Available",
                AssetCondition = "Good",
                Location = "IT Department"
            },

            new Asset
            {
                AssetID = 2,
                AssetName = "HP Printer",
                AssetCode = "AST-1002",
                IdentificationNumber = "ID-002",
                SerialNumber = "HP789456",
                Category = new AssetCategory { CategoryName = "Printer" },
                Description = "Office network printer",
                Manufacturer = "HP",
                Model = "LaserJet Pro",
                Status = "Assigned",
                AssetCondition = "Good",
                Location = "HR Department"
            }
        };

        // GET: api/Assets
        [HttpGet]
        public IActionResult GetAssets()
        {
            return Ok(Assets);
        }

        // GET: api/Assets/1
        [HttpGet("{id}")]
        public IActionResult GetAsset(int id)
        {
            var asset = Assets.FirstOrDefault(a => a.AssetID == id);

            if (asset == null)
            {
                return NotFound("Asset not found.");
            }

            return Ok(asset);
        }

        // POST: api/Assets
        [HttpPost]
        public IActionResult AddAsset(Asset asset)
        {
            int newID = Assets.Count == 0
                ? 1
                : Assets.Max(a => a.AssetID) + 1;

            asset.AssetID = newID;

            Assets.Add(asset);

            return CreatedAtAction(
                nameof(GetAsset),
                new { id = asset.AssetID },
                asset
            );
        }

        // PUT: api/Assets/1
        [HttpPut("{id}")]
        public IActionResult UpdateAsset(int id, Asset updatedAsset)
        {
            var asset = Assets.FirstOrDefault(a => a.AssetID == id);

            if (asset == null)
            {
                return NotFound("Asset not found.");
            }

            asset.AssetName = updatedAsset.AssetName;
            asset.AssetCode = updatedAsset.AssetCode;
            asset.IdentificationNumber = updatedAsset.IdentificationNumber;
            asset.SerialNumber = updatedAsset.SerialNumber;
            asset.Category = updatedAsset.Category;
            asset.Description = updatedAsset.Description;
            asset.Manufacturer = updatedAsset.Manufacturer;
            asset.Model = updatedAsset.Model;
            asset.Status = updatedAsset.Status;
            asset.AssetCondition = updatedAsset.AssetCondition;
            asset.Location = updatedAsset.Location;

            return Ok(asset);
        }

        // DELETE: api/Assets/1
        [HttpDelete("{id}")]
        public IActionResult DeleteAsset(int id)
        {
            var asset = Assets.FirstOrDefault(a => a.AssetID == id);

            if (asset == null)
            {
                return NotFound("Asset not found.");
            }

            Assets.Remove(asset);

            return Ok("Asset deleted successfully.");
        }

        // GET: api/Assets/search?keyword=laptop
        [HttpGet("search")]
        public IActionResult SearchAssets(string keyword)
        {
            var results = Assets
                .Where(a =>
                    a.AssetName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    a.AssetCode.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    (a.SerialNumber?.Contains(keyword, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (a.IdentificationNumber?.Contains(keyword, StringComparison.OrdinalIgnoreCase) ?? false))
                .ToList();

            return Ok(results);
        }

        // GET: api/Assets/filter?categoryID=1&status=Available&location=IT
        [HttpGet("filter")]
        public IActionResult FilterAssets(
            int? categoryID,
            string? status,
            string? location)
        {
            var results = Assets.AsEnumerable();

            if (categoryID.HasValue)
            {
                results = results.Where(a => a.CategoryID == categoryID.Value);
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                results = results.Where(a =>
                    a.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(location))
            {
                results = results.Where(a =>
                    a.Location?.Contains(location, StringComparison.OrdinalIgnoreCase) ?? false);
            }

            return Ok(results.ToList());
        }
    }
}
