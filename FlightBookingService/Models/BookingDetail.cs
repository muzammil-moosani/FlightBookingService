using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FlightBookingService.Models
{
    public class BookingDetail
    {
        [Key]
        public int BookingId { get; set; }
        public int InventoryId { get; set; }
        [ForeignKey("InventoryId")]
        [NotMapped]
        public string AirlineName { get; set; }
        public virtual InventoryDetail InventoryDetail { get; set; }
        public int FlightNumber { get; set; }        
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int NoOfPassenger { get; set; }
        public DateTime BookingDate { get; set; }
        public string TravelClass { get; set; }
        public string Meal { get; set; }
        public double TicketCharges { get; set; }
        public string PNR { get; set; }
        public List<PassengerDetail> PassengerDetails { get; set; }
        //[NotMapped]
        //public string Passengers { get; set; }
    }
}
