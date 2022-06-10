using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.Models
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<BookingDetail> BookingDetail { get; set; }       
        public DbSet<PassengerDetail> PassengerDetail { get; set; }
        public DbSet<InventoryDetail> InventoryDetail { get; set; }
        public DbSet<AirlineDetail> AirlineDetail { get; set; }
    }
}
