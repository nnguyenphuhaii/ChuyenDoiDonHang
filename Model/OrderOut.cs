using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuyenDoiDonHang.Model
{
	public class OrderOut
	{
		public string? ID { get; set; }
		public string? ProductSKU { get; set; }
		public string? Size { get; set; }
		public string? Quantity { get; set; }
		public string? Name { get; set; }
		public string? Telephone { get; set; }
		public string? Countrycode { get; set; }
		public string? Province { get; set; }
		public string? City { get; set; }
		public string? Street { get; set; }
		public string? Postcode { get; set; }
		public string? DesignLink { get; set; }
		public string? MockupLink { get; set; }
		public string? BaseCost { get; set; }
		public string? VAT { get; set; }
		public string? Note { get; set; }
		public string? CustomName { get; set; }
        public string? VerifyAddress { get; set; }

		public Address ToAddress()
		{
			return new Address
			{
				AddressLine1 = this.Street,
				City = this.City,
				State = this.Province,
				PostalCode = this.Postcode,
				Country = this.Countrycode
			};
		}
	}
}
