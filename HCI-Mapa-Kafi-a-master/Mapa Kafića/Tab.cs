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
    public partial class Tab : Form
    {
        public Tab()
        {
            InitializeComponent();
            label1.Visible = false; 

        }

        private void Tab_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Tab_KeyDown);
        }

        private void Tab_MouseHover(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = false;
            pictureBox1.Visible = false;
            textBox1.Enabled = false;
            button1.Enabled = false;
        }

        private void Tab_MouseLeave(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = true;
            pictureBox1.Visible = true;
            textBox1.Enabled = true;
            button1.Enabled = true;
            textBox1.Focus();

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = false;
            pictureBox1.Visible = false;
            textBox1.Enabled = false;
            button1.Enabled = false;
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = false;
            pictureBox1.Visible = false;
            textBox1.Enabled = false;
            button1.Enabled = false;
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = false;
            pictureBox1.Visible = false;
            textBox1.Enabled = false;
            button1.Enabled = false;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = false;
            pictureBox1.Visible = false;
            textBox1.Enabled = false;
            button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                ToolTip t = new ToolTip();
                t.Show("Sve je u redu, još jednom pročitajte zadatak!", textBox1, 10000);
                textBox1.Focus();
                return;
            }
            infoToolTip tt = new infoToolTip();
            tt.ShowDialog(this);
            this.Close();
        }

        private void Tab_KeyDown(object sender, KeyEventArgs e)
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
