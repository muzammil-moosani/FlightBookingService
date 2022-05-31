using AirlineService.Models;
using FlightBookingService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineService.Controllers
{
    public class AirlineController : Controller
    {
        private IAirlineRepository airline;

        public AirlineController(IAirlineRepository _airline)
        {
            airline = _airline;
        }

        [HttpGet]
        [Route("Airline/GetAirlineById")]
        public AirlineDetail GetAirlineById(int airlineId)
        {
            return airline.GetAirlineById(airlineId);
        }
        [HttpGet]
        [Route("Airline/GetAllAirlines")]
        public IEnumerable<AirlineDetail> GetAllAirlines()
        {
            return airline.GetAllAirlines();
        }

        [HttpPost]
        [Route("Airline/AddAirline")]
        public AirlineDetail AddAirline([FromBody]AirlineDetail detail)
        {
            return airline.AddAirline(detail);
        }

        [HttpDelete]
        [Route("Airline/DeleteAirline")]
        public AirlineDetail DeleteAirline(int airlineId)
        {
            return airline.DeleteAirline(airlineId);
        }

        [HttpPut]
        [Route("Airline/UpdateAirline")]
        public AirlineDetail UpdateAirline([FromBody]AirlineDetail changeAirline)
        {
            return airline.UpdateAirline(changeAirline);
        }

        [HttpPut]
        [Route("Airline/BlockAirline")]
        public bool BlockAirline(int airlineId)
        {
            return airline.BlockAirline(airlineId);
        }

    }
}
