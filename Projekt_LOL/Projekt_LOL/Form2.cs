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
    public partial class Form2 : Form
    {
        private Gracze gracz;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Gracze gracz)
        {
            InitializeComponent();
            this.gracz = gracz;
            int i = 0;
            foreach (Gry gry in gracz.Gries)
            {
                UserControlGra uc = new UserControlGra(gry);
                uc.Location = new Point(10, 10 + (i++) * (uc.Height + 20));
                this.Controls.Add(uc);
            }
        }
    }
}
