using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.Models
{
    public class SearchFlightDetail
    {
        public string From { get; set; }
        public string To { get; set; }
        public DateTime StartTime { get; set; }
        public bool IsRoundTrip { get; set; }
        public DateTime ReturnStartTime { get; set; }
    }
}
