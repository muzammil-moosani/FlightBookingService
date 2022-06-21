using AirlineService.Models;
using FlightBookingService.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineService.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AirlineController : Controller
    {
        private IAirlineRepository airline;

        public AirlineController(IAirlineRepository _airline)
        {
            airline = _airline;
        }

        [HttpGet("GetAirlineById")]
        public AirlineDetail GetAirlineById(int airlineId)
        {
            return airline.GetAirlineById(airlineId);
        }
        [HttpGet]        
        public IEnumerable<AirlineDetail> GetAllAirlines()
        {
            return airline.GetAllAirlines();
        }

        [HttpPost("AddAirline")]
        public AirlineDetail AddAirline([FromBody]AirlineDetail detail)
        {
            return airline.AddAirline(detail);
        }

        [HttpDelete("DeleteAirline")]
        public AirlineDetail DeleteAirline(int airlineId)
        {
            return airline.DeleteAirline(airlineId);
        }

        [HttpPut("UpdateAirline")]
        public AirlineDetail UpdateAirline([FromBody]AirlineDetail changeAirline)
        {
            return airline.UpdateAirline(changeAirline);
        }

        [HttpPut("BlockAirline")]
        public bool BlockAirline(int airlineId)
        {
            return airline.BlockAirline(airlineId);
        }

        [HttpPut("UnBlockAirline")]
        public bool UnblockAirline(int airlineId)
        {
            return airline.UnblockAirline(airlineId);
        }

    }
}
