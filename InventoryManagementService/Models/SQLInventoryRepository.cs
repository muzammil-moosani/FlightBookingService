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
            context.InventoryDetail.Add()
        }

        public InventoryDetail DeleteInventory(int inventoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InventoryDetail> GetAllInventories()
        {
            throw new NotImplementedException();
        }

        public InventoryDetail GetInventoryById(int inventoryId)
        {
            throw new NotImplementedException();
        }

        public InventoryDetail UpdateInventory(InventoryDetail changeInventory)
        {
            throw new NotImplementedException();
        }
    }
}
