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
            // TODO: This line of code loads data into the 'bazaDataSet.Regiony' table. You can move, or remove it, as needed.
            this.regionyTableAdapter.Fill(this.bazaDataSet.Regiony);

        }

        private void buttonDodajGracza_Click(object sender, EventArgs e)
        {
            string content = client.DownloadString("https://"+comboBoxDodajGracza.Text+".api.pvp.net/api/lol/" + comboBoxDodajGracza.Text + "/v1.4/summoner/by-name/" + textBoxDodajGracza.Text + "?api_key=f4d10937-bd33-42ac-80ef-62290e4755bf");
            Dictionary<string, GraczJson> ListaGraczy = JsonConvert.DeserializeObject<Dictionary<string, GraczJson>>(content);

            BazaDataContext baza = new BazaDataContext();


            IkonyGraczy ikona = new IkonyGraczy
            {
                profileIconId = ListaGraczy[textBoxDodajGracza.Text.Replace(" ", "")].profileIconId,
            };

            if (baza.IkonyGraczies.Contains(ikona)==false)
            {
                client.DownloadFile("http://ddragon.leagueoflegends.com/cdn/5.2.1/img/profileicon/" + ikona.profileIconId + ".png",ikona.profileIconId + ".png");
                ikona.ikona = ikona.profileIconId + ".png";
                baza.IkonyGraczies.InsertOnSubmit(ikona);
            }

            Gracze gracz = new Gracze()
            {
                Id = ListaGraczy[textBoxDodajGracza.Text.Replace(" ","")].id,
                name = ListaGraczy[textBoxDodajGracza.Text.Replace(" ", "")].name,
                profileIconId = ListaGraczy[textBoxDodajGracza.Text.Replace(" ", "")].profileIconId,
                revisionDate = ListaGraczy[textBoxDodajGracza.Text.Replace(" ", "")].revisionDate,
                summonerLevel = ListaGraczy[textBoxDodajGracza.Text.Replace(" ", "")].summonerLevel,
                idRegionu = (int)comboBoxDodajGracza.SelectedValue,
            };
                       

            baza.Graczes.InsertOnSubmit(gracz);
            baza.SubmitChanges();
        }
    }
}
