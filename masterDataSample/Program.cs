using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using masterDataSample.Models;
using System.Data.SqlClient;

namespace masterDataSample
{
	public enum AddressType
	{
		Billing=1,Rendering
	}

	class Program
	{
		static void Main(string[] args)
		{
			dbo db = new dbo();
			List<ProviderStaging> stagingdata =db.GetProviderStagingData();

			if (db.InsertProviderData(stagingdata))
			{
				if (db.InsertAssosiatedProvidersData(stagingdata))
				{
					db.InsertTinNumbers(stagingdata);
					//db.InsertSpecalityTable(stagingdata);
					db.InsertProviderCertificate(stagingdata);

					if (db.InsertProviderAddress(stagingdata) && db.insertContactPerson(stagingtable))
					{
						if (db.InsertContact(stagingdata))
						{
							db.InsertConatactPoint(stagingdata);
						}
					}
					//db.Insert
				}
			}


			//if (db.InsertProviderData(stagingdata))
			//{
			//	Console.WriteLine("Provider Table Data Inserted");
			//	if (db.InsertAssosiatedProvidersData(stagingdata))
			//	{
			//		db.InsertTinNumbers(stagingdata);
			//	}
			//}

			//if (db.InsertProviderAddress(stagingdata))
			//{
			//	db.InsertContact(stagingdata);
			//}

			db.InsertContact(stagingdata);
		}



	}


	class dbo
	{
		SqlConnection conn;
		SqlCommand cmd;
		string connString = System.Configuration.ConfigurationManager.ConnectionStrings["dataStaging"].ConnectionString;

		

		public List<ProviderStaging> GetProviderStagingData()
		{
			List<ProviderStaging> stagingdata = new List<ProviderStaging>();
			ProviderStaging row;

			try
			{
				conn = new SqlConnection(connString);
				cmd = new SqlCommand("select * from Provider_Staging", conn);
				conn.Open();

				SqlDataReader dr= cmd.ExecuteReader();

				//System.Data.DataTable dt = new System.Data.DataTable();
				//dt.Load(dr);

				while (dr.Read())
				{
					row = new ProviderStaging();

					
					row.FirstName = Nullable.Equals( dr["FistName"],null) ? null: dr["FistName"].ToString();
					row.LastName = Nullable.Equals(dr["LastName"], null) ? null : dr["LastName"].ToString();
					row.Cluster = dr["Cluster"].ToString();
					row.MiddleInitial = Nullable.Equals(dr["MiddleInitial"], null) ? null : dr["MiddleInitial"].ToString();
					row.Title = Nullable.Equals(dr["Title"], null) ? null : dr["Title"].ToString();
					row.TIN = float.Parse(Nullable.Equals(dr["TIN"], null) ? "0" : dr["TIN"].ToString());
					row.AddressAddressLine1 = Nullable.Equals(dr["Address/AddressLine1"], null) ? null : dr["Address/AddressLine1"].ToString();
					row.AddressAddressLine2 = Nullable.Equals(dr["Address/AddressLine2"], null) ? null : dr["Address/AddressLine2"].ToString();
					row.AddressState = Nullable.Equals(dr["Address/State"], null) ? null : dr["Address/State"].ToString();
					row.AddressCity = Nullable.Equals(dr["Address/City"], null) ? null : dr["Address/City"].ToString();
					row.AddressZipCode = float.Parse(Nullable.Equals(dr["Address/ZipCode"], null) ? "0" : dr["Address/ZipCode"].ToString());
					row.AddressExtZipCode = float.Parse(Nullable.Equals(dr["Address/ExtZipCode"], null) ? "0" : dr["Address/ExtZipCode"].ToString());
					row.RenderingAddressLine1 = Nullable.Equals(dr["RenderingAddress/AddressLine1"], null) ? null : dr["RenderingAddress/AddressLine1"].ToString();
					row.RenderingAddressLine2 = Nullable.Equals(dr["RenderingAddress/AddressLine2"], null) ? null : dr["RenderingAddress/AddressLine2"].ToString();
					row.RenderingState = Nullable.Equals(dr["RenderingAddress/State"], null) ? null : dr["RenderingAddress/State"].ToString();
					row.RenderingZipCode = float.Parse(Nullable.Equals(dr["RenderingAddress/ZipCode"], null) ? "0" : dr["RenderingAddress/ZipCode"].ToString());
					row.RenderingExtZipCode = Nullable.Equals(dr["RenderingAddress/ExtZipCode"], null) ? null : dr["RenderingAddress/ExtZipCode"].ToString();
					//new DateTime(dr["fdf"].ToString());



					stagingdata.Add(row);
				}

				conn.Close();
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
			}


			return stagingdata;
		}


		//public List<ProviderStaging> GetProviderAddressFromStaging()
		//{
		//	List<ProviderStaging> stagingdata = new List<ProviderStaging>();
		//	ProviderStaging row;

		//	try
		//	{
		//		conn = new SqlConnection(connString);
		//		cmd = new SqlCommand("select * from Provider_Staging", conn);
		//		conn.Open();

		//		SqlDataReader dr = cmd.ExecuteReader();

		//		while (dr.Read())
		//		{
		//			row = new ProviderStaging();

		//			row.AddressAddressLine1 = Nullable.Equals(dr["Address/AddressLine1"], null) ? null : dr["Address/AddressLine1"].ToString();
		//			row.AddressAddressLine2 = Nullable.Equals(dr["Address/AddressLine2"], null) ? null : dr["Address/AddressLine2"].ToString();
		//			row.AddressState = Nullable.Equals(dr["Address/State"], null) ? null : dr["Address/State"].ToString();
		//			row.AddressCity = Nullable.Equals(dr["Address/City"], null) ? null : dr["Address/City"].ToString();
		//			row.AddressZipCode = float.Parse(Nullable.Equals(dr["Address/ZipCode"], null) ? "0" : dr["Address/ZipCode"].ToString());
		//			row.AddressExtZipCode = float.Parse(Nullable.Equals(dr["Address/ExtZipCode"], null) ? "0" : dr["Address/ExtZipCode"].ToString());
		//			stagingdata.Add(row);
		//		}

		//		conn.Close();
		//	}
		//	catch (Exception ex)
		//	{
		//		Console.WriteLine(ex.StackTrace);
		//	}


		//	return stagingdata;
		//}

		//public List<ProviderStaging> GetProviderRenderingAddressFromStaging()
		//{
		//	List<ProviderStaging> stagingdata = new List<ProviderStaging>();
		//	ProviderStaging row;

		//	try
		//	{
		//		conn = new SqlConnection(connString);
		//		cmd = new SqlCommand("select * from Provider_Staging", conn);
		//		conn.Open();

		//		SqlDataReader dr = cmd.ExecuteReader();

		//		while (dr.Read())
		//		{
		//			row = new ProviderStaging();
		//			row.RenderingAddressLine1 = Nullable.Equals(dr["RenderingAddress/AddressLine1"], null) ? null : dr["RenderingAddress/AddressLine1"].ToString();
		//			row.RenderingAddressLine2 = Nullable.Equals(dr["RenderingAddress/AddressLine2"], null) ? null : dr["RenderingAddress/AddressLine2"].ToString();
		//			row.RenderingState = Nullable.Equals(dr["RenderingAddress/State"], null) ? null : dr["RenderingAddress/State"].ToString();
		//			row.RenderingZipCode = float.Parse(Nullable.Equals(dr["RenderingAddress/ZipCode"], null) ? "0" : dr["RenderingAddress/ZipCode"].ToString());
		//			row.RenderingExtZipCode = Nullable.Equals(dr["RenderingAddress/ExtZipCode"], null) ? null : dr["RenderingAddress/ExtZipCode"].ToString();
		//			//new DateTime(dr["fdf"].ToString());



		//			stagingdata.Add(row);
		//		}

		//		conn.Close();
		//	}
		//	catch (Exception ex)
		//	{
		//		Console.WriteLine(ex.StackTrace);
		//	}


		//	return stagingdata;
		//}




		public bool InsertProviderData(List<ProviderStaging> stagingdata)
		{
			List<Provider> providerdata = new List<Provider>();
			List<string> clusterGrpId=new List<string>();
			Provider providerrow;
			foreach (ProviderStaging row in stagingdata)
			{
				if (!clusterGrpId.Contains(row.Cluster))
				{
					providerrow = new Provider();
					providerrow.ProviderClusterGroupId = row.Cluster;
					providerrow.Status = 0;
					providerdata.Add(providerrow);
					clusterGrpId.Add( row.Cluster);
				}
			}

			try
			{
				conn = new SqlConnection(connString);
			
				conn.Open();

				foreach (Provider row in providerdata)
				{
					cmd = new SqlCommand(String.Format("insert into Provider(ProviderClusterGroupId,Status) values('{0}',{1})", row.ProviderClusterGroupId,row.Status), conn);
					cmd.ExecuteNonQuery();
				}

				conn.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				return false;
			}

			return true;
		}

		private int GetProviderId(string clusterId)
		{

			try
			{
				conn = new SqlConnection(connString);

				conn.Open();

				
					cmd = new SqlCommand(String.Format("select ProviderId from Provider where ProviderClusterGroupId='{0}'", clusterId.Trim()), conn);
				 SqlDataReader dr=	cmd.ExecuteReader();

				int providerid = 0;
					while (dr.Read()) {
					providerid = int.Parse(dr["ProviderId"].ToString());
				}

				conn.Close();
				return providerid;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				return 0;
			}
			
		}

		private int GetAssociatedProviderId(string firstname, string providerid)
		{

			try
			{
				conn = new SqlConnection(connString);

				conn.Open();


				cmd = new SqlCommand(String.Format("select AssociatedProviderId from AssociatedProviders where FirstName='{0}' and ProviderId = {1}", firstname,providerid), conn);
				SqlDataReader dr = cmd.ExecuteReader();

				int associatedProviderId = 0;
				while (dr.Read())
				{
					associatedProviderId = int.Parse(dr["AssociatedProviderId"].ToString());
				}

				conn.Close();
				return associatedProviderId;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				return 0;
			}

		}

		

		public bool InsertAssosiatedProvidersData(List<ProviderStaging> stagingdata)
		{
			List<AssociatedProviders> AssociatedTabledata = new List<AssociatedProviders>();
			

			
			AssociatedProviders assrow;
			foreach (ProviderStaging row in stagingdata)
			{
				assrow = new AssociatedProviders();
				assrow.ProviderId = GetProviderId(row.Cluster);
				assrow.FirstName = row.FirstName;
				assrow.LastName = row.LastName;
				assrow.Title = row.Title;
				assrow.MiddleInitial = row.MiddleInitial;
				AssociatedTabledata.Add(assrow);
			}

			try
			{
				conn = new SqlConnection(connString);

				conn.Open();

				foreach (AssociatedProviders assosiatedTablerow in AssociatedTabledata)
				{
					cmd = new SqlCommand(String.Format("insert into AssociatedProviders(ProviderId,FirstName,LastName,Title,MiddleInitial) values({0},'{1}','{2}','{3}','{4}')", assosiatedTablerow.ProviderId,assosiatedTablerow.FirstName.Trim(),assosiatedTablerow.LastName.Trim(),assosiatedTablerow.Title.Trim(),assosiatedTablerow.MiddleInitial.Trim()), conn);
					cmd.ExecuteNonQuery();
				}

				conn.Close();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				return false;
			}

			return true;
		}


		public bool InsertTinNumbers(List<ProviderStaging> stagingdata)
		{
			List<ProviderTin> ProviderTinTabledata = new List<ProviderTin>();

			ProviderTin ProviderTinrow;
			foreach (ProviderStaging row in stagingdata)
			{

				ProviderTinrow = new ProviderTin();
				int providerId = GetProviderId(row.Cluster);
				ProviderTinrow.TinNumber = row.TIN;

				ProviderTinrow.AssociatedProviderId = GetAssociatedProviderId(row.FirstName, providerId.ToString());

				ProviderTinTabledata.Add(ProviderTinrow);
			}

			try
			{
				conn = new SqlConnection(connString);

				conn.Open();

				foreach (ProviderTin ProviderTinTablerow in ProviderTinTabledata)
				{
					cmd = new SqlCommand(String.Format("insert into ProviderTin(AssociatedProviderId,TinNumber) values({0},'{1}')", ProviderTinTablerow.AssociatedProviderId, ProviderTinTablerow.TinNumber), conn);
					cmd.ExecuteNonQuery();
				}

				conn.Close();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				return false;
			}

			
		}


		private int GetStateProvinenceId(string statecode)
		{
			try
			{
				conn = new SqlConnection(connString);

				conn.Open();


				cmd = new SqlCommand(String.Format("select StateProvinceId from StateProvince where Code='{0}'", statecode), conn);
				SqlDataReader dr = cmd.ExecuteReader();

				int StateProvinceId = 0;
				while (dr.Read())
				{
					StateProvinceId = int.Parse(dr["StateProvinceId"].ToString());
				}

				conn.Close();
				return StateProvinceId;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				return 0;
			}
		}

		public bool InsertProviderAddress(List<ProviderStaging> stagingdata)
		{
			List<ProviderAddress> addresstable = new List<ProviderAddress>();
			ProviderAddress addressrow;

			foreach (ProviderStaging row in stagingdata)
			{
				addressrow = new ProviderAddress();
				addressrow.Address1 = row.AddressAddressLine1;
				addressrow.Address2 = row.AddressAddressLine2;
				addressrow.AddressTypeId = (int)AddressType.Billing;
				addressrow.City = row.AddressCity;
				addressrow.Zip = row.AddressZipCode;
				
				addressrow.StateProvinceId = GetStateProvinenceId(row.AddressState);
				addresstable.Add(addressrow);
			}

		
			foreach (ProviderStaging row in stagingdata)
			{
				addressrow = new ProviderAddress();
				addressrow.Address1 = row.RenderingAddressLine1;
				addressrow.Address2 = row.RenderingAddressLine2;
				addressrow.AddressTypeId = (int)AddressType.Rendering;
				addressrow.Zip = row.RenderingZipCode;
				addressrow.StateProvinceId = GetStateProvinenceId(row.RenderingState);
				addresstable.Add(addressrow);

			}
			try
			{
				conn = new SqlConnection(connString);

				conn.Open();

				foreach (ProviderAddress addresstablerow in addresstable)
				{
					cmd = new SqlCommand(String.Format("insert into ProviderAddress(AddressTypeId,Address1,Address2,City,Zip,StatePovinceId) values({0},'{1}','{2}','{3}',{4},{5})", addresstablerow.AddressTypeId,addresstablerow.Address1,addresstablerow.Address2,addresstablerow.City,addresstablerow.Zip,addresstablerow.StateProvinceId), conn);
					cmd.ExecuteNonQuery();
				}

				conn.Close();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				return false;
			}

			

		}


		private int GetAddressId(string address1)
		{
			try
			{
				conn = new SqlConnection(connString);

				conn.Open();


				cmd = new SqlCommand(String.Format("select AddressId from ProviderAddress where Address1='{0}'", address1), conn);
				SqlDataReader dr = cmd.ExecuteReader();

				int AddressId = 0;
				while (dr.Read())
				{
					AddressId = Convert.ToInt32(dr["AddressId"].ToString());
				}

				conn.Close();
				return AddressId;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				return 0;
			}

			
		}

		public bool InsertContact(List<ProviderStaging> stagingdata)
		{
			List<Contact> contacttable = new List<Contact>();
			Contact contactrow;
			int AddressId;
			foreach (ProviderStaging row in stagingdata)
			{
				contactrow = new Contact();
				string providerId = GetProviderId(row.Cluster).ToString();
				contactrow.AssociatedProvinceId = GetAssociatedProviderId(row.FirstName, providerId);
				contactrow.AddressTypeId= (int)AddressType.Rendering;
				contactrow.ContactPersonId = 0;
				 AddressId = GetAddressId(row.RenderingAddressLine1);
				if (AddressId == 0) continue;
				contactrow.AddressId = AddressId;
				contacttable.Add(contactrow);
			}

			foreach (ProviderStaging row in stagingdata)
			{
				contactrow = new Contact();
				string providerId = GetProviderId(row.Cluster).ToString();
				contactrow.AssociatedProvinceId = GetAssociatedProviderId(row.FirstName, providerId);
				contactrow.AddressTypeId = (int)AddressType.Billing;
				contactrow.ContactPersonId = 0;
				AddressId = GetAddressId(row.AddressAddressLine1);
				if (AddressId == 0) continue;
				contactrow.AddressId = AddressId;
				contacttable.Add(contactrow);
			}

			try
			{
				conn = new SqlConnection(connString);

				conn.Open();

				foreach (Contact contacttablerow in contacttable)
				{
					cmd = new SqlCommand(String.Format("insert into Contact(AddressTypeId,AssociatedProviderId,AddressId,ContactPersonId) values({0},{1},{2},{3})", contacttablerow.AddressTypeId,contacttablerow.AssociatedProvinceId,contacttablerow.AddressId,contacttablerow.ContactPersonId), conn);
					cmd.ExecuteNonQuery();
				}

				conn.Close();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.StackTrace);
				return false;
			}
		}
	}
}
