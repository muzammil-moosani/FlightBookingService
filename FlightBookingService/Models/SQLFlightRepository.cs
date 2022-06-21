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
            booking.BookingDate = DateTime.Now;
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
                           join i in context.InventoryDetail
                           on b.InventoryId equals i.InventoryId
                           join a in context.AirlineDetail
                           on i.AirlineId equals a.AirlineId
                           where b.BookingId == bookingId
                           select new BookingDetail
                           {
                               BookingId = b.BookingId,
                               InventoryId = b.InventoryId,
                               AirlineName = a.AirlineName,
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
        public BookingDetail GetBookingDetailsByPnr(string pnr)
        {
            var booking = (from b in context.BookingDetail
                           join i in context.InventoryDetail
                           on b.InventoryId equals i.InventoryId
                           join a in context.AirlineDetail
                           on i.AirlineId equals a.AirlineId
                           where b.PNR == pnr
                           select new BookingDetail
                           {
                               BookingId = b.BookingId,
                               InventoryId = b.InventoryId,
                               AirlineName = a.AirlineName,
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
        public IEnumerable<BookingDetail> GetBookingDetailsByName(string name)
        {
            var details = context.BookingDetail.
                Join(context.InventoryDetail, b=> b.InventoryId, i=>i.InventoryId,(b,i)=> new { b, i }).
                Join(context.AirlineDetail, r=> r.i.AirlineId, a=>a.AirlineId,(r,a)=> new {r,a }).
                Where(m => m.r.b.UserName == name)
                .Select(m=> new BookingDetail
                {
                    BookingId = m.r.b.BookingId,
                    InventoryId = m.r.b.InventoryId,
                    AirlineName = m.a.AirlineName,
                    FlightNumber = m.r.b.FlightNumber,
                    UserName = m.r.b.UserName,
                    Email = m.r.b.Email,
                    FromPlace = m.r.b.FromPlace,
                    ToPlace = m.r.b.ToPlace,
                    StartDateTime = m.r.b.StartDateTime,
                    EndDateTime = m.r.b.EndDateTime,
                    NoOfPassenger = m.r.b.NoOfPassenger,
                    BookingDate = m.r.b.BookingDate,
                    TravelClass = m.r.b.TravelClass,
                    Meal = m.r.b.Meal,
                    TicketCharges = m.r.b.TicketCharges,
                    PNR = m.r.b.PNR,
                    PassengerDetails = context.PassengerDetail.Where(p=> p.BookingId == m.r.b.BookingId)
                    .Select(z=> new PassengerDetail
                        {
                        Pid = z.Pid,
                        BookingId = z.BookingId,
                        Name = z.Name,
                        Age = z.Age,
                        Gender = z.Gender,
                        SeatNo = z.SeatNo
                    }).ToList()
                });

            //var booking = (from b in context.BookingDetail
            //               join i in context.InventoryDetail
            //               on b.InventoryId equals i.InventoryId
            //               join a in context.AirlineDetail
            //               on i.AirlineId equals a.AirlineId
            //               where b.UserName == name
            //               select new BookingDetail
            //               {
            //                   BookingId = b.BookingId,
            //                   InventoryId = b.InventoryId,
            //                   AirlineName = a.AirlineName,
            //                   FlightNumber = b.FlightNumber,
            //                   UserName = b.UserName,
            //                   Email = b.Email,
            //                   FromPlace = b.FromPlace,
            //                   ToPlace = b.ToPlace,
            //                   StartDateTime = b.StartDateTime,
            //                   EndDateTime = b.EndDateTime,
            //                   NoOfPassenger = b.NoOfPassenger,
            //                   BookingDate = b.BookingDate,
            //                   TravelClass = b.TravelClass,
            //                   Meal = b.Meal,
            //                   TicketCharges = b.TicketCharges,
            //                   PNR = b.PNR,
            //                   PassengerDetails = (from p in context.PassengerDetail
            //                                       where p.BookingId == b.BookingId
            //                                       select new PassengerDetail
            //                                       {
            //                                           Pid = p.Pid,
            //                                           BookingId = p.BookingId,
            //                                           Name = p.Name,
            //                                           Age = p.Age,
            //                                           Gender = p.Gender,
            //                                           SeatNo = p.SeatNo
            //                                       }).ToList()
            //               }).FirstOrDefault();
            return details;
        }

        public IEnumerable<InventoryDetail> SearchFlight(SearchFlightDetail detail)
        {
            IEnumerable<InventoryDetail> goingDetails;
            IEnumerable<InventoryDetail> comingDetails;
            IEnumerable<InventoryDetail> allDetails;


            if (!detail.IsRoundTrip)
            {
                allDetails = context.InventoryDetail.
                Join(context.AirlineDetail, a => a.AirlineId, i => i.AirlineId,
                (a, i) => new { a, i }).
                Where(m => m.a.FromPlace == detail.From && m.a.ToPlace == detail.To && (m.a.ScheduledDays == "Daily" || (m.a.ScheduledDays == detail.StartTime.DayOfWeek.ToString() && m.a.StartDateTime.Date == detail.StartTime.Date))).
                Select(m => new InventoryDetail
                {
                    InventoryId = m.a.InventoryId,
                    AirlineId = m.a.AirlineId,
                    AirlineName = m.i.AirlineName,
                    FlightNumber = m.a.FlightNumber,
                    FromPlace = m.a.FromPlace,
                    ToPlace = m.a.ToPlace,
                    StartDateTime = m.a.StartDateTime,
                    EndDateTime = m.a.EndDateTime,
                    ScheduledDays = m.a.ScheduledDays,
                    Instrument = m.a.Instrument,
                    NoOfBusinessSeats = m.a.NoOfBusinessSeats,
                    NoOfNonBusinessSeats = m.a.NoOfNonBusinessSeats,
                    TicketCharges = m.a.TicketCharges,
                    NoOfRows = m.a.NoOfRows,
                    Meal = m.a.Meal
                });
                //allDetails = context.InventoryDetail.Where(n => n.FromPlace == detail.From && n.ToPlace == detail.To && (n.ScheduledDays == "Daily" || (n.ScheduledDays == detail.StartTime.DayOfWeek.ToString() && n.StartDateTime.Date == detail.StartTime.Date)));
                foreach (var d in allDetails.Where(x => x.ScheduledDays == "Daily"))
                {
                    d.StartDateTime = detail.StartTime.Date + d.StartDateTime.TimeOfDay;
                    d.EndDateTime = detail.StartTime.Date + d.EndDateTime.TimeOfDay;

                }
            }
            else
            {
                goingDetails = context.InventoryDetail.
                Join(context.AirlineDetail, a => a.AirlineId, i => i.AirlineId,
                (a, i) => new { a, i }).
                Where(m => m.a.FromPlace == detail.From && m.a.ToPlace == detail.To && (m.a.ScheduledDays == "Daily" || (m.a.ScheduledDays == detail.StartTime.DayOfWeek.ToString() && m.a.StartDateTime.Date == detail.StartTime.Date))).
                Select(m => new InventoryDetail
                {
                    InventoryId = m.a.InventoryId,
                    AirlineId = m.a.AirlineId,
                    AirlineName = m.i.AirlineName,
                    FlightNumber = m.a.FlightNumber,
                    FromPlace = m.a.FromPlace,
                    ToPlace = m.a.ToPlace,
                    StartDateTime = m.a.StartDateTime,
                    EndDateTime = m.a.EndDateTime,
                    ScheduledDays = m.a.ScheduledDays,
                    Instrument = m.a.Instrument,
                    NoOfBusinessSeats = m.a.NoOfBusinessSeats,
                    NoOfNonBusinessSeats = m.a.NoOfNonBusinessSeats,
                    TicketCharges = m.a.TicketCharges,
                    NoOfRows = m.a.NoOfRows,
                    Meal = m.a.Meal
                });
                //goingDetails = context.InventoryDetail.Where((n => n.FromPlace == detail.From && n.ToPlace == detail.To && (n.ScheduledDays == "Daily" || (n.ScheduledDays == detail.StartTime.DayOfWeek.ToString() && n.StartDateTime.Date == detail.StartTime.Date))));
                foreach (var d in goingDetails)
                {
                    if (d.ScheduledDays == "Daily")
                    {
                        d.StartDateTime = detail.StartTime.Date + d.StartDateTime.TimeOfDay;
                        DateTime diff =
                        d.EndDateTime = detail.StartTime.Date + d.EndDateTime.TimeOfDay;
                    }
                }
                comingDetails = context.InventoryDetail.
                Join(context.AirlineDetail, a => a.AirlineId, i => i.AirlineId,
                (a, i) => new { a, i }).
                Where(m => m.a.FromPlace == detail.To && m.a.ToPlace == detail.From && (m.a.ScheduledDays == "Daily" || (m.a.ScheduledDays == detail.ReturnStartTime.DayOfWeek.ToString() && m.a.StartDateTime.Date == detail.ReturnStartTime.Date))).
                Select(m => new InventoryDetail
                {
                    InventoryId = m.a.InventoryId,
                    AirlineId = m.a.AirlineId,
                    AirlineName = m.i.AirlineName,
                    FlightNumber = m.a.FlightNumber,
                    FromPlace = m.a.FromPlace,
                    ToPlace = m.a.ToPlace,
                    StartDateTime = m.a.StartDateTime,
                    EndDateTime = m.a.EndDateTime,
                    ScheduledDays = m.a.ScheduledDays,
                    Instrument = m.a.Instrument,
                    NoOfBusinessSeats = m.a.NoOfBusinessSeats,
                    NoOfNonBusinessSeats = m.a.NoOfNonBusinessSeats,
                    TicketCharges = m.a.TicketCharges,
                    NoOfRows = m.a.NoOfRows,
                    Meal = m.a.Meal
                });
                //comingDetails = context.InventoryDetail.Where((n => n.FromPlace == detail.To && n.ToPlace == detail.From && (n.ScheduledDays == "Daily" || (n.ScheduledDays == detail.ReturnStartTime.DayOfWeek.ToString() && n.StartDateTime.Date == detail.ReturnStartTime.Date))));
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
