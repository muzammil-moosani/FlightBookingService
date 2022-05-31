using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.Models
{
    public class SQLFlightRepository : IFlightRepository
    {
        private AppDbContext context;
        public SQLFlightRepository(AppDbContext context)
        {
            this.context = context;
        }
        public BookingDetail AddBooking(BookingDetail booking)
        {
            context.BookingDetails.Add(booking);
            context.SaveChanges();
            return booking;
        }

        public BookingDetail DeleteBooking(int bookingId)
        {
            BookingDetail details = context.BookingDetails.Find(bookingId);
            if (details != null)
            {
                context.Remove(details);
                context.SaveChanges();
            }
            return details;
        }

        public IEnumerable<BookingDetail> GetBookingDetailsByUserId(int id)
        {
            IEnumerable<BookingDetail> details = context.BookingDetails;
            return details.Where(n => n.Id == id);
        }

        public IEnumerable<BookingDetail> GetBookingDetailsByBookingId(int bookingId)
        {
            IEnumerable<BookingDetail> details = context.BookingDetails;
            return details.Where(n => n.BookingId == bookingId);
        }

        public BookingDetail UpdateBooking(BookingDetail changebooking)
        {
            var details = context.BookingDetails.Attach(changebooking);
            details.State = EntityState.Modified;
            context.SaveChanges();
            return changebooking;
        }
    }
}
