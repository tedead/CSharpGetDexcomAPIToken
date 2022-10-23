using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Dexcom
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                //Copied from Developer Dexcom API site.
                //This retrieves a new token
                List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));
                postData.Add(new KeyValuePair<string, string>("code", "AUTHORIZATION CODE HERE"));
                postData.Add(new KeyValuePair<string, string>("redirect_uri", "http://localhost"));
                postData.Add(new KeyValuePair<string, string>("client_id", "CLIENT ID HERE"));
                postData.Add(new KeyValuePair<string, string>("client_secret", "CLIENT SECRET HERE"));

                var request = await client.PostAsync("https://sandbox-api.dexcom.com/v2/oauth2/token", new FormUrlEncodedContent(postData));
                var response = await request.Content.ReadAsStringAsync();

                Console.WriteLine(response);
            }
        }
    }
}
