using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_LOL
{
    public partial class Staty : Form
    {
        private Gracze gracz;
        private Form1 forma;

        public Staty(Form1 forma, Gracze gracz)
        {
            this.forma = forma;
            this.gracz = gracz;
        }

        public void StatyGenerator(Form1 forma, Gracze gracz)
        {
            
            int i = 0;
            Panel panel = GeneratorPanela();
            foreach (Gry gry in gracz.Gries)
            {
                UserControlGra uc = new UserControlGra(gry);
                uc.Location = new Point(20, 10 + (i++) * (uc.Height + 20));
                panel.Controls.Add(uc);
            }
            forma.panel1.Controls.Add(panel);
        }

        private Panel GeneratorPanela()
        {
            Panel panel = new Panel();


            panel.Location = new System.Drawing.Point(1, 9);
            panel.Size = new System.Drawing.Size(forma.panel1.Width - 20, forma.panel1.Height - 20);
            panel.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            panel.AutoScroll = true;
            return panel;   
        }
    }
}
