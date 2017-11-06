using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace masterDataSample.Models
{
	class ProviderAddress
	{
		public int AddressId { get; set; }
		public int AddressTypeId { get; set; }
		public string Address1 { get; set; }
		public string Address2 { get; set; }
		public string City { get; set; }
		public float Zip { get; set; }
		public int StateProvinceId { get; set; }
	}
}
