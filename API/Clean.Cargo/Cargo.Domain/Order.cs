using Cargo.Application.Enums;
using Cargo.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo.Domain
{
    public record Order:BaseEntity
    {
        public string TrackingNumber { get; set; }
        public string Seller { get; set; }
        public double Weight { get; set; }
        public string Notes { get; set; }
        public OrderCategory OrderCategory { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public double ShippingFee { get; set; }
        public string InvoiceImage { get; set; }
        public string PackageImage { get; set; }
        public bool PaymentStatus { get; set; }


    }
}
