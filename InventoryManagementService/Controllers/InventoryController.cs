using FlightBookingService.Models;
using InventoryManagementService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementService.Controllers
{
    [Route("api/[controller]")]
    public class InventoryController : Controller
    {
        private IInventoryRepository inventory;

        public InventoryController(IInventoryRepository _inventory)
        {
            inventory = _inventory;
        }

        [HttpGet("GetInventoryById")]
        public InventoryDetail GetInventoryById(int inventoryId)
        {
            return inventory.GetInventoryById(inventoryId);
        }
        [HttpGet]
        public IEnumerable<InventoryDetail> GetAllInventories()
        {
            return inventory.GetAllInventories();
        }

        [HttpPost("AddInventory")]
        public InventoryDetail AddInventory([FromBody] InventoryDetail detail)
        {
            return inventory.AddInventory(detail);
        }

        [HttpDelete("DeleteInventory")]
        public InventoryDetail DeleteInventory(int inventoryId)
        {
            return inventory.DeleteInventory(inventoryId);
        }

        [HttpPut("UpdateInventory")]
        public InventoryDetail UpdateInventory([FromBody] InventoryDetail changeInventory)
        {
            return inventory.UpdateInventory(changeInventory);
        }
    }
}
