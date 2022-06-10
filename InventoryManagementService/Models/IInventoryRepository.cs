using FlightBookingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementService.Models
{
    public interface IInventoryRepository
    {
        InventoryDetail AddInventory(InventoryDetail inventory);
        InventoryDetail UpdateInventory(InventoryDetail changeInventory);
        InventoryDetail DeleteInventory(int inventoryId);
        IEnumerable<InventoryDetail> GetAllInventories();
        InventoryDetail GetInventoryById(int inventoryId);

    }
}
