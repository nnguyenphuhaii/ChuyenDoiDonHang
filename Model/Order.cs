using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuyenDoiDonHang.Model
{
    public class Order
    {
        public string? ShopDomain { get; set; }
        public string? Name { get; set; }
        public string? ShippingMethod { get; set; }
        public string? CreatedAt { get; set; }
        public string? LineitemQuantity { get; set; }
        public string? LineitemVariantId { get; set; }
        public string? LineitemName { get; set; }
        public string? LineitemSku { get; set; }
        public string? SKUYOCOL { get; set; }
        public string? LineitemTaxable { get; set; }
        public string? LineitemFulfillableQuantity { get; set; }
        public string? ShippingName { get; set; }
        public string? ShippingStreet { get; set; }
        public string? ShippingAddress1 { get; set; }
        public string? ShippingAddress2 { get; set; }
        public string? ShippingCompany { get; set; }
        public string? ShippingCity { get; set; }
        public string? ShippingZip { get; set; }
        public string? ShippingProvince { get; set; }
        public string? ShippingCountry { get; set; }
        public string? ShippingPhone { get; set; }
        public string? Notes { get; set; }
        public string? NoteAttributes { get; set; }
        public string? CancelledAt { get; set; }
        public string? PaymentMethod { get; set; }
        public string? PaymentReference { get; set; }
        public string? RefundAmount { get; set; }
        public string? Vendor { get; set; }
        public string? Id { get; set; }
        public string? Tags { get; set; }
        public string? RiskLevel { get; set; }
        public string? Source { get; set; }
        public string? LineitemDiscount { get; set; }
        public string? Phone { get; set; }
        public string? SourceIdentifier { get; set; }
        public string? ReferringSite { get; set; }
        public string? LandingSite { get; set; }
        public string? UtmSource { get; set; }
        public string? UtmMedium { get; set; }
        public string? UtmCampaign { get; set; }
        public string? PlbProfit { get; set; }
        public string? PlbApproveStatus { get; set; }
        public string? LineitemProfit { get; set; }
        public string? OpenDisputeDate { get; set; }
        public string? DisputeReason { get; set; }
        public string? DisputeDueDate { get; set; }
        public string? DisputeStatus { get; set; }
        public string? IsTestOrder { get; set; }
        public string? SourceAnalytics { get; set; }
    }
}
