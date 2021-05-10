using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            Persona oPersona = new Persona() { Nombre = "Rober", Edad = 42 };
            Solicitud<Persona> oSolicitud = new Solicitud<Persona>(oPersona);
            string resultado = oSolicitud.Solicitar(url);

            Carro oCarro = new Carro() { Marca = "landRober", Modelo = "Joy" };
            Solicitud<Carro> oSolicitudCarro = new Solicitud<Carro>(oCarro);
            resultado = oSolicitudCarro.Solicitar(url);
        }

        public class Solicitud<T>
        {
            T data;
            public Solicitud(T data)
            {
                this.data = data;
            }

            public string Solicitar(string url)
            {
                string result = "";
                WebRequest oRequest = WebRequest.Create(url);
                oRequest.Method = "post";
                oRequest.ContentType = "application/json;charset=UTF-8";

                using (var oSW = new StreamWriter(oRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(data);
                    oSW.Write(json);
                    oSW.Flush();
                    oSW.Close();
                }

                WebResponse oResponse = oRequest.GetResponse();
                using(var oSR = new StreamReader(oResponse.GetResponseStream()))
                {
                    result = oSR.ReadToEnd().Trim();
                }

                return result;
            }
        }

        public class Persona
        {
            public string Nombre { get; set; }
            public int Edad { get; set; }
        }

        public class Carro
        {
            public string Marca { get; set; }
            public string Modelo { get; set; }
        }
    }
}
