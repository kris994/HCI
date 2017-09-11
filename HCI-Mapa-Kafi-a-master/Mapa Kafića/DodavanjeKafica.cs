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
    public partial class DodavanjeKafica : Form
    {
        
        List<getKaficInfo.Kafic> kaf;
        private String icoPath;
        private string wop;
               public DodavanjeKafica()
        {
            InitializeComponent();
            fillAll();
            this.kaf = new List<getKaficInfo.Kafic>();
            this.icoPath = "";
            Enabled = true;
            button1.Visible = false;
            button1.Enabled = false;
            informacijeLokalButton.Enabled = true;
            informacijeLokalButton.Visible = true;
    
        }

               public DodavanjeKafica(string wop)
               {
                   // TODO: Complete member initialization
                   this.wop = wop;
                   InitializeComponent();
                   fillAll();
                   ImeLokalaTextBox.Focus();
                   //this.ime = ime;
                  // fillCB();
                   button1.Visible = true;
                   button1.Enabled = true;
                   informacijeLokalButton.Enabled = false;
                   informacijeLokalButton.Visible = false; 
                   SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
                   tip.TestConnection();
                   DataTable t = tip.GetDataTable("Select ime, tip, oznaka, opis, kapacitet, etikete, alkohol, pusenje, rezervacije, hendikep, kat_cena, ikona, datum, x,y from lokal where ime= '" + wop + "';");
                   ImeLokalaTextBox.Text = t.Rows[0]["ime"].ToString();
                   tipComboBox.SelectedIndex = tipComboBox.Items.IndexOf(t.Rows[0]["tip"].ToString());
                   oznakaLokalaTextBox.Text = t.Rows[0]["oznaka"].ToString();
                   OpisLokalatextBox.Text = t.Rows[0]["opis"].ToString();
                   textBox1.Text = t.Rows[0]["kapacitet"].ToString();

                   String[] etikes = t.Rows[0]["etikete"].ToString().Trim().Split(',');
                   foreach (string s in etikes)
                   {
                       int index = etiketeListBox.FindStringExact(s.Trim());
                       if (index == -1) continue;
                       etiketeListBox.SetSelected(index, true);
                   }

                   String a = t.Rows[0]["alkohol"].ToString();
                   if (a == "Služi do 23h." || a == "Služi i kasno noću.") {
                       alkoholCheckBox.Checked = true;
                       AlkoholcomboBox.SelectedIndex = AlkoholcomboBox.Items.IndexOf(a);

                   }

                   String p = t.Rows[0]["pusenje"].ToString();
                   if (p == "Dozvoljeno samo u bašti." || p == "Izdvojena prostorija za pušače." || p=="Podeljen deo za pušače." ||p== "Pušenje dozvoljeno svuda.")
                   {
                       pusenjeCheckBox.Checked = true;
                       pusenjeCheckBox.Visible = true;
                       pusenjeKomboBox.SelectedIndex = pusenjeKomboBox.Items.IndexOf(p);

                   }
                   String r = t.Rows[0]["rezervacije"].ToString();
                   if (r == "1") rezervacijeCheckBox.Checked = true;

                   String h = t.Rows[0]["hendikep"].ToString();
                   if (h == "1") HendikepCheckBox.Checked = true;

                   string k = t.Rows[0]["kat_cena"].ToString();
                   ceneComboBox.SelectedIndex = ceneComboBox.Items.IndexOf(k);

                   dateTimePicker1.Value = Convert.ToDateTime((t.Rows[0]["datum"]).ToString());
                   icoPath = t.Rows[0]["ikona"].ToString();

               }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        public void fillAll()
        {
            izaberiIkonuButton.Enabled = true;
            //inicijalizacija alkoholnog box-a
            AlkoholcomboBox.Visible = false;
            AlkoholcomboBox.Items.Add("Služi do 23h.");
            AlkoholcomboBox.Items.Add("Služi i kasno noću.");

            //inicijalizacija pusackog box-a
            pusenjeKomboBox.Visible = false;
            pusenjeKomboBox.Items.Add("Dozvoljeno samo u bašti.");
            pusenjeKomboBox.Items.Add("Izdvojena prostorija za pušače.");
            pusenjeKomboBox.Items.Add("Podeljen deo za pušače.");
            pusenjeKomboBox.Items.Add("Pušenje dozvoljeno svuda.");

            //fokus na prvo
            ImeLokalaTextBox.Focus();

            //cene kombo box
            //ceneComboBox.Visible = false;
            ceneComboBox.Items.Add("Visoke cene.");
            ceneComboBox.Items.Add("Srednje visoke cene.");
            ceneComboBox.Items.Add("Prosečne cene.");
            ceneComboBox.Items.Add("Niske cene.");

            //inicijalizacija tip kombo boxa
            //draw som base shit
            //wop wop wop
            SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
            tip.TestConnection();
            DataTable t = tip.GetDataTable("SELECT tip FROM Tip; ");

            for (int i = 0; i < t.Rows.Count; i++)
            {
                tipComboBox.Items.Add(t.Rows[i]["tip"]);
            }

            //inishlajz det etiket niga list

            SQLiteDatabase etiketa = new SQLiteDatabase("", "baza.s3db");
            tip.TestConnection();
            DataTable etik = tip.GetDataTable("SELECT etiketa FROM Etiketa; ");

            for (int i = 0; i < etik.Rows.Count; i++)
            {
                etiketeListBox.Items.Add(etik.Rows[i]["etiketa"]);
            }

            dateTimePicker1.CustomFormat = "dd-MM-yyyy";

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(DodavanjeKafica_KeyDown);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tipLokalaTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ImeLokalaTextBox_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tipLokalaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                OpisLokalatextBox.Focus();
        }

        private void ImeLokalaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
               oznakaLokalaTextBox.Focus();
                
        }

        private void oznakaLokalaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                tipComboBox.Focus();
                tipComboBox.DroppedDown = true;
            }
        }

        private void OpisLokalatextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {

                textBox1.Focus();
            }
        }

        private void alkoholCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (alkoholCheckBox.Checked == true)
            {
                AlkoholcomboBox.Visible = true;
                AlkoholcomboBox.Focus();
                AlkoholcomboBox.DroppedDown = true;
                alkoholCheckBox.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                AlkoholcomboBox.Visible = false;
                alkoholCheckBox.FlatStyle = FlatStyle.Popup;
                pusenjeCheckBox.Focus();
            }
            

            
            
        }

       

        private void AlkoholcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AlkoholcomboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                pusenjeCheckBox.Focus();
                //alkoholCheckBox.ForeColor = Color.Black;
                //alkoholCheckBox.BackColor = Color.Black;
                pusenjeCheckBox.FlatStyle = FlatStyle.Flat;
                this.Refresh();
            }
        }

        private void pusenjeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (pusenjeCheckBox.Checked == true)
            {
                pusenjeKomboBox.Visible = true;
                pusenjeKomboBox.Focus();
                pusenjeKomboBox.DroppedDown = true;
                pusenjeCheckBox.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                pusenjeKomboBox.Visible = false;
                pusenjeCheckBox.FlatStyle = FlatStyle.Popup;
            }
        }

        private void pusenjeKomboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                rezervacijeCheckBox.Focus();
                //alkoholCheckBox.ForeColor = Color.Black;
                //alkoholCheckBox.BackColor = Color.Black;
                rezervacijeCheckBox.FlatStyle = FlatStyle.Flat;
                this.Refresh();
            }
        }

        private void rezervacijeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rezervacijeCheckBox.Checked == true)
            {
                rezervacijeCheckBox.FlatStyle = FlatStyle.Flat;
            }
            else
            {
                rezervacijeCheckBox.FlatStyle = FlatStyle.Popup;
            }
        }

        private void alkoholCheckBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                pusenjeCheckBox.Focus();
                alkoholCheckBox.BackColor = Color.FromName("White");
            }
        }

        private void pusenjeCheckBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                rezervacijeCheckBox.Focus();
                pusenjeCheckBox.FlatStyle = FlatStyle.Popup;
                //alkoholCheckBox.ForeColor = Color.Black;
                //alkoholCheckBox.BackColor = Color.Black;
                rezervacijeCheckBox.FlatStyle = FlatStyle.Flat;
                this.Refresh();
            }
        }

        private void rezervacijeCheckBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                HendikepCheckBox.Focus();
                rezervacijeCheckBox.FlatStyle = FlatStyle.Popup;
                //alkoholCheckBox.ForeColor = Color.Black;
                //alkoholCheckBox.BackColor = Color.Black;
                HendikepCheckBox.FlatStyle = FlatStyle.Flat;
                this.Refresh();
            }
        }

        private void HendikepCheckBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                ceneComboBox.Focus();
                HendikepCheckBox.FlatStyle = FlatStyle.Popup;
                ceneComboBox.DroppedDown = true;
                //alkoholCheckBox.ForeColor = Color.Black;
                //alkoholCheckBox.BackColor = Color.Black;
                //CheckBox.FlatStyle = FlatStyle.Flat;
                //this.Refresh();
            }
        }

        private void ceneComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                informacijeLokalButton.Focus();
                //rezervacijeCheckBox.FlatStyle = FlatStyle.Popup;
                //alkoholCheckBox.ForeColor = Color.Black;
                //alkoholCheckBox.BackColor = Color.Black;
                //HendikepCheckBox.FlatStyle = FlatStyle.Flat;
                this.Refresh();
            }
        }

        private void OpisLokalatextBox_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void ImeLokalaTextBox_Leave(object sender, EventArgs e)
        {
            
        }

        private void oznakaLokalaTextBox_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;

            }

            else { e.Handled = false; }

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                etiketeListBox.Focus();
                etiketeListBox.Select();
            }
            
        }

        

        private void OpisLokalatextBox_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
        }

        private void informacijeLokalButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(ImeLokalaTextBox.Text))
            {
                tipToolTip.SetToolTip(ImeLokalaTextBox, "Nije unesen naziv lokala.");
                tipToolTip.Show(tipToolTip.GetToolTip(ImeLokalaTextBox), ImeLokalaTextBox, 3000);
                ImeLokalaTextBox.Focus();
                return;

            }

            else if (string.IsNullOrEmpty(oznakaLokalaTextBox.Text))
            {
                tipToolTip.SetToolTip(oznakaLokalaTextBox, "Nije unesena oznaka lokala.");
                tipToolTip.Show(tipToolTip.GetToolTip(oznakaLokalaTextBox), oznakaLokalaTextBox, 3000);
                oznakaLokalaTextBox.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(OpisLokalatextBox.Text))
            {
                tipToolTip.SetToolTip(OpisLokalatextBox, "Nije unesen opis lokala.");
                tipToolTip.Show(tipToolTip.GetToolTip(OpisLokalatextBox), OpisLokalatextBox, 3000);
                OpisLokalatextBox.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(textBox1.Text))
            {
                tipToolTip.SetToolTip(textBox1, "Nije unesen kapacitet lokala.");
                tipToolTip.Show(tipToolTip.GetToolTip(textBox1), textBox1, 3000);
                textBox1.Focus();
                return;
            }
            else if (tipComboBox.SelectedIndex == -1)
            {
                tipToolTip.SetToolTip(tipComboBox, "Nije izabran tip lokala.");
                tipToolTip.Show(tipToolTip.GetToolTip(tipComboBox), tipComboBox, 3000);
                tipComboBox.Focus();
                tipComboBox.DroppedDown = true;
                return;
            }

            else if (AlkoholcomboBox.SelectedIndex == -1 && alkoholCheckBox.Checked)
            {
                tipToolTip.SetToolTip(AlkoholcomboBox, "Nije izabrana kategorija alkohola.");
                tipToolTip.Show(tipToolTip.GetToolTip(AlkoholcomboBox), AlkoholcomboBox, 3000);
                AlkoholcomboBox.Focus();
                AlkoholcomboBox.DroppedDown = true;
                return;
            }

            else if (pusenjeKomboBox.SelectedIndex == -1 && pusenjeCheckBox.Checked)
            {
                tipToolTip.SetToolTip(pusenjeKomboBox, "Nije izabrana kategorija pusenja.");
                tipToolTip.Show(tipToolTip.GetToolTip(pusenjeKomboBox), pusenjeKomboBox, 3000);
                pusenjeKomboBox.Focus();
                pusenjeKomboBox.DroppedDown = true;
                return;
            }

            else if (ceneComboBox.SelectedIndex == -1)
            {
                tipToolTip.SetToolTip(ceneComboBox, "Nije izabran tip lokala.");
                tipToolTip.Show(tipToolTip.GetToolTip(ceneComboBox), ceneComboBox, 3000);
                ceneComboBox.Focus();
                ceneComboBox.DroppedDown = true;
                return;
            }

            else
            {
                //getKaficInfo.Kafic kafanica = new getKaficInfo.Kafic();
                String imeKafica = ImeLokalaTextBox.Text;
                String tipKafica = tipComboBox.Text;
                String oznakaLokala = oznakaLokalaTextBox.Text;
                String opisLokala = OpisLokalatextBox.Text;
                int kapacitet = int.Parse(textBox1.Text);

                String statusAlkohola;
                if (alkoholCheckBox.Checked == true)
                {
                    statusAlkohola = AlkoholcomboBox.Text;
                }
                else
                {
                    statusAlkohola = "Ne toči alkohol.";
                }

                String statusPusenja;
                if (pusenjeCheckBox.Checked == true)
                {
                    statusPusenja = pusenjeKomboBox.Text;
                }
                else
                {
                    statusPusenja = "Nije dozvoljeno pušenje.";
                }

                int rezervacije;
                if (rezervacijeCheckBox.Checked == true)
                {
                    rezervacije = 1;
                }
                else
                {
                    rezervacije = 0;
                }


                int hendikep;
                if (HendikepCheckBox.Checked == true)
                {
                    hendikep = 1;
                }
                else
                {
                    hendikep = 0;
                }

                String cene = ceneComboBox.Text;

                int[] wop = new int[etiketeListBox.SelectedItems.Count];
                String etikete = "";
                if (etiketeListBox.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < etiketeListBox.SelectedItems.Count; i++)
                    {
                        wop[i] = etiketeListBox.SelectedIndices[i];
                    }
                }

                for (int i = 0; i < wop.Length; i++)
                {
                    etikete += etiketeListBox.Items[wop[i]] + ", ";
                }


                String datum = dateTimePicker1.Value.ToString();

                SQLiteDatabase lokali = new SQLiteDatabase("", "baza.s3db");

                lokali.ExecuteNonQuery("CREATE TABLE IF NOT EXISTS `Lokal`" +
                                            "(`id`	INTEGER DEFAULT 0 PRIMARY KEY AUTOINCREMENT," +
                                            "`ime`	TEXT UNIQUE," +
                                            "`tip`	TEXT," +
                                            "`oznaka`	TEXT UNIQUE," +
                                            "`opis`	TEXT," +
                                            "`kapacitet`	TEXT," +
                                            "`etikete`	TEXT," +
                                            "`alkohol`	TEXT," +
                                            "`pusenje`	TEXT," +
                                            "`rezervacije`	TEXT," +
                                            "`hendikep`	TEXT," +
                                            "`kat_cena`	TEXT," +
                                            "`ikona`	TEXT," +
                                            "`datum`	TEXT ," +
                                            "`na_tabeli`	TEXT, " +
                                            "`x`	TEXT, " +
                                            "`y`	TEXT " +
                                            ");");




                Dictionary<String, String> za_tabelu = new Dictionary<string, string>();
                za_tabelu.Add("ime", imeKafica);
                za_tabelu.Add("tip", tipKafica);
                za_tabelu.Add("oznaka", oznakaLokala);
                za_tabelu.Add("opis", opisLokala);
                za_tabelu.Add("kapacitet", kapacitet.ToString());
                za_tabelu.Add("etikete", etikete);
                za_tabelu.Add("alkohol", statusAlkohola);
                za_tabelu.Add("pusenje", statusPusenja);
                za_tabelu.Add("rezervacije", rezervacije.ToString());
                za_tabelu.Add("hendikep", hendikep.ToString());
                za_tabelu.Add("kat_cena", cene);
                za_tabelu.Add("ikona", icoPath);
                za_tabelu.Add("datum", datum);
                za_tabelu.Add("na_tabeli", "0");
                za_tabelu.Add("x", "-1");
                za_tabelu.Add("y", "-1");
                lokali.Insert("lokal", za_tabelu);



                this.Close();




            }
        }





        public Pocetna p { get; set; }

        private void DodavanjeKafica_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Pocetna p = new Pocetna();
            //p.Show();
          /*  Pocetna p = (Pocetna)Application.OpenForms[0];
            p.clearTable();
            p.readTable();
            p.refreshList();
            p.Refresh();*/
        }

        private void tipComboBox_Leave(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void etiketeListBox_Leave(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_Leave(object sender, EventArgs e)
        {
            
        }

        private void ceneComboBox_Leave(object sender, EventArgs e)
        {
            
        }

        private void izaberiIkonuButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            //op.FileName = "*.ico"
            op.Filter = " PNG Files|*.png";
            op.ShowDialog(this);

            icoPath = op.FileName;
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ImeLokalaTextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void oznakaLokalaTextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void OpisLokalatextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tipComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                OpisLokalatextBox.Focus();
        }

        private void etiketeListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                alkoholCheckBox.Focus();
                //alkoholCheckBox.ForeColor = Color.Black;
                //alkoholCheckBox.BackColor = Color.Black;
               // alkoholCheckBox.BackColor = Color.FromName("Green");
            }
        }

        private void alkoholCheckBox_Enter(object sender, EventArgs e)
        {
            alkoholCheckBox.BackColor = Color.FromName("Green");
        }

        private void alkoholCheckBox_Leave(object sender, EventArgs e)
        {
            alkoholCheckBox.BackColor = Color.FromName("White");

        }

        private void pusenjeCheckBox_Enter(object sender, EventArgs e)
        {
            pusenjeCheckBox.BackColor = Color.FromName("Green");

        }

        private void pusenjeCheckBox_Leave(object sender, EventArgs e)
        {
            pusenjeCheckBox.BackColor = Color.FromName("White");

        }

        private void rezervacijeCheckBox_Enter(object sender, EventArgs e)
        {
            rezervacijeCheckBox.BackColor = Color.FromName("Green");

        }

        private void rezervacijeCheckBox_Leave(object sender, EventArgs e)
        {
            rezervacijeCheckBox.BackColor = Color.FromName("White");

        }

        private void HendikepCheckBox_Enter(object sender, EventArgs e)
        {
            HendikepCheckBox.BackColor = Color.FromName("Green");

        }

        private void HendikepCheckBox_Leave(object sender, EventArgs e)
        {
            HendikepCheckBox.BackColor = Color.FromName("White");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(ImeLokalaTextBox.Text))
            {
                tipToolTip.SetToolTip(ImeLokalaTextBox, "Nije unesen naziv lokala.");
                tipToolTip.Show(tipToolTip.GetToolTip(ImeLokalaTextBox), ImeLokalaTextBox, 3000);
                ImeLokalaTextBox.Focus();
                return;

            }

            else if (string.IsNullOrEmpty(oznakaLokalaTextBox.Text))
            {
                tipToolTip.SetToolTip(oznakaLokalaTextBox, "Nije unesena oznaka lokala.");
                tipToolTip.Show(tipToolTip.GetToolTip(oznakaLokalaTextBox), oznakaLokalaTextBox, 3000);
                oznakaLokalaTextBox.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(OpisLokalatextBox.Text))
            {
                tipToolTip.SetToolTip(OpisLokalatextBox, "Nije unesen opis lokala.");
                tipToolTip.Show(tipToolTip.GetToolTip(OpisLokalatextBox), OpisLokalatextBox, 3000);
                OpisLokalatextBox.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(textBox1.Text))
            {
                tipToolTip.SetToolTip(textBox1, "Nije unesen kapacitet lokala.");
                tipToolTip.Show(tipToolTip.GetToolTip(textBox1), textBox1, 3000);
                textBox1.Focus();
                return;
            }
            else if (tipComboBox.SelectedIndex == -1)
            {
                tipToolTip.SetToolTip(tipComboBox, "Nije izabran tip lokala.");
                tipToolTip.Show(tipToolTip.GetToolTip(tipComboBox), tipComboBox, 3000);
                tipComboBox.Focus();
                tipComboBox.DroppedDown = true;
                return;
            }

            else if (AlkoholcomboBox.SelectedIndex == -1 && alkoholCheckBox.Checked)
            {
                tipToolTip.SetToolTip(AlkoholcomboBox, "Nije izabrana kategorija alkohola.");
                tipToolTip.Show(tipToolTip.GetToolTip(AlkoholcomboBox), AlkoholcomboBox, 3000);
                AlkoholcomboBox.Focus();
                AlkoholcomboBox.DroppedDown = true;
                return;
            }

            else if (pusenjeKomboBox.SelectedIndex == -1 && pusenjeCheckBox.Checked)
            {
                tipToolTip.SetToolTip(pusenjeKomboBox, "Nije izabrana kategorija pusenja.");
                tipToolTip.Show(tipToolTip.GetToolTip(pusenjeKomboBox), pusenjeKomboBox, 3000);
                pusenjeKomboBox.Focus();
                pusenjeKomboBox.DroppedDown = true;
                return;
            }

            else if (ceneComboBox.SelectedIndex == -1)
            {
                tipToolTip.SetToolTip(ceneComboBox, "Nije izabran tip lokala.");
                tipToolTip.Show(tipToolTip.GetToolTip(ceneComboBox), ceneComboBox, 3000);
                ceneComboBox.Focus();
                ceneComboBox.DroppedDown = true;
                return;
            }

            else
            {
                //getKaficInfo.Kafic kafanica = new getKaficInfo.Kafic();
                String imeKafica = ImeLokalaTextBox.Text;
                String tipKafica = tipComboBox.Text;
                String oznakaLokala = oznakaLokalaTextBox.Text;
                String opisLokala = OpisLokalatextBox.Text;
                int kapacitet = int.Parse(textBox1.Text);

                String statusAlkohola;
                if (alkoholCheckBox.Checked == true)
                {
                    statusAlkohola = AlkoholcomboBox.Text;
                }
                else
                {
                    statusAlkohola = "Ne toči alkohol.";
                }

                String statusPusenja;
                if (pusenjeCheckBox.Checked == true)
                {
                    statusPusenja = pusenjeKomboBox.Text;
                }
                else
                {
                    statusPusenja = "Nije dozvoljeno pušenje.";
                }

                int rezervacije;
                if (rezervacijeCheckBox.Checked == true)
                {
                    rezervacije = 1;
                }
                else
                {
                    rezervacije = 0;
                }


                int hendikep;
                if (HendikepCheckBox.Checked == true)
                {
                    hendikep = 1;
                }
                else
                {
                    hendikep = 0;
                }

                String cene = ceneComboBox.Text;

                int[] wop = new int[etiketeListBox.SelectedItems.Count];
                String etikete = "";
                if (etiketeListBox.SelectedItems.Count > 0)
                {
                    for (int i = 0; i < etiketeListBox.SelectedItems.Count; i++)
                    {
                        wop[i] = etiketeListBox.SelectedIndices[i];
                    }
                }

                for (int i = 0; i < wop.Length; i++)
                {
                    etikete += etiketeListBox.Items[wop[i]] + ", ";
                }


                String datum = dateTimePicker1.Value.ToString();

                SQLiteDatabase lokali = new SQLiteDatabase("", "baza.s3db");
                Dictionary<String, String> za_tabelu = new Dictionary<string, string>();
                za_tabelu.Add("ime", imeKafica);
                za_tabelu.Add("tip", tipKafica);
                za_tabelu.Add("oznaka", oznakaLokala);
                za_tabelu.Add("opis", opisLokala);
                za_tabelu.Add("kapacitet", kapacitet.ToString());
                za_tabelu.Add("etikete", etikete);
                za_tabelu.Add("alkohol", statusAlkohola);
                za_tabelu.Add("pusenje", statusPusenja);
                za_tabelu.Add("rezervacije", rezervacije.ToString());
                za_tabelu.Add("hendikep", hendikep.ToString());
                za_tabelu.Add("kat_cena", cene);
                za_tabelu.Add("ikona", icoPath);
                za_tabelu.Add("datum", datum);
                za_tabelu.Add("na_tabeli", "0");
                //za_tabelu.Add("x", "-1");
                //za_tabelu.Add("y", "-1");
                //lokali.Insert("lokal", za_tabelu);

                //lokali.Update("Lokal", za_tabelu, "ime = '" + wop + "'");
                lokali.Update("Lokal", za_tabelu, "ime = '" + this.wop + "'");


                this.Close();
                
            
            }

        }

        private void DodavanjeKafica_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                // the user pressed the F1 key
                HelpNavigator navigator = HelpNavigator.TopicId;
                Help.ShowHelp(this, "help.chm", navigator, "140");
            }
        }
    }
}
namespace getKaficInfo {

    public class Kafic {
        
        

        public Kafic() { 
       
        }


        public String kapacitet
        {
            get;
            set;
        }
        
        public String imeKafica
        {
            get;
            set;
        }
        public String tipKafica
        {
            get;
            set;
        }

        public String oznakaLokala
        {
            get;
            set;
        }

        public String opisLokala
        {
            get;
            set;
        }

        public String statusAlkohola
        {
            get;
            set;
        }

        public String statusPusenja
        {
            get;
            set;
        }

        public bool rezervacije
        {
            get;
            set;
        }
        public bool hendikep
        {
            get;
            set;

        }
        public String cene
        {
            get;
            set;
        }

    }
}

