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
    public partial class checkB_liste : Form
    {
        public checkB_liste()
        {
            InitializeComponent();
            textBox1.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkB_liste_Load(object sender, EventArgs e)
        {

        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            /*label1.Visible = true;
            panel1.Visible = false;
            panel1.Enabled = false;*/
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            /*label1.Visible = false;
            panel1.Visible = true;
            panel1.Enabled = true;
            textBox1.Focus();*/
        }

        private void checkBox1_Enter(object sender, EventArgs e)
        {
            checkBox1.BackColor = Color.Green;
        }

        private void checkBox1_Leave(object sender, EventArgs e)
        {
            checkBox1.BackColor = Color.White;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_Enter(object sender, EventArgs e)
        {
            checkBox2.BackColor = Color.Green;
        }

        private void checkBox2_Leave(object sender, EventArgs e)
        {
            checkBox2.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                t.Show("Pročitajte zadatak!", textBox1, 10000);
                textBox1.Focus();
            }
            else if (string.IsNullOrEmpty(comboBox1.Text))
            {
                t.Show("Pročitajte zadatak!", comboBox1, 10000);
                comboBox1.DroppedDown = true;
                comboBox1.Focus();
            }
            else if (checkBox1.Checked)
            {
                t.Show("Pročitajte zadatak!", checkBox1, 10000);
                checkBox1.Focus();
            }
            else if (!checkBox2.Checked)
            {
                t.Show("Pročitajte zadatak!", checkBox2, 10000);
                checkBox2.Focus();
            }
            else
            {
                MessageBox.Show("Čestitamo, završili ste tutorijal!");
                this.Close();
            }



        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            comboBox1.DroppedDown = true;
        }
    }
}
