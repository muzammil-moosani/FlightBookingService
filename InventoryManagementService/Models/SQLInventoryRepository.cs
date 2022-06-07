using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementService.Models
{
    public class SQLInventoryRepository : IInventoryRepository
    {
        private AppDbContext context;
        public SQLInventoryRepository(AppDbContext context)
        {
            this.context = context;
        }
        public InventoryDetail AddInventory(InventoryDetail inventory)
        {
            context.InventoryDetail.Add(inventory);
            context.SaveChanges();
            return inventory;
        }

        public InventoryDetail DeleteInventory(int inventoryId)
        {
            InventoryDetail inventoryDetail = context.InventoryDetail.Find(inventoryId);
            if(inventoryDetail != null)
            {
                context.Remove(inventoryDetail);
                context.SaveChanges();
            }
            return inventoryDetail;
        }

        public IEnumerable<InventoryDetail> GetAllInventories()
        {
            return context.InventoryDetail;
        }

        public InventoryDetail GetInventoryById(int inventoryId)
        {
            return context.InventoryDetail.Find(inventoryId);
        }

        public InventoryDetail UpdateInventory(InventoryDetail changeInventory)
        {
            var details = context.InventoryDetail.Attach(changeInventory);
            details.State = EntityState.Modified;
            context.SaveChanges();
            return changeInventory;
        }
    }
}
