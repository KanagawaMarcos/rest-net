using System;
using System.Runtime.Serialization;
using System.Globalization;

namespace WebAPIClient
{
    [DataContract(Name="CostumerCall")]
    public class CostumerCall
   {
       [DataMember]
       public int Id {get; set;}
       [DataMember]
       public string Date {get; set;}
       [DataMember]
       public string Name {get;set;}
       [DataMember]
       public string Email {get;set;}
       [DataMember]
       public string Phone {get;set;}
       [DataMember]
       public string Time {get;set;}
       	[IgnoreDataMember]
		public DateTime DateConverted
		{
			get
			{
				return DateTime.ParseExact(Date, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
			}
		}
       
   } 
}