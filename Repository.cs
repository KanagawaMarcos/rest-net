using System;
using System.Runtime.Serialization;

namespace WebAPIClient
{
	[DataContract(Name="Repo")]
	public class Repository
	{
		[DataContract(Name="name")]
		public string Name { get; set; };
	}
}
