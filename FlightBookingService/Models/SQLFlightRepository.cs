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
        public string AddBooking(BookingDetail booking)
        {
            Random r = new Random();
            string pnr = r.Next(100, 50000).ToString();
            booking.PNR = pnr;
            context.BookingDetail.Add(booking);
            foreach (PassengerDetail passenger in booking.PassengerDetails.ToList())
            {
                context.PassengerDetail.Add(passenger);
            }
            context.SaveChanges();
            return pnr;
        }

        public BookingDetail DeleteBooking(string pnr)
        {
            BookingDetail details = context.BookingDetail.FirstOrDefault(x => x.PNR == pnr);
            if (details != null)
            {
                List<PassengerDetail> passengerDetails = context.PassengerDetail.Where(x => x.BookingId == details.BookingId).ToList();
                if (passengerDetails.Any())
                    context.PassengerDetail.RemoveRange(passengerDetails);
                context.Remove(details);
                context.SaveChanges();
            }
            return details;
        }

        public BookingDetail GetBookingDetailsByBookingId(int bookingId)
        {
            var booking = (from b in context.BookingDetail
                                     where b.BookingId==bookingId
                           select new BookingDetail
                           {
                               BookingId = b.BookingId,
                               InventoryId = b.InventoryId,
                               FlightNumber = b.FlightNumber,
                               UserName = b.UserName,
                               Email = b.Email,
                               FromPlace = b.FromPlace,
                               ToPlace = b.ToPlace,
                               StartDateTime = b.StartDateTime,
                               EndDateTime = b.EndDateTime,
                               NoOfPassenger = b.NoOfPassenger,
                               BookingDate = b.BookingDate,
                               TravelClass = b.TravelClass,
                               Meal = b.Meal,
                               TicketCharges = b.TicketCharges,
                               PNR = b.PNR,
                               PassengerDetails = (from p in context.PassengerDetail
                                                   where p.BookingId==b.BookingId
                                                   select new PassengerDetail 
                                                   { 
                                                       Pid = p.Pid,
                                                       BookingId = p.BookingId,
                                                       Name = p.Name,
                                                       Age = p.Age,
                                                       Gender = p.Gender,
                                                       SeatNo = p.SeatNo
                                                   }).ToList()
                                     }).FirstOrDefault();
            return booking;
        }
        public BookingDetail GetBookingDetailsByPnr(string pnr)
        {
            var booking = (from b in context.BookingDetail
                           where b.PNR == pnr
                           select new BookingDetail
                           {
                               BookingId = b.BookingId,
                               InventoryId = b.InventoryId,
                               FlightNumber = b.FlightNumber,
                               UserName = b.UserName,
                               Email = b.Email,
                               FromPlace = b.FromPlace,
                               ToPlace = b.ToPlace,
                               StartDateTime = b.StartDateTime,
                               EndDateTime = b.EndDateTime,
                               NoOfPassenger = b.NoOfPassenger,
                               BookingDate = b.BookingDate,
                               TravelClass = b.TravelClass,
                               Meal = b.Meal,
                               TicketCharges = b.TicketCharges,
                               PNR = b.PNR,
                               PassengerDetails = (from p in context.PassengerDetail
                                                   where p.BookingId == b.BookingId
                                                   select new PassengerDetail
                                                   {
                                                       Pid = p.Pid,
                                                       BookingId = p.BookingId,
                                                       Name = p.Name,
                                                       Age = p.Age,
                                                       Gender = p.Gender,
                                                       SeatNo = p.SeatNo
                                                   }).ToList()
                           }).FirstOrDefault();
            return booking;
        }
        public BookingDetail GetBookingDetailsByEmail(string email)
        {
            var booking = (from b in context.BookingDetail
                           where b.Email == email
                           select new BookingDetail
                           {
                               BookingId = b.BookingId,
                               InventoryId = b.InventoryId,
                               FlightNumber = b.FlightNumber,
                               UserName = b.UserName,
                               Email = b.Email,
                               FromPlace = b.FromPlace,
                               ToPlace = b.ToPlace,
                               StartDateTime = b.StartDateTime,
                               EndDateTime = b.EndDateTime,
                               NoOfPassenger = b.NoOfPassenger,
                               BookingDate = b.BookingDate,
                               TravelClass = b.TravelClass,
                               Meal = b.Meal,
                               TicketCharges = b.TicketCharges,
                               PNR = b.PNR,
                               PassengerDetails = (from p in context.PassengerDetail
                                                   where p.BookingId == b.BookingId
                                                   select new PassengerDetail
                                                   {
                                                       Pid = p.Pid,
                                                       BookingId = p.BookingId,
                                                       Name = p.Name,
                                                       Age = p.Age,
                                                       Gender = p.Gender,
                                                       SeatNo = p.SeatNo
                                                   }).ToList()
                           }).FirstOrDefault();
            return booking;
        }        

        public IEnumerable<InventoryDetail> SearchFlight(SearchFlightDetail detail)
        {
            IEnumerable<InventoryDetail> goingDetails;
            IEnumerable<InventoryDetail> comingDetails;
            IEnumerable<InventoryDetail> allDetails;
            if (!detail.IsRoundTrip)
            {
                allDetails = context.InventoryDetail.Where(n => n.FromPlace == detail.From && n.ToPlace == detail.To && (n.ScheduledDays == "Daily" || (n.ScheduledDays == detail.StartTime.DayOfWeek.ToString() && n.StartDateTime.Date == detail.StartTime.Date)));
                foreach (var d in allDetails)
                {
                    if (d.ScheduledDays == "Daily")
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
