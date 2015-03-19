using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_LOL
{
    public partial class UserControlGra : UserControl
    {
        private Gry gry;

        public Gry GryDane
        {
            get {return gry;}
        }
        public UserControlGra()
        {
            InitializeComponent();
            this.gry = new Gry();

            textBox1.Text = gry.assists + " " + gry.numDeaths + " " + gry.championsKilled;
        }
        public UserControlGra(Gry gra)
        {
            InitializeComponent();
            this.gry = new Gry();
            textBox1.DataBindings.Add(new Binding("Text", gra, "gameId".ToString()));
            textBox2.DataBindings.Add(new Binding("Text", gra, "summonerId".ToString()));
            textBox3.DataBindings.Add(new Binding("Text", gra, "championId".ToString()));
            textBox4.DataBindings.Add(new Binding("Text", gra, "spell1".ToString()));
            textBox5.DataBindings.Add(new Binding("Text", gra, "spell2".ToString()));
            textBox10.DataBindings.Add(new Binding("Text", gra, "ipEarned".ToString()));
            textBox9.DataBindings.Add(new Binding("Text", gra, "createDate".ToString()));
            textBox8.DataBindings.Add(new Binding("Text", gra, "level".ToString()));
            textBox7.DataBindings.Add(new Binding("Text", gra, "goldEarned".ToString()));
            textBox6.DataBindings.Add(new Binding("Text", gra, "numDeaths".ToString()));
            textBox11.DataBindings.Add(new Binding("Text", gra, "championsKilled".ToString()));
            textBox12.DataBindings.Add(new Binding("Text", gra, "assists".ToString()));

        }


    }
}
