using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;

namespace Projekt_LOL
{
    public partial class Form1 : Form
    {
        WebClient client = new WebClient();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string content = client.DownloadString("https://eune.api.pvp.net/api/lol/eune/v1.4/summoner/by-name/Klekot56,Mitronus,Hablarox?api_key=f4d10937-bd33-42ac-80ef-62290e4755bf");
            richTextBox1.Text = richTextBox1.Text + content;
            Dictionary<string, Gracz> ListaGraczy = JsonConvert.DeserializeObject<Dictionary<string, Gracz>>(content);

        
            string content2 = client.DownloadString("https://eune.api.pvp.net/api/lol/eune/v1.3/game/by-summoner/47719350/recent?api_key=f4d10937-bd33-42ac-80ef-62290e4755bf");
            ListaOstatnichGierGracza ostatnieGry = JsonConvert.DeserializeObject<ListaOstatnichGierGracza>(content2);
            richTextBox1.Text = richTextBox1.Text +"\n"+ content2;        
        }
    }
}
