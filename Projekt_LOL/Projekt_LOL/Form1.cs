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
///////////////////////////////////SCIEZKA LOKALNA/////////////////////
namespace Projekt_LOL
{
    public partial class Form1 : Form
    {
        WebClient client = new WebClient();
        public Form1()
        {
            InitializeComponent();
            
        }
      /*  private void button1_Click(object sender, EventArgs e)
        {
            string content = client.DownloadString("https://eune.api.pvp.net/api/lol/eune/v1.4/summoner/by-name/Klekot56,Mitronus,Hablarox?api_key=f4d10937-bd33-42ac-80ef-62290e4755bf");
            richTextBox1.Text = richTextBox1.Text + content;
            Dictionary<string, GraczJson> ListaGraczy = JsonConvert.DeserializeObject<Dictionary<string, GraczJson>>(content);

        
            string content2 = client.DownloadString("https://eune.api.pvp.net/api/lol/eune/v1.3/game/by-summoner/47719350/recent?api_key=f4d10937-bd33-42ac-80ef-62290e4755bf");
            ListaGierJson ostatnieGry = JsonConvert.DeserializeObject<ListaGierJson>(content2);
            richTextBox1.Text = richTextBox1.Text +"\n"+ content2;        
        }*/

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bazaDataSet.Regiony' table. You can move, or remove it, as needed.
            this.regionyTableAdapter.Fill(this.bazaDataSet.Regiony);

        }

        private void buttonDodajGracza_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string content = client.DownloadString("https://"+comboBoxDodajGracza.Text+".api.pvp.net/api/lol/" + comboBoxDodajGracza.Text + "/v1.4/summoner/by-name/" + textBoxDodajGracza.Text + "?api_key=f4d10937-bd33-42ac-80ef-62290e4755bf");
            Dictionary<string, GraczJson> ListaGraczy = JsonConvert.DeserializeObject<Dictionary<string, GraczJson>>(content);

            BazaDataContext baza = new BazaDataContext();

            Gracze graczsprawdz = new Gracze()
            {
                Id = ListaGraczy[textBoxDodajGracza.Text.Replace(" ", "")].id,
            };

            if(baza.Graczes.Contains(graczsprawdz))
            {
                textBoxDodajGracza.Text = "pograny gracz juz istnieje";
            }
            else
            {

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

                foreach(Gracze g in baza.Graczes)
                {
                    listBox1.Items.Add(g);
                }
                listBox1.DisplayMember = "name";


            }
        }

        private void buttonAktualizujGry_Click(object sender, EventArgs e)
        {
            BazaDataContext baza = new BazaDataContext();

            foreach(Gracze gracz in baza.Graczes)
            {
                string grystring = client.DownloadString("https://" + gracz.Regiony.name + ".api.pvp.net/api/lol/" + gracz.Regiony.name + "/v1.3/game/by-summoner/"+gracz.Id+"/recent?api_key=f4d10937-bd33-42ac-80ef-62290e4755bf");
                ListaGierJson ostatnieGry = JsonConvert.DeserializeObject<ListaGierJson>(grystring);

                foreach (GraJson gra in ostatnieGry.games)
                {
                    if (gra.invalid == false && gra.gameMode == "CLASSIC" && gra.gameType == "MATCHED_GAME" && (gra.subType == "RANKED_SOLO_5x5" || gra.subType == "RANKED_PREMADE_5x5"))
                    {
                        IkonyPrzedmiotow ikona0 = new IkonyPrzedmiotow
                        {
                            itemId = gra.stats.item0,
                        };

                        if (baza.IkonyPrzedmiotows.Contains(ikona0) == false && ikona0.itemId != 0)
                        {
                            client.DownloadFile("http://ddragon.leagueoflegends.com/cdn/5.2.1/img/item/" + ikona0.itemId + ".png", ikona0.itemId + ".png");
                            ikona0.ikona = ikona0.itemId + ".png";
                            baza.IkonyPrzedmiotows.InsertOnSubmit(ikona0);
                        }

                        IkonyPrzedmiotow ikona1 = new IkonyPrzedmiotow
                        {
                            itemId = gra.stats.item1,
                        };

                        if (baza.IkonyPrzedmiotows.Contains(ikona1) == false && ikona1.itemId != 0)
                        {
                            client.DownloadFile("http://ddragon.leagueoflegends.com/cdn/5.2.1/img/item/" + ikona1.itemId + ".png", ikona1.itemId + ".png");
                            ikona1.ikona = ikona1.itemId + ".png";
                            baza.IkonyPrzedmiotows.InsertOnSubmit(ikona1);
                        }

                        IkonyPrzedmiotow ikona2 = new IkonyPrzedmiotow
                        {
                            itemId = gra.stats.item2,
                        };

                        if (baza.IkonyPrzedmiotows.Contains(ikona2) == false && ikona2.itemId != 0)
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

                        if (baza.Postacies.Contains(postac) == false)
                        {
                            string postacstring = client.DownloadString("https://global.api.pvp.net/api/lol/static-data/eune/v1.2/champion/" + postac.championId + "?api_key=f4d10937-bd33-42ac-80ef-62290e4755bf");
                            ChampionJson postacJson = JsonConvert.DeserializeObject<ChampionJson>(postacstring);
                            postac.name = postacJson.key;
                            client.DownloadFile("http://ddragon.leagueoflegends.com/cdn/5.2.1/img/champion/" + postac.name + ".png", postac.name + ".png");
                            postac.ikona = postac.name + ".png";
                            baza.Postacies.InsertOnSubmit(postac);
                        }

                        Gry dodawanagra = new Gry()
                        {
                            gameId = gra.gameId,
                            summonerId = ostatnieGry.summonerId,
                            championId = gra.championId,
                            spell1 = gra.spell1,
                            spell2 = gra.spell2,
                            ipEarned = gra.ipEarned,
                            createDate = gra.createDate,
                            level = gra.stats.level,
                            goldEarned = gra.stats.goldEarned,
                            numDeaths = gra.stats.numDeaths,
                            minionsKilled = gra.stats.minionsKilled,
                            championsKilled = gra.stats.championsKilled,
                            totalDamageDealt = gra.stats.totalDamageDealt,
                            totalDamageTaken = gra.stats.totalDamageTaken,
                            team = gra.stats.team,
                            win = gra.stats.win,
                            neutralMinionsKilled = gra.stats.neutralMinionsKilled,
                            largestMultiKill = gra.stats.largestMultiKill,
                            physicalDamageDealtPlayer = gra.stats.physicalDamageDealtPlayer,
                            magicDamageDealtPlayer = gra.stats.magicDamageDealtPlayer,
                            physicalDamageTaken = gra.stats.physicalDamageTaken,
                            magicDamageTaken = gra.stats.magicDamageTaken,
                            timePlayed = gra.stats.timePlayed,
                            totalHeal = gra.stats.totalHeal,
                            assists = gra.stats.assists,
                            item0 = gra.stats.item0,
                            item1 = gra.stats.item1,
                            item2 = gra.stats.item2,
                            item3 = gra.stats.item3,
                            item4 = gra.stats.item4,
                            item5 = gra.stats.item5,
                            item6 = gra.stats.item6,
                            sightWardsBought = gra.stats.sightWardsBought,
                            magicDamageDealtToChampions = gra.stats.magicDamageDealtToChampions,
                            physicalDamageDealtToChampions = gra.stats.physicalDamageDealtToChampions,
                            totalDamageDealtToChampions = gra.stats.totalDamageDealtToChampions,
                            trueDamageDealtPlayer = gra.stats.trueDamageDealtPlayer,
                            trueDamageDealtToChampions = gra.stats.trueDamageDealtToChampions,
                            trueDamageTaken = gra.stats.trueDamageTaken,
                            wardKilled = gra.stats.wardKilled,
                            wardPlaced = gra.stats.wardPlaced,
                            totalTimeCrowdControlDealt = gra.stats.totalTimeCrowdControlDealt,
                        };
                        baza.Gries.InsertOnSubmit(dodawanagra);
                        baza.SubmitChanges();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Gracze g in listBox1.SelectedItems)
            {
                Form2 okno = new Form2(g);
                //okno.FormClosed += Form1_FormClosed;
                okno.Show();
            }
         /*
            BazaDataContext baza = new BazaDataContext();
            Gracze g = listBox1.SelectedItem as Gracze;
            Kontrolki generator = new Kontrolki(this);
            var ilosc = baza.Gries.Where(s => s.summonerId == g.Id).Select(a=> a.gameId);
            int iloscc = ilosc.Count();
            groupBox1.Text = g.name;
            generator.GenerowanieButtonow(iloscc, g.name,g.Id);
           */
        }


    }

}

