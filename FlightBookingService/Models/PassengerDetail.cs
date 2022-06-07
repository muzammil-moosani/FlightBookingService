using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.Models
{
    public class PassengerDetail
    {
        [Key]
        public int Pid { get; set; }
        public int BookingId { get; set; }
        public int Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int SeatNo { get; set; }
    }
}
