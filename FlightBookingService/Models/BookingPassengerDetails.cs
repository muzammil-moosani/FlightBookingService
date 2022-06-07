using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.Models
{
    public class BookingPassengerDetails
    {
        public BookingDetail BookingDetail { get; set; }
        public PassengerDetail[] PassengerDetail { get; set; }   
    }
}
