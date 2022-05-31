using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineService.Models
{
    public class AirlineDetail
    {
        [Key]
        public int AirlineId { get; set; }
        public string AirlineName { get; set; }
        public string AirlineLogo { get; set; }
        public string ContactAddress { get; set; }
        public string ContactNumber { get; set; }
        public bool IsBlocked { get; set; }

    }
}
