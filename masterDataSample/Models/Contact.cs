using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace masterDataSample.Models
{
	class Contact
	{
		public int ContactId { get; set; }
		public int AddressTypeId { get; set; }
		public int AssociatedProvinceId { get; set; }
		public int AddressId { get; set; }
		public int ContactPersonId { get; set; }
	}
}
