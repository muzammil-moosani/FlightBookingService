﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.Models
{
    public interface IFlightRepository
    {
        BookingDetail AddBooking(BookingDetail booking);
        IEnumerable<BookingDetail> GetBookingDetailsByUserId(int id);
        IEnumerable<BookingDetail> GetBookingDetailsByBookingId(int bookingId);
        BookingDetail UpdateBooking(BookingDetail changebooking);
        BookingDetail DeleteBooking(int bookingId);
    }
}