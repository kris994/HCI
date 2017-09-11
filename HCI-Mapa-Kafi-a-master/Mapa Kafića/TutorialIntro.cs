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
    public partial class TutorialIntro : Form
    {
        public TutorialIntro()
        {
            InitializeComponent();
            Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(TutorialIntro_KeyDown);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
                this.Close();
        }

        private void TutorialIntro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                Tab t = new Tab();
                t.ShowDialog(this);
                this.Close();
            }
        }

        private void TutorialIntro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                // the user pressed the F1 key
                HelpNavigator navigator = HelpNavigator.TopicId;
                Help.ShowHelp(this, "help.chm", navigator, "273");
            }
        }
    }
}
