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

        private void buttonAktualizujGry_Click(object sender, EventArgs e)
        {
            BazaDataContext baza = new BazaDataContext();

            foreach(Gracze gracz in baza.Graczes)
            {
                string grystring = client.DownloadString("https://" + gracz.Regiony.name + ".api.pvp.net/api/lol/" + gracz.Regiony.name + "/v1.3/game/by-summoner/"+gracz.Id+"/recent?api_key=f4d10937-bd33-42ac-80ef-62290e4755bf");
                ListaGierJson ostatnieGry = JsonConvert.DeserializeObject<ListaGierJson>(grystring);

                foreach(GraJson gra in ostatnieGry.games)
                {
                    IkonyPrzedmiotow ikona1 = new IkonyPrzedmiotow
                    {
                        itemId= gra.stats.item1,
                    };

                    if (baza.IkonyPrzedmiotows.Contains(ikona1) == false && ikona1.itemId!=0)
                    {
                        client.DownloadFile("http://ddragon.leagueoflegends.com/cdn/5.2.1/img/item/" + ikona1.itemId + ".png", ikona1.itemId + ".png");
                        ikona1.ikona = ikona1.itemId + ".png";
                        baza.IkonyPrzedmiotows.InsertOnSubmit(ikona1);
                    }

                    IkonyPrzedmiotow ikona2 = new IkonyPrzedmiotow
                    {
                        itemId = gra.stats.item2,
                    };

                    if (baza.IkonyPrzedmiotows.Contains(ikona2) == false && ikona2.itemId!=0)
                    {
                        client.DownloadFile("http://ddragon.leagueoflegends.com/cdn/5.2.1/img/item/" + ikona2.itemId + ".png", ikona2.itemId + ".png");
                        ikona2.ikona = ikona2.itemId + ".png";
                        baza.IkonyPrzedmiotows.InsertOnSubmit(ikona2);
                    }

                    IkonyPrzedmiotow ikona3 = new IkonyPrzedmiotow
                    {
                        itemId = gra.stats.item3,
                    };

                    if (baza.IkonyPrzedmiotows.Contains(ikona3) == false && ikona3.itemId != 0)
                    {
                        client.DownloadFile("http://ddragon.leagueoflegends.com/cdn/5.2.1/img/item/" + ikona3.itemId + ".png", ikona3.itemId + ".png");
                        ikona3.ikona = ikona3.itemId + ".png";
                        baza.IkonyPrzedmiotows.InsertOnSubmit(ikona3);
                    }

                    IkonyPrzedmiotow ikona4 = new IkonyPrzedmiotow
                    {
                        itemId = gra.stats.item4,
                    };

                    if (baza.IkonyPrzedmiotows.Contains(ikona4) == false && ikona4.itemId != 0)
                    {
                        client.DownloadFile("http://ddragon.leagueoflegends.com/cdn/5.2.1/img/item/" + ikona4.itemId + ".png", ikona4.itemId + ".png");
                        ikona4.ikona = ikona4.itemId + ".png";
                        baza.IkonyPrzedmiotows.InsertOnSubmit(ikona4);
                    }

                    IkonyPrzedmiotow ikona5 = new IkonyPrzedmiotow
                    {
                        itemId = gra.stats.item5,
                    };

                    if (baza.IkonyPrzedmiotows.Contains(ikona5) == false && ikona5.itemId != 0)
                    {
                        client.DownloadFile("http://ddragon.leagueoflegends.com/cdn/5.2.1/img/item/" + ikona5.itemId + ".png", ikona5.itemId + ".png");
                        ikona5.ikona = ikona5.itemId + ".png";
                        baza.IkonyPrzedmiotows.InsertOnSubmit(ikona5);
                    }

                    IkonyPrzedmiotow ikona6 = new IkonyPrzedmiotow
                    {
                        itemId = gra.stats.item6,
                    };

                    if (baza.IkonyPrzedmiotows.Contains(ikona6) == false && ikona6.itemId != 0)
                    {
                        client.DownloadFile("http://ddragon.leagueoflegends.com/cdn/5.2.1/img/item/" + ikona6.itemId + ".png", ikona6.itemId + ".png");
                        ikona6.ikona = ikona6.itemId + ".png";
                        baza.IkonyPrzedmiotows.InsertOnSubmit(ikona6);
                    }

                    Postacie postac = new Postacie
                    {
                        championId = gra.championId,
                    };

                    if(baza.Postacies.Contains(postac) == false)
                    {
                        string postacstring = client.DownloadString("https://global.api.pvp.net/api/lol/static-data/eune/v1.2/champion/" + postac.championId + "?api_key=f4d10937-bd33-42ac-80ef-62290e4755bf");
                        ChampionJson postacJson = JsonConvert.DeserializeObject<ChampionJson>(postacstring);
                        postac.name = postacJson.key;
                        client.DownloadFile("http://ddragon.leagueoflegends.com/cdn/5.2.1/img/champion/" + postac.name + ".png", postac.name + ".png");
                        postac.ikona = postac.name + ".png";
                        baza.Postacies.InsertOnSubmit(postac);
                    }
                }
            }
        }
    }
}
