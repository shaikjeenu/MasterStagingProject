using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace masterDataSample.Models
{
	class ProviderTin
	{
		public int ProviderTinId { get; set; }
		public int AssociatedProviderId { get; set; }
		public float TinNumber { get; set; }
	}
}
