using AirlineService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.Models
{
    public interface IAirlineRepository
    {
        AirlineDetail AddAirline(AirlineDetail airline);
        IEnumerable<AirlineDetail> GetAllAirlines();
        AirlineDetail GetAirlineById(int airlineId);
        AirlineDetail UpdateAirline(AirlineDetail changeAirline);
        AirlineDetail DeleteAirline(int airlineId);
        bool BlockAirline(int airlineId);
    }
}
