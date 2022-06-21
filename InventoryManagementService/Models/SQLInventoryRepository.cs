using FlightBookingService.Models;
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
            if (inventoryDetail != null)
            {
                context.Remove(inventoryDetail);
                context.SaveChanges();
            }
            return inventoryDetail;
        }

        public IEnumerable<InventoryDetail> GetAllInventories()
        {
            var details = context.InventoryDetail.
                Join(context.AirlineDetail, a => a.AirlineId, i => i.AirlineId,
                (a, i) => new { a, i }).
                Select( m=> new InventoryDetail
                {
                    InventoryId = m.a.InventoryId,
                    AirlineId = m.a.AirlineId,
                    AirlineName = m.i.AirlineName,
                    FlightNumber = m.a.FlightNumber,
                    FromPlace = m.a.FromPlace,
                    ToPlace = m.a.ToPlace,
                    StartDateTime = m.a.StartDateTime,
                    EndDateTime = m.a.EndDateTime,
                    ScheduledDays = m.a.ScheduledDays,
                    Instrument = m.a.Instrument,
                    NoOfBusinessSeats = m.a.NoOfBusinessSeats,
                    NoOfNonBusinessSeats = m.a.NoOfNonBusinessSeats,
                    TicketCharges = m.a.TicketCharges,
                    NoOfRows = m.a.NoOfRows,
                    Meal = m.a.Meal
                });

            return details;
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
