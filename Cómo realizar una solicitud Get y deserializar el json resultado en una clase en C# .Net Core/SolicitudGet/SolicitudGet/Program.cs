//using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Text.Json;

namespace SolicitudGet
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string url = "https://jsonplaceholder.typicode.com/todos/1";
            string respuesta = GetHttp(url);

            RootObject obj = JsonSerializer.Deserialize<RootObject>(respuesta);  //JsonConvert.DeserializeObject<RootObject>(respuesta);
        }

        public static string GetHttp(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            return reader.ReadToEnd().Trim();
        }

    }

    public class RootObject
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
    }
}
