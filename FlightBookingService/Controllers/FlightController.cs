using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingService.Models;

namespace FlightBookingService.Controllers
{
    public class FlightController : Controller
    {
        private IFlightRepository flight;

        public FlightController(IFlightRepository _flight)
        {
            flight = _flight;
        }

        [HttpGet]
        [Route("Flight/GetBookingByUser")]
        public IEnumerable<BookingDetail> GetBookingDetailsByUserId(int Id)
        {
            return flight.GetBookingDetailsByUserId(Id);
        }
        [HttpGet]
        [Route("Flight/GetBooking")]
        public IEnumerable<BookingDetail> GetBookingDetailsByBookingId(int bookingId)
        {
            return flight.GetBookingDetailsByBookingId(bookingId);
        }

        [HttpPost]
        [Route("Flight/AddBooking")]
        public BookingDetail AddBooking([FromBody]BookingDetail detail)
        {            
            return flight.AddBooking(detail);
        }

        [HttpDelete]
        [Route("Flight/DeleteBooking")]
        public BookingDetail DeleteBooking(int bookingId)
        {
            return flight.DeleteBooking(bookingId);
        }

        [HttpPut]
        [Route("Flight/UpdateBooking")]
        public BookingDetail UpdateBooking([FromBody]BookingDetail changebooking)
        {
            return flight.UpdateBooking(changebooking);
        }

    }
}
