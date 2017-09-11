using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Mapa_Kafića
{
    public partial class DodajEtiketu : Form
    {

        bool succes;

        bool uspeh;
        String ime;
        public DodajEtiketu()
        {

            InitializeComponent();
            this.uspeh = true;
            this.succes = true;
            tipoviTextBox.Focus();
            izmenaButton.Visible = false;
            izmenaButton.Enabled = false;
        }

        public DodajEtiketu(String ime) {
            
            InitializeComponent();
            tipoviTextBox.Focus();
            this.ime = ime;
            //fillCB();
            dodajTipButton.Enabled = false;
            dodajTipButton.Visible = false;
            SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
            tip.TestConnection();
            DataTable t = tip.GetDataTable("SELECT etiketa, opis, boja FROM etiketa where etiketa = '" + ime + "'; ");
            tipoviTextBox.Text = t.Rows[0]["etiketa"].ToString();
            textBox1.Text = t.Rows[0]["opis"].ToString();
            colorComboBox.Items.Add(t.Rows[0]["boja"].ToString());
            colorComboBox.Text = t.Rows[0]["boja"].ToString();

        
        }

        private void fillCB()
        {
            foreach (System.Reflection.PropertyInfo prop in typeof(Color).GetProperties())
            {
                if (prop.PropertyType.FullName == "System.Drawing.Color")

                    colorComboBox.Items.Add(prop.Name);


            }

        }

        private void tipToolTip_Popup(object sender, PopupEventArgs e)
        {

        }

        private void DodajEtiketu_FormClosed(object sender, FormClosedEventArgs e)
        {
            
                
            
        }

        private void dodajTipButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tipoviTextBox.Text)) 
            {
                tipToolTip.SetToolTip(tipoviTextBox, "Nije unesen naziv etikete.");
                tipToolTip.Show(tipToolTip.GetToolTip(tipoviTextBox), tipoviTextBox, 3000);
                tipoviTextBox.Focus();
                
            }

            else if(string.IsNullOrEmpty(textBox1.Text))
            {
                tipToolTip.SetToolTip(textBox1, "Nije unesen opis etikete.");
                tipToolTip.Show(tipToolTip.GetToolTip(textBox1), textBox1, 3000);
                textBox1.Focus();
            }
            else if (colorComboBox.SelectedIndex == -1) {
                tipToolTip.SetToolTip(colorComboBox, "Nije unesen opis etikete.");
                tipToolTip.Show(tipToolTip.GetToolTip(colorComboBox), colorComboBox, 3000);
                colorComboBox.Select();
                colorComboBox.Focus();
            }
            else
            {
                string inputFile = "baza.s3db";
                string dbConnection = String.Format("Data Source={0}", inputFile);
                SQLiteConnection cnn = new SQLiteConnection(dbConnection);
                cnn.Open();

                // Define the SQL Create table statement  
                string createLogTableSQL = "CREATE TABLE IF NOT EXISTS `Etiketa`" +
                                            "(`id`	INTEGER DEFAULT 0 PRIMARY KEY AUTOINCREMENT," +
                                            "`etiketa`	TEXT UNIQUE," +
                                            "'opis' TEXT," +
                                            "'boja' TEXT"
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

                string etiketa = tipoviTextBox.Text;




                string quary = "SELECT etiketa FROM Etiketa where etiketa ='" + etiketa.Trim() + "';";
                SQLiteCommand q = new SQLiteCommand(cnn);
                q.CommandText = quary;
                object res = q.ExecuteScalar();

                if (res != null) {
                    tipToolTip.SetToolTip(tipoviTextBox, "Već postoji etiketa sa istim imenom.");
                    tipToolTip.Show(tipToolTip.GetToolTip(tipoviTextBox), tipoviTextBox, 3000);
                    tipoviTextBox.Focus();
                }
                else
                {


                    try
                    {
                        string sql = "insert into Etiketa (etiketa, opis, boja) values ('" + etiketa.Trim() + "','" + textBox1.Text.Trim() + "','" + colorComboBox.SelectedItem.ToString().Trim() + "')";
                        SQLiteCommand mycommand = new SQLiteCommand(cnn);
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
                    DodajEtiketu t = new DodajEtiketu();
                    t.Show();
                    System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
                    ToolTip1.SetToolTip(t.tipoviTextBox, "test");

                }
                else
                {


                }


            }
        }

        private void DodajEtiketu_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(DodajEtiketu_KeyDown);
            tipoviTextBox.Focus();
            tipoviTextBox.Select();
            foreach (System.Reflection.PropertyInfo prop in typeof(Color).GetProperties())
            {
                if (prop.PropertyType.FullName == "System.Drawing.Color")
                   
                    colorComboBox.Items.Add(prop.Name);
                    
                    
            }

        }

        private void colorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color p = Color.FromName(colorComboBox.Text);
            labelPrimer.ForeColor = p;
        }

        private void tipoviTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ToolTip t = new ToolTip();
            if(e.KeyChar == ';'){
              //  t.Show("Unet nedozvoljen karakter ; !", this, 3000);

                e.Handled = true ;
                
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

            else {
                e.Handled = false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

            else if (e.KeyChar =='\r') {
                e.Handled = true;
            }

            else
            {
                e.Handled = false;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
         
        }

        private void tipoviTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                textBox1.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                colorComboBox.Focus();
        }

        private void z1(object sender, EventArgs e)
        {

        }

        private void colorComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                dodajTipButton.Focus();

        }

        private void deleteAllPictureBox() { }

        private void izmenaButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tipoviTextBox.Text))
            {
                tipToolTip.SetToolTip(tipoviTextBox, "Nije unesen naziv etikete.");
                tipToolTip.Show(tipToolTip.GetToolTip(tipoviTextBox), tipoviTextBox, 3000);
                tipoviTextBox.Focus();

            }

            else if (string.IsNullOrEmpty(textBox1.Text))
            {
                tipToolTip.SetToolTip(textBox1, "Nije unesen opis etikete.");
                tipToolTip.Show(tipToolTip.GetToolTip(textBox1), textBox1, 3000);
                textBox1.Focus();
            }
            else if (colorComboBox.SelectedIndex == -1)
            {
                tipToolTip.SetToolTip(colorComboBox, "Nije unesen opis etikete.");
                tipToolTip.Show(tipToolTip.GetToolTip(colorComboBox), colorComboBox, 3000);
                colorComboBox.Select();
                colorComboBox.Focus();
            }
            else
            {

                SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
                tip.TestConnection();
                DataTable t = tip.GetDataTable("SELECT etiketa,opis,boja FROM etiketa where etiketa = '" + ime + "'; ");
                DataTable etiketa = tip.GetDataTable("SELECT ime, etikete FROM Lokal; ");
                bool cool = false;
                List<String> listaEtiketa = new List<string>();
                List<String> listaEtiketaZaIzmenu = new List<string>();
                String add;

                foreach(DataRow r in etiketa.Rows)
                {
                    cool = false;
                    add = "";
                    String[] sve_etikete = r["etikete"].ToString().Trim().Split(',');
                    for (int i = 0; i < sve_etikete.Length; i++)
                    {
                        if (sve_etikete[i].Trim().Equals(ime))
                        {
                            sve_etikete[i] = tipoviTextBox.Text.ToString();
                            cool = true;

                        }
                        if (cool && i == sve_etikete.Length-1) {
                            foreach (String s in sve_etikete)
                            {
                                add += s + ", ";
                            }
                            listaEtiketa.Add(add);
                            listaEtiketaZaIzmenu.Add(r["etikete"].ToString());
                        
                        }
                    }


                }

                Dictionary<string, string> za_update_lokal = new Dictionary<string, string>();
                Dictionary<string, string> za_update_tip = new Dictionary<string, string>();

                za_update_tip.Add("etiketa", tipoviTextBox.Text.Trim());
                za_update_tip.Add("opis", tipoviTextBox.Text.Trim());
                za_update_tip.Add("boja", colorComboBox.Text.Trim());
                tip.Update("Etiketa", za_update_tip, "etiketa = '" + ime + "'");


                for (int i = 0; i < listaEtiketa.Count; i++)
                {
                    za_update_lokal.Add("etikete", listaEtiketa[i]);
                    tip.Update("Lokal", za_update_lokal, "etikete = '" + listaEtiketaZaIzmenu[i] + "'");
                    za_update_lokal.Remove("etikete");
                }
                this.Close();



            }
        }

        private void DodajEtiketu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                // the user pressed the F1 key
                HelpNavigator navigator = HelpNavigator.TopicId;
                Help.ShowHelp(this, "help.chm", navigator, "263");
            }
        }

        
    }
}
