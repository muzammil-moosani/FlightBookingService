using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingService.Models;

namespace FlightBookingService.Controllers
{
    [Route("api/[controller]")]
    public class FlightController : Controller
    {
        private IFlightRepository flight;

        public FlightController(IFlightRepository _flight)
        {
            flight = _flight;
        }

        [HttpGet("SearchFlight")]
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
        [HttpGet("GetBookingDetailsByEmail")]
        public BookingDetail GetBookingDetailsByEmail(string email)
        {
            return flight.GetBookingDetailsByEmail(email);
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
