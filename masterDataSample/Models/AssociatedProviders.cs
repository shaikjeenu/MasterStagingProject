using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace masterDataSample.Models
{
	class AssociatedProviders
	{
		public int AssociatedProviderId { get; set; }
		public int ProviderId { get; set; }
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Title { get; set; }
		public string MiddleInitial { get; set; }
		public string GroupName { get; set; }
		

	}
}
