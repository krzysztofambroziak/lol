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
            Dictionary<string, GraczJson> ListaGraczy = JsonConvert.DeserializeObject<Dictionary<string, GraczJson>>(content);

        
            string content2 = client.DownloadString("https://eune.api.pvp.net/api/lol/eune/v1.3/game/by-summoner/47719350/recent?api_key=f4d10937-bd33-42ac-80ef-62290e4755bf");
            ListaGierJson ostatnieGry = JsonConvert.DeserializeObject<ListaGierJson>(content2);
            richTextBox1.Text = richTextBox1.Text +"\n"+ content2;        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bazaDataSet1.Regiony' table. You can move, or remove it, as needed.
            this.regionyTableAdapter1.Fill(this.bazaDataSet1.Regiony);
        }

        private void buttonDodajGracza_Click(object sender, EventArgs e)
        {
            string content = client.DownloadString("https://eune.api.pvp.net/api/lol/"+comboBoxDodajGracza.Text+"/v1.4/summoner/by-name/"+textBoxDodajGracza.Text+"?api_key=f4d10937-bd33-42ac-80ef-62290e4755bf");
            Dictionary<string, GraczJson> ListaGraczy = JsonConvert.DeserializeObject<Dictionary<string, GraczJson>>(content);
            BazaDataContext baza = new BazaDataContext();
            Gracze gracz = new Gracze()
            {
                Id = ListaGraczy[textBoxDodajGracza.Text].id,
                name = ListaGraczy[textBoxDodajGracza.Text].name
            };
            //gracz.Id=ListaGraczy[textBoxDodajGracza.Text].id;
//gracz.name=ListaGraczy[textBoxDodajGracza.Text].name;
//gracz.revisionDate=ListaGraczy[textBoxDodajGracza.Text].revisionDate;
         //   gracz.summonerLevel=ListaGraczy[textBoxDodajGracza.Text].summonerLevel;
//gracz.profileIconId=ListaGraczy[textBoxDodajGracza.Text].profileIconId;
           // gracz.idRegionu = comboBoxDodajGracza.SelectedValue
            baza.Graczes.InsertOnSubmit(gracz);
            baza.SubmitChanges();
        }
    }
}
