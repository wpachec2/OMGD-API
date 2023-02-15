using System;
using System.Net;
using Newtonsoft.Json;

namespace OMGD_API.Models
{
	public class MovieDAL
	{
        public static Movie GetMovie(string input)
        {
            //Setup
            string url = $"https://www.omdbapi.com/?t={input}&apikey=f7c39b2c";

            //Request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Convert it to JSON
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            //Convert to C#
            Movie result = JsonConvert.DeserializeObject<Movie>(JSON);
            return result;
        }
    }
}

