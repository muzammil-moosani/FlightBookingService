using AirlineService.Models;
using InventoryManagementService.Models;
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
        public string AddBooking(BookingPassengerDetails booking)
        {
            Random r = new Random();
            string pnr = r.Next(100, 50000).ToString();
            //pnr = booking.BookingId + pnr + booking.BookingId;

            //context.BookingDetails.Add(booking);

            //foreach(var passenger in booking.PassengerDetails)
            //{
            //    var pass = new PassengerDetail()
            //    {
            //        BookingId = booking.BookingId,
            //        Name = passenger.Name,
            //        Age = passenger.Age,
            //        Gender = passenger.Gender,
            //        SeatNo = passenger.SeatNo
            //    };
            //    context.PassengerDetail.Add(pass);
            //}
            //context.SaveChanges();
            return pnr;
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
            return details.Where(n => n.UserId == id);
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

        public IEnumerable<InventoryDetail> SearchFlight(SearchFlightDetail detail)
        {
            IEnumerable<InventoryDetail> goingDetails;
            IEnumerable<InventoryDetail> comingDetails;
            IEnumerable<InventoryDetail> allDetails;
            if (!detail.IsRoundTrip)
            {
                allDetails = context.InventoryDetail.Where(n => n.FromPlace == detail.From && n.ToPlace == detail.To && (n.ScheduledDays == "Daily" || (n.ScheduledDays == detail.StartTime.DayOfWeek.ToString() && n.StartDateTime.Date == detail.StartTime.Date)));
                foreach(var d in allDetails)
                {
                    if(d.ScheduledDays =="Daily")
                    {
                        d.StartDateTime = detail.StartTime.Date + d.StartDateTime.TimeOfDay;
                        d.EndDateTime = detail.StartTime.Date + d.EndDateTime.TimeOfDay;
                    }
                }
            }
            else
            {
                goingDetails = context.InventoryDetail.Where((n => n.FromPlace == detail.From && n.ToPlace == detail.To && (n.ScheduledDays == "Daily" || (n.ScheduledDays == detail.StartTime.DayOfWeek.ToString() && n.StartDateTime.Date == detail.StartTime.Date))));
                foreach (var d in goingDetails)
                {
                    if (d.ScheduledDays == "Daily")
                    {
                        d.StartDateTime = detail.StartTime.Date + d.StartDateTime.TimeOfDay;
                        DateTime diff = 
                        d.EndDateTime = detail.StartTime.Date + d.EndDateTime.TimeOfDay;
                    }
                }
                comingDetails = context.InventoryDetail.Where((n => n.FromPlace == detail.To && n.ToPlace == detail.From && (n.ScheduledDays == "Daily" || (n.ScheduledDays == detail.ReturnStartTime.DayOfWeek.ToString() && n.StartDateTime.Date == detail.ReturnStartTime.Date))));
                foreach (var d in comingDetails)
                {
                    if (d.ScheduledDays == "Daily")
                    {
                        d.StartDateTime = detail.ReturnStartTime.Date + d.StartDateTime.TimeOfDay;
                        d.EndDateTime = detail.ReturnStartTime.Date + d.EndDateTime.TimeOfDay;
                    }
                }
                allDetails = goingDetails.Concat(comingDetails);
            }
            return allDetails;
        }
    }
}
