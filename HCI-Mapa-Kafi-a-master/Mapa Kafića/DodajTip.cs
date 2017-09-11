using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;


namespace Mapa_Kafića
{
    public partial class Tip : Form
    {

        bool succes;
        bool uspeh;
        //string fail;
        private string ime;
        public Tip()
        {
            InitializeComponent();
            tipoviTextBox.Focus();
            fillCB();
            izmenaButton.Visible = false;
            izmenaButton.Enabled = false;

            
            
            this.uspeh = true;
            this.succes = true;
        }

        public Tip(String ime)
        {
            InitializeComponent();
            tipoviTextBox.Focus();
            this.ime = ime;
            fillCB();
            dodajTipButton.Enabled = false;
            dodajTipButton.Visible = false;
            SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
            tip.TestConnection();
            DataTable t = tip.GetDataTable("SELECT tip,opis,ikona FROM tip where tip = '"+ime+"'; ");
            tipoviTextBox.Text = t.Rows[0]["tip"].ToString();
            opisTipaTextBox.Text = t.Rows[0]["opis"].ToString();
            ikonaComboBox.Items.Add(t.Rows[0]["ikona"].ToString());
            ikonaComboBox.Text = t.Rows[0]["ikona"].ToString();


        }
        private void fillCB()
        {
            string folder = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + @"\..\..\tipIcons\";
            string filter = "*.png";
            string[] files = Directory.GetFiles(folder, filter);

            foreach (String file in files)
            {
                ikonaComboBox.Items.Add(file);
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tipoviTextBox.Focus();
            tipoviTextBox.Select();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Tip_KeyDown);
        }

        private void dodajTipButton_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(tipoviTextBox.Text))
            {
                tipToolTip.SetToolTip(tipoviTextBox, "Nije unesen naziv tipa.");
                tipToolTip.Show(tipToolTip.GetToolTip(tipoviTextBox), tipoviTextBox, 3000);
                tipoviTextBox.Focus();

            }

            else if (string.IsNullOrEmpty(opisTipaTextBox.Text))
            {
                tipToolTip.SetToolTip(opisTipaTextBox, "Nije unesen opis tipa.");
                tipToolTip.Show(tipToolTip.GetToolTip(opisTipaTextBox), opisTipaTextBox, 3000);
                opisTipaTextBox.Focus();
            }
            else if (ikonaComboBox.SelectedIndex == -1)
            {
                tipToolTip.SetToolTip(ikonaComboBox, "Nije izabrana ni jedna ikona tipa.");
                tipToolTip.Show(tipToolTip.GetToolTip(ikonaComboBox), ikonaComboBox, 3000);
                ikonaComboBox.Select();
                ikonaComboBox.Focus();
            }
            else
            {
                string inputFile = "baza.s3db";
                string dbConnection = String.Format("Data Source={0}", inputFile);
                SQLiteConnection cnn = new SQLiteConnection(dbConnection);
                cnn.Open();

                // Define the SQL Create table statement  
                string createLogTableSQL = "CREATE TABLE IF NOT EXISTS `Tip`" +
                                              "(`id`	INTEGER DEFAULT 0 PRIMARY KEY AUTOINCREMENT," +
                                               "`tip`	TEXT UNIQUE," +
                                               "'opis' TEXT,"
                                              + "'ikona' TEXT"
                                              + ");";

                using (SQLiteTransaction sqlTransaction = cnn.BeginTransaction())
                {
                    // Create the table  
                    SQLiteCommand createCommand = new SQLiteCommand(createLogTableSQL, cnn);
                    createCommand.ExecuteNonQuery();
                    createCommand.Dispose();
                    // Commit the changes into the database  
                    sqlTransaction.Commit();
                } // end using    

                string tip = tipoviTextBox.Text;





                string quary = "SELECT tip FROM Tip where tip ='" + tip.Trim() + "';";
                SQLiteCommand q = new SQLiteCommand(cnn);
                q.CommandText = quary;
                object res = q.ExecuteScalar();
                
                
                if (res != null) 
                {
                    tipToolTip.SetToolTip(tipoviTextBox, "Već tip sa istim imenom.");
                    tipToolTip.Show(tipToolTip.GetToolTip(tipoviTextBox), tipoviTextBox, 3000);
                    tipoviTextBox.Focus();
                }
                
                else
                {


                    try
                    {
                        string sql = "insert into Tip (tip, opis, ikona) values ('" + tip.Trim() + "','" +
                            opisTipaTextBox.Text.Trim() + "','" + ikonaComboBox.Text.Trim() + "')";
                        SQLiteCommand mycommand = new SQLiteCommand(cnn);
                        //proveriti na sajtu
                        //mycommand.Parameters.Add(@name);
                        mycommand.CommandText = sql;
                        int rowsUpdated = mycommand.ExecuteNonQuery();
                        cnn.Close();
                        this.Close();
                    }
                    catch (SQLiteException sl)
                    {
                        sl.ToString();
                        throw;
                    }
                }
                




                if (!uspeh)
                {
                    Tip t = new Tip();
                    t.Show();
                    System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                    ToolTip1.SetToolTip(t.tipoviTextBox, "test");

                }
                else
                {
             
                }


            } 
        }

        private void tipToolTip_Popup(object sender, PopupEventArgs e)
        {
            
        }

        private void Tip_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tipoviTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ikonaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(ikonaComboBox.Text);
        }

        private void izmenaButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(tipoviTextBox.Text))
            {
                tipToolTip.SetToolTip(tipoviTextBox, "Nije unesen naziv tipa.");
                tipToolTip.Show(tipToolTip.GetToolTip(tipoviTextBox), tipoviTextBox, 3000);
                tipoviTextBox.Focus();

            }

            else if (string.IsNullOrEmpty(opisTipaTextBox.Text))
            {
                tipToolTip.SetToolTip(opisTipaTextBox, "Nije unesen opis tipa.");
                tipToolTip.Show(tipToolTip.GetToolTip(opisTipaTextBox), opisTipaTextBox, 3000);
                opisTipaTextBox.Focus();
            }
            else if (ikonaComboBox.SelectedIndex == -1)
            {
                tipToolTip.SetToolTip(ikonaComboBox, "Nije izabrana ni jedna ikona tipa.");
                tipToolTip.Show(tipToolTip.GetToolTip(ikonaComboBox), ikonaComboBox, 3000);
                ikonaComboBox.Select();
                ikonaComboBox.Focus();
            }
            else
            {


                SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
                tip.TestConnection();
                DataTable t = tip.GetDataTable("SELECT tip,opis,ikona FROM tip where tip = '" + ime + "'; ");
                Dictionary<string, string> za_update_lokal = new Dictionary<string, string>();
                Dictionary<string, string> za_update_tip = new Dictionary<string, string>();

                za_update_tip.Add("tip", tipoviTextBox.Text.Trim());
                za_update_tip.Add("opis", opisTipaTextBox.Text.Trim());
                za_update_tip.Add("ikona", ikonaComboBox.Text.Trim());
                tip.Update("Tip", za_update_tip, "tip = '" + ime + "'");



                za_update_lokal.Add("tip", tipoviTextBox.Text.Trim());
                tip.Update("Lokal", za_update_lokal, "tip = '" + ime + "'");

                this.Close();

            }
        }

        private void tipoviTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ToolTip t = new ToolTip();
            if (e.KeyChar == ';')
            {
                //  t.Show("Unet nedozvoljen karakter ; !", this, 3000);

                e.Handled = true;

            }
            else if (e.KeyChar == '"')
            {
                //t.Show("Unet nedozvoljen karakter \" !", this, 3000);
                e.Handled = true;
            }

            else if (e.KeyChar == '\'')
            {
                // t.Show("Unet nedozvoljen karakter \' !", this, 3000);
                e.Handled = true;
            }

            else if (e.KeyChar == '\r')
            {
                e.Handled = true;
            }

            else
            {
                e.Handled = false;
            }
        }

        private void opisTipaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ToolTip t = new ToolTip();
            if (e.KeyChar == ';')
            {
                //  t.Show("Unet nedozvoljen karakter ; !", this, 3000);

                e.Handled = true;

            }
            else if (e.KeyChar == '"')
            {
                //t.Show("Unet nedozvoljen karakter \" !", this, 3000);
                e.Handled = true;
            }

            else if (e.KeyChar == '\'')
            {
                // t.Show("Unet nedozvoljen karakter \' !", this, 3000);
                e.Handled = true;
            }

            else if (e.KeyChar == '\r')
            {
                e.Handled = true;
            }

            else
            {
                e.Handled = false;
            }
        }

        private void tipoviTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                opisTipaTextBox.Focus();
        }

        private void opisTipaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                ikonaComboBox.Focus();
        }

        private void ikonaComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (izmenaButton.Enabled)
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                    izmenaButton.Focus();
            }
            else {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                    dodajTipButton.Focus();
                
            }
        }

        private void Tip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                // the user pressed the F1 key
                HelpNavigator navigator = HelpNavigator.TopicId;
                Help.ShowHelp(this, "help.chm", navigator, "209");
            }
        }
    }
}
