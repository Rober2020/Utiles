using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetJsonGrid
{
    public partial class Form1 : Form
    {
        string url = "https://jsonplaceholder.typicode.com/posts";
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string respuesta = await GetHttp();
            List<PostViewModel> lst = JsonConvert.DeserializeObject<List<PostViewModel>>(respuesta);
            dataGridView1.DataSource = lst;
        }

        public async Task<string> GetHttp()
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            return await reader.ReadToEndAsync();
        }
    }
}
