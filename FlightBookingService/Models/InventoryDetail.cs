using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.Models
{
    public class InventoryDetail
    {
        [Key]
        public int InventoryId { get; set; }
        public int AirlineId { get; set; }
        [ForeignKey("AirlineId")]
        public virtual AirlineDetail AirlineDetail { get; set; }
        [NotMapped]
        public string AirlineName { get; set; }
        public int FlightNumber { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string ScheduledDays { get; set; }
        public string Instrument { get; set; }
        public int NoOfBusinessSeats { get; set; }
        public int NoOfNonBusinessSeats { get; set; }
        public double TicketCharges { get; set; }
        public int NoOfRows { get; set; }
        public string Meal { get; set; }
    }
}
