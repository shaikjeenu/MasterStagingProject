using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace masterDataSample.Models
{
	class ProviderStaging
	{
		public string Cluster { get; set; }
		public float TIN { get; set; }
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Title { get; set; }
		public string MiddleInitial { get; set; }
		public string AddressAddressLine1 { get; set; }
		public string AddressAddressLine2 { get; set; }
		public string AddressState { get; set; }
		public string AddressCity { get; set; }
		public float AddressZipCode { get; set; }
		public float AddressExtZipCode { get; set; }
		public string RenderingAddressLine1 { get; set; }
		public string RenderingAddressLine2 { get; set; }
		public string RenderingState { get; set; }
		
		public float RenderingZipCode { get; set; }
		public string RenderingExtZipCode { get; set; }
	}
}
