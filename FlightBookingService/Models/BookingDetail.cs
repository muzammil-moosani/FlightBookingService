using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.Models
{
    public class BookingDetail
    {
        [Key]
        public int BookingId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime TravellingDate { get; set; }
        public int NoOfPassenger { get; set; }
        public DateTime BookingDate { get; set; }
        public string TravelClass { get; set; }
        public bool IsMeal { get; set; }
        public string PreferredCarrier { get; set; }
        public string Remarks { get; set; }
    }
}
