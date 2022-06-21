using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.Models
{
    public interface IFlightRepository
    {
        IEnumerable<InventoryDetail> SearchFlight(SearchFlightDetail detail);
        string AddBooking(BookingDetail booking);
        BookingDetail GetBookingDetailsByBookingId(int bookingId);
        IEnumerable<BookingDetail> GetBookingDetailsByName(string name);
        BookingDetail GetBookingDetailsByPnr(string pnr);
        BookingDetail DeleteBooking(string pnr);
    }
}
