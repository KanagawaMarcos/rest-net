using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;

namespace WebAPIClient
{
    class Program
    {
		private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
		{
			List<CostumerCall> costumersToCall = GetNewPosibleCostumersContact().Result;
			foreach (var costumer in costumersToCall)
			{
				Console.WriteLine(costumer.Id);
				Console.WriteLine(costumer.Date);
				Console.WriteLine(costumer.Name);
				Console.WriteLine(costumer.Email);
				Console.WriteLine(costumer.Phone);
				Console.WriteLine(costumer.Time);			
			}
    	}

		private static async Task<List<CostumerCall>> GetNewPosibleCostumersContact ()
		{
			HttpClient client = new HttpClient();
			var serializer = new DataContractJsonSerializer(typeof(List<CostumerCall>));
			
			var response = client.GetStreamAsync("http://ceapebrasil.org.br/api/wecallyou/0,1/"+GetMd5Key());
			List<CostumerCall> costumersToCall = serializer.ReadObject(await response) as List<CostumerCall>;
			Console.WriteLine(costumersToCall[0].Name);
			return costumersToCall;
		}

		private static string GetMd5Key()
		{
			string key = System.IO.File.ReadAllText("md5.key");
			return key;
		}

    }
}
