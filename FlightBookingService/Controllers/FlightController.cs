using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace FlightBookingService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FlightController : Controller
    {
        private IFlightRepository flight;

        public FlightController(IFlightRepository _flight)
        {
            flight = _flight;
        }

        [HttpPost("SearchFlight")]
        public IEnumerable<InventoryDetail> SearchFlight([FromBody] SearchFlightDetail detail)
        {
            return flight.SearchFlight(detail);
        }

        [HttpGet("GetBookingDetailsByBookingId")]
        public BookingDetail GetBookingDetailsByBookingId(int bookingId)
        {
            return flight.GetBookingDetailsByBookingId(bookingId);
        }
        [HttpGet("GetBookingDetailsByPnr")]
        public BookingDetail GetBookingDetailsByPnr(string pnr)
        {
            return flight.GetBookingDetailsByPnr(pnr);
        }
        [HttpGet("GetBookingDetailsByName")]
        public IEnumerable<BookingDetail> GetBookingDetailsByName(string name)
        {
            return flight.GetBookingDetailsByName(name);
        }
        [HttpPost("AddBooking")]
        public string AddBooking([FromBody]BookingDetail detail)
        {            
            return flight.AddBooking(detail);
        }

        [HttpDelete("DeleteBooking")]
        public BookingDetail DeleteBooking(string pnr)
        {
            return flight.DeleteBooking(pnr);
        }

    }
}
