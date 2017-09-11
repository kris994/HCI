using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mapa_Kafića
{
    public partial class infoToolTip : Form
    {
        public infoToolTip()
        {
            InitializeComponent();
        }

        private void infoToolTip_Load(object sender, EventArgs e)
        {

        }

        private void infoToolTip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                //Tab t = new Tab();
                checkB_liste t = new checkB_liste();
                t.ShowDialog(this);
                this.Close();
            }
        }
    }
}
