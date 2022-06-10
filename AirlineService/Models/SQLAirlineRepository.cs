using FlightBookingService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineService.Models
{
    public class SQLAirlineRepository : IAirlineRepository
    {
        private AppDbContext context;
        public SQLAirlineRepository(AppDbContext context)
        {
            this.context = context;
        }
        public AirlineDetail AddAirline(AirlineDetail airline)
        {
            context.AirlineDetail.Add(airline);
            context.SaveChanges();
            return airline;
        }

        public AirlineDetail DeleteAirline(int airlineId)
        {
            AirlineDetail details = context.AirlineDetail.Find(airlineId);
            if (details != null)
            {
                context.Remove(details);
                context.SaveChanges();
            }
            return details;
        }

        public AirlineDetail GetAirlineById(int airlineId)
        {
            IEnumerable<AirlineDetail> detail = context.AirlineDetail.Where(n => n.AirlineId == airlineId && n.IsBlocked == false);
            if (detail.Any())
                return detail.First();
            else
                return new AirlineDetail();
        }

        public IEnumerable<AirlineDetail> GetAllAirlines()
        {
            return context.AirlineDetail.Where(n => n.IsBlocked == false);
        }

        public AirlineDetail UpdateAirline(AirlineDetail changeAirline)
        {
            var details = context.AirlineDetail.Attach(changeAirline);
            details.State = EntityState.Modified;
            context.SaveChanges();
            return changeAirline;
        }

        public bool BlockAirline(int airlineId)
        {
            var airline = context.AirlineDetail.Where(n => n.AirlineId == airlineId).FirstOrDefault();
            if(airline != null)
            {
                airline.IsBlocked = true;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
