using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuyenDoiDonHang.Model
{
    public class Order
    {
        public string? Name { get; set; }
        public string? LineitemQuantity { get; set; }
        public string? LineitemSku { get; set; }
        public string? ShippingName { get; set; }
        public string? ShippingPhone { get; set; }
        public string? ShippingCountryCode { get; set; }
        public string? ShippingProvince { get; set; }
        public string? ShippingCity { get; set; }
        public string? ShippingAddress1 { get; set; }
        public string? ShippingAddress2 { get; set; }
        public string? ShippingZip { get; set; }
        public string? LineitemImage { get; set; }
        public string? LineitemProperties { get; set; }
        public string? ShippingMethod { get; set; }
        public string? IsTestOrder { get; set; }
        public string? SourceAnalytics { get; set; }
    }
}
