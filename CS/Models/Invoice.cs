using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InstantFeedback.Models {
    public partial class Order {
        public int OrderId { get; set; }

        [Required]
        public string ShipName { get; set; }

        [Required]
        public string ShipCity { get; set; }

        [Required]
        public string ShipCountry { get; set; }

        public decimal? Freight { get; set; }

        [Range(typeof(DateTime), "1/1/1996", "1/1/1999",
        ErrorMessage = "OrderDate must be between {1:d} and {2:d}")]
        public DateTime? OrderDate { get; set; }

        [Range(typeof(DateTime), "1/1/1996", "1/1/1999",
        ErrorMessage = "ShippedDate must be between {1:d} and {2:d}")]
        public DateTime? ShippedDate { get; set; }
    }
}
