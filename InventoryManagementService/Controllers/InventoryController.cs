using InventoryManagementService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementService.Controllers
{
    public class InventoryController : Controller
    {
        private IInventoryRepository inventory;

        public InventoryController(IInventoryRepository _inventory)
        {
            inventory = _inventory;
        }

        [HttpGet]
        [Route("Inventory/GetInventoryById")]
        public InventoryDetail GetInventoryById(int inventoryId)
        {
            return inventory.GetInventoryById(inventoryId);
        }
        [HttpGet]
        [Route("Inventory/GetAllInventories")]
        public IEnumerable<InventoryDetail> GetAllInventories()
        {
            return inventory.GetAllInventories();
        }

        [HttpPost]
        [Route("Inventory/AddInventory")]
        public InventoryDetail AddInventory([FromBody] InventoryDetail detail)
        {
            return inventory.AddInventory(detail);
        }

        [HttpDelete]
        [Route("Inventory/DeleteInventory")]
        public InventoryDetail DeleteInventory(int inventoryId)
        {
            return inventory.DeleteInventory(inventoryId);
        }

        [HttpPut]
        [Route("Inventory/UpdateInventory")]
        public InventoryDetail UpdateInventory([FromBody] InventoryDetail changeInventory)
        {
            return inventory.UpdateInventory(changeInventory);
        }
    }
}
