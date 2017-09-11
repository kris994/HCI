using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mapa_Kafića
{
    public partial class LokalPrikaz : Form
    {
        private List<customPB> pb = new List<customPB>();
        
        public LokalPrikaz()
        {
            InitializeComponent();
            readTable();
        }


        public void readTable()
        {

            SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
            tip.TestConnection();
            DataTable t = tip.GetDataTable("SELECT ime,etikete,tip,ikona,x,y FROM Lokal; ");
            //ovde smestamo listu ikona;
            ImageList ikone = new ImageList();

            //pravimo i string za boju i ujedno je trazimo kada trazimo tip
            String[] boje = new String[t.Rows.Count];
            int i = 0;
            foreach (DataRow r in t.Rows)
            {

                //ako je na tabeli
                //if(r["na_tabeli"].Equals(1) {continue;}
                //ako ikona ne postoji stavljamo ikonu tipa
                if (r["ikona"].Equals(""))
                {
                    DataTable tipTabela = tip.GetDataTable("SELECT ikona FROM tip where tip='" + r["tip"] + "';");
                    DataRow tr = tipTabela.Rows[0];
                    ikone.Images.Add(r["ime"].ToString(), Image.FromFile(tr["ikona"].ToString()));
                }
                else
                {

                    //TODO 1: ukoliko postoji ikona
                    ikone.Images.Add(r["ime"].ToString(), Image.FromFile(r["ikona"].ToString()));
                }
                //svakako iz ove tabele vucemo boju
                DataTable etiketaTabela = tip.GetDataTable("SELECT boja FROM etiketa WHERE etiketa = '" + r["etikete"].ToString().Split(',')[0] + "'");
                String boja;
                if (etiketaTabela.Rows.Count == 0)
                {
                    boja = "White";
                }
                else
                {
                    DataRow boj = etiketaTabela.Rows[0];
                    boja = boj["boja"].ToString();
                }
                boje[i] = boja;
                i++;

            }

            //hocemo da povezemo ikone i text
            lokaliListView.LargeImageList = ikone;

            int j = 0;
            //sve povezemo zajedno
            foreach (DataRow r in t.Rows)
            {
                //ukoliko su koordinate takve da jeste na mapi
                /*if (Convert.ToInt32(r["x"]) != -1)
                {
                    String name = r["ime"].ToString();
                    String color = "";
                    for (int w = 0; w < getLokalColor(name).Length; w++)
                    {
                        color += getLokalColor(name)[w] + " ";
                    }
                    String ico = getLokalImage(name);

                    //pravimo tu paintbox komponentu
                    Point po = new Point();
                    String coX = r["x"].ToString();
                    String coY = r["y"].ToString();
                    po.X = Convert.ToInt32(coX);
                    po.Y = Convert.ToInt32(coY);

                    //customPB p = new customPB(name, color, ico, p);
                    customPB pbox = new customPB(name, color, ico, po);
                    //pbox.Show();
                    pb.Add(pbox);
                    //mapPicture.Controls.Add(pbox);





                    //continue;
                }*/
                ListViewItem it = lokaliListView.Items.Add(r["ime"].ToString());

                // it.ForeColor = Color.FromName(boje[j]);
                j++;
                it.ImageKey = r["ime"].ToString();




            }


        }

        private String getLokalImage(string name)
        {

            SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
            tip.TestConnection();

            DataTable t = tip.GetDataTable("SELECT ime, etikete, tip, ikona FROM Lokal WHERE ime ='" + name + "'; ");

            if (t.Rows[0]["ikona"].Equals(""))
            {
                DataTable tipTabela = tip.GetDataTable("SELECT ikona FROM tip where tip='" + t.Rows[0]["tip"] + "';");
                return tipTabela.Rows[0]["ikona"].ToString();
            }
            else
            {
                return t.Rows[0]["ikona"].ToString();
            }
        }


        public void clearTable()
        {

            deleteAllPb();
            for (int i = lokaliListView.Items.Count - 1; i >= 0; i--)
                lokaliListView.Items.RemoveAt(i);


        }


        public void deleteAllPb()
        {
            /*foreach (customPB p in pb)
            {
                //mapPicture.Controls.Remove(p);
                //pb.Remove(p);
            }*/
            if (pb.Count > 0) {
                pb[0].Hide();
            }
            pb.Clear();
        }


        private String[] getLokalColor(String name)
        {
            SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
            tip.TestConnection();

            DataTable t = tip.GetDataTable("SELECT ime, etikete, tip, ikona FROM Lokal WHERE ime ='" + name + "'; ");
            String[] etikete = t.Rows[0]["etikete"].ToString().Split(',');
            String[] boje = new String[etikete.Length];

            for (int i = 0; i < etikete.Length; i++)
            {

                if (!etikete[i].Trim().Equals(""))
                {
                    DataTable e = tip.GetDataTable("SELECT boja FROM etiketa WHERE etiketa ='" + etikete[i].Trim() + "'; ");
                    boje[i] = e.Rows[0]["boja"].ToString();
                }
            }

            return boje;
        }


        private void LokalPrikaz_Load(object sender, EventArgs e)
        {

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(LokalPrikaz_KeyDown);
            
            deleteEntery.Enabled = false;
            IzmeniButton.Enabled = false;
            etiketePanel.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";

            string folder = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + @"\..\..\tipIcons\";
            string filter = "*.png";
            string[] files = Directory.GetFiles(folder, filter);

            previewComboBox.Visible = false;
            previewPictureBox.Visible = false;

            foreach (String file in files)
            {
                previewComboBox.Items.Add(file);
            }
        }

        private void lokaliListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lokaliListView.SelectedItems.Count == 0)
            {
                deleteEntery.Enabled = false;
                IzmeniButton.Enabled = false;
                ImeLabel.Text = "nije selektovan ni jedan lokal";
                tipLabel.Text = "nije selektovan ni jedan lokal";
                etiketaLabel.Text = "nije selektovan ni jedan lokal";
                etiketaLabel.Visible = true;
                etiketePanel.Visible = false;
                etiketePanel.Controls.Clear();
                oznakaLabel.Text = "nije selektovan ni jedan lokal";
                opisLabel.Text = "nije selektovan ni jedan lokal";
                kapacitetLabel.Text = "nije selektovan ni jedan lokal";
                alkoholLabel.Text = "nije selektovan ni jedan lokal";
                pusenjeLabel.Text = "nije selektovan ni jedan lokal";
                rezervacijeLabel.Text = "nije selektovan ni jedan lokal";
                ceneLabel.Text = "nije selektovan ni jedan lokal";
                datumLabel.Text = "nije selektovan ni jedan lokal";
                naMapiLabel.Text = "nije selektovan ni jedan lokal";
                hendikepLabel.Text = "nije selektovan ni jedan lokal";

                if (pb.Count > 0)
                {
                    pb[0].Hide();
                    pb.Clear();

                }
                icoPictureBox.Image = icoPictureBox.InitialImage;
                customPBpictureBox.Image = icoPictureBox.InitialImage;
            }
            else
            {
                deleteEntery.Enabled = true;
                IzmeniButton.Enabled = true;


                String wop = lokaliListView.SelectedItems[0].Text.Trim();
                
                SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
                tip.TestConnection();
                DataTable t = tip.GetDataTable("Select ime, tip, oznaka, opis, kapacitet, etikete, alkohol, pusenje, rezervacije, hendikep, kat_cena, ikona, datum, x,y from lokal where ime= '" + wop + "';");
                DataTable tipTable = tip.GetDataTable("Select tip,opis,ikona from tip where tip= '" + t.Rows[0]["tip"].ToString() + "';");
                DataTable etiketaTable = tip.GetDataTable("Select etiketa,opis,boja from etiketa where etiketa= '" + "dsdsdgfsdgsdfgsdfsdf" + "';");

                foreach (string s in t.Rows[0]["etikete"].ToString().Split(','))
                {
                    DataTable tmp = tip.GetDataTable("Select etiketa,opis,boja from etiketa where etiketa= '" + s.Trim() + "';");

                    if (tmp.Rows.Count > 0) {
                        DataRow d = etiketaTable.NewRow();
                        d["etiketa"] = tmp.Rows[0]["etiketa"];
                        d["opis"] = tmp.Rows[0]["opis"];
                        d["boja"] = tmp.Rows[0]["boja"];
                        etiketaTable.Rows.InsertAt(d,etiketaTable.Rows.Count);
                    }

                }
                
                ImeLabel.Text = t.Rows[0]["ime"].ToString();
                tipLabel.Text = t.Rows[0]["tip"].ToString();

                etiketaLabel.Visible = false;
                etiketePanel.Visible = true;

                //dodavanja vjua etiketa
                Control[] w = new Control[etiketaTable.Rows.Count];
                for(int i = 0; i <  etiketaTable.Rows.Count; i++) {
                    Label l = new Label();
                    l.AutoSize = true;
                    //l.Font = new Font(l.Font, FontStyle.Bold);
                    l.Text = etiketaTable.Rows[i]["etiketa"].ToString();
                    l.ForeColor = Color.FromName(etiketaTable.Rows[i]["boja"].ToString());
                    w[i] = l;
                }
                etiketePanel.Controls.AddRange(w);

                
                oznakaLabel.Text = t.Rows[0]["oznaka"].ToString();
                opisLabel.Text = t.Rows[0]["opis"].ToString();
                kapacitetLabel.Text = t.Rows[0]["kapacitet"].ToString();
                alkoholLabel.Text = t.Rows[0]["alkohol"].ToString();
                pusenjeLabel.Text = t.Rows[0]["pusenje"].ToString();


                //ispis rezervacija
                String r;
                if (t.Rows[0]["rezervacije"].ToString().Equals("0")) {
                    r = "Ne";
                }
                else
                {
                    r = "Da";
                }
                rezervacijeLabel.Text = r;



                
                ceneLabel.Text = t.Rows[0]["kat_cena"].ToString();
                datumLabel.Text = t.Rows[0]["datum"].ToString().Split(' ')[0].Trim();

                String onM;
                if (Int32.Parse(t.Rows[0]["x"].ToString()) > -1 && Int32.Parse(t.Rows[0]["y"].ToString()) > -1)
                {
                    onM = "Da";
                }
                else
                {

                    onM = "Ne";
                }
                naMapiLabel.Text = onM;

                
                //za hendikepirane
                String h;
                if (t.Rows[0]["hendikep"].ToString().Equals("0"))
                {
                    r = "Ne";
                }
                else
                {
                    r = "Da";
                }
                hendikepLabel.Text = r;
                if (t.Rows[0]["ikona"].ToString().Equals("")) {
                    icoPictureBox.Image = Image.FromFile(tipTable.Rows[0]["ikona"].ToString());
                }
                else
                {
                    //TODO: ako postoji ikona iscrtati je

                }

                //dodavanje ikone sa mape na formu
                String name = t.Rows[0]["ime"].ToString();
                String color = "";
                for (int www = 0; www < getLokalColor(name).Length; www++)
                {
                    color += getLokalColor(name)[www] + " ";
                }
                String ico = getLokalImage(name);

                //pravimo tu paintbox komponentu
                Point po = new Point();
                String coX = "+16";
                String coY = "+16";
                po.X = Convert.ToInt32(coX);
                po.Y = Convert.ToInt32(coY);

                if (pb.Count>0) {
                    pb[0].Hide();
                    pb.Clear();
                }
                //customPB p = new customPB(name, color, ico, p);
                customPB pbox = new customPB(name, color, ico, po);
                pbox.Show();
                pbox.Size = new Size(32, 32);
                pb.Add(pbox);
                customPBpictureBox.Controls.Add(pbox);

            }
        }

        private void InfoPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void naMapiLabel_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void enterEntery_Click(object sender, EventArgs e)
        {
            DodavanjeKafica d = new DodavanjeKafica();
            d.ShowDialog(this);
            clearTable();
            readTable();
        }

        private void FilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FilterComboBox.SelectedItem.ToString() == "Ime")
            {
                previewComboBox.Visible = false;
                previewPictureBox.Visible = false;
                filterTextBox.Visible = true;
                dateTimePicker1.Visible = false;

                
                return;
            }
            else if (FilterComboBox.SelectedItem.ToString() == "Tip")
            {
                previewComboBox.Visible = true;
                previewPictureBox.Visible = false;
                filterTextBox.Visible = false;
                dateTimePicker1.Visible = false;

                SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
                tip.TestConnection();
                DataTable t = tip.GetDataTable("Select tip,opis,ikona from tip;");
                previewComboBox.Items.Clear();
                foreach (DataRow d in t.Rows)
                {
                    previewComboBox.Items.Add(d["tip"].ToString());

             
                }

                
                return;
            }
            else if (FilterComboBox.SelectedItem.ToString() == "Etiketa")
            {
                previewComboBox.Visible = true;
                previewPictureBox.Visible = false;
                filterTextBox.Visible = false;
                dateTimePicker1.Visible = false;

                SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
                tip.TestConnection();
                DataTable t = tip.GetDataTable("Select etiketa from etiketa;");
                previewComboBox.Items.Clear();
                foreach (DataRow d in t.Rows)
                {
                    previewComboBox.Items.Add(d["etiketa"].ToString());

                }


                return;
            }


            else if (FilterComboBox.SelectedItem.ToString() == "Oznaka")
            {
                previewComboBox.Visible = false;
                previewPictureBox.Visible = false;
                filterTextBox.Visible = true;
                dateTimePicker1.Visible = false;
               
                return;
            }
            else if (FilterComboBox.SelectedItem.ToString() == "Opis")
            {
                previewComboBox.Visible = false;
                previewPictureBox.Visible = false;
                filterTextBox.Visible = true;
                dateTimePicker1.Visible = false;
               
                return;
            }

            else if (FilterComboBox.SelectedItem.ToString() == "Kapacitet")
            {
                previewComboBox.Visible = false;
                previewPictureBox.Visible = false;
                filterTextBox.Visible = true;
                dateTimePicker1.Visible = false;

                return;
            }

            else if (FilterComboBox.SelectedItem.ToString() == "Alkohol")
            {
                previewComboBox.Visible = true;
                previewPictureBox.Visible = false;
                filterTextBox.Visible = false;
                dateTimePicker1.Visible = false;

                //punimo combo box
                previewComboBox.Items.Clear();
                previewComboBox.Items.Add("Ne toči alkohol.");
                previewComboBox.Items.Add("Služi do 23h.");
                previewComboBox.Items.Add("Služi i kasno noću.");



                return;
            }

            else if (FilterComboBox.SelectedItem.ToString() == "Pušenje")
            {
                previewComboBox.Visible = true;
                previewPictureBox.Visible = false;
                filterTextBox.Visible = false;
                dateTimePicker1.Visible = false;

                //punimo combo box
                previewComboBox.Items.Clear();
                previewComboBox.Items.Add("Nije dozvoljeno pušenje.");
                previewComboBox.Items.Add("Dozvoljeno samo u bašti.");
                previewComboBox.Items.Add("Izdvojena prostorija za pušače.");
                previewComboBox.Items.Add("Podeljen deo za pušače.");
                previewComboBox.Items.Add("Pušenje dozvoljeno svuda.");


                return;
            }

            else if (FilterComboBox.SelectedItem.ToString() == "Rezervacije")
            {
                previewComboBox.Visible = true;
                previewPictureBox.Visible = false;
                filterTextBox.Visible = false;
                dateTimePicker1.Visible = false;

                //punimo combo box
                previewComboBox.Items.Clear();
                previewComboBox.Items.Add("Da");
                previewComboBox.Items.Add("Ne");
                

                return;
            }

            else if (FilterComboBox.SelectedItem.ToString() == "Cene")
            {
                previewComboBox.Visible = true;
                previewPictureBox.Visible = false;
                filterTextBox.Visible = false;
                dateTimePicker1.Visible = false;

                //punimo combo box
                previewComboBox.Items.Clear();
                previewComboBox.Items.Add("Visoke cene.");
                previewComboBox.Items.Add("Srednje visoke cene.");
                previewComboBox.Items.Add("Prosečne cene.");
                previewComboBox.Items.Add("Niske cene.");



                return;
            }

            else if (FilterComboBox.SelectedItem.ToString() == "Datum")
            {
                previewComboBox.Visible = false;
                previewPictureBox.Visible = false;
                filterTextBox.Visible = false;
                dateTimePicker1.Visible = true;



                return;
            }

            else if (FilterComboBox.SelectedItem.ToString() == "Hendikepirani")
            {
                previewComboBox.Visible = true;
                previewPictureBox.Visible = false;
                filterTextBox.Visible = false;
                dateTimePicker1.Visible = false;

                //punimo combo box
                previewComboBox.Items.Clear();
                previewComboBox.Items.Add("Da");
                previewComboBox.Items.Add("Ne");


                return;
            }


            else if (FilterComboBox.SelectedItem.ToString() == "Na mapi")
            {
                previewComboBox.Visible = true;
                previewPictureBox.Visible = false;
                filterTextBox.Visible = false;
                dateTimePicker1.Visible = false;

                //punimo combo box
                previewComboBox.Items.Clear();
                previewComboBox.Items.Add("Da");
                previewComboBox.Items.Add("Ne");


                return;
            }

            else if (FilterComboBox.SelectedItem.ToString() == "Ikona")
            {
                previewComboBox.Visible = true;
                previewPictureBox.Visible = true;
                filterTextBox.Visible = false;
                dateTimePicker1.Visible = false;

                //punimo combo box
                previewComboBox.Items.Clear();
                string folder = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName) + @"\..\..\tipIcons\";
                string filter = "*.png";
                string[] files = Directory.GetFiles(folder, filter);

                
                foreach (String file in files)
                {
                    previewComboBox.Items.Add(file);
                }

                return;
            }

            else if (FilterComboBox.SelectedItem.ToString() == "Prikaži sve")
            {
                previewComboBox.Visible = false;
                previewPictureBox.Visible = false;
                filterTextBox.Visible = false;
                dateTimePicker1.Visible = false;

              
                return;
            }





        
        }

        private void previewComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(FilterComboBox.SelectedItem.ToString() == "Ikona")
            previewPictureBox.Image = Image.FromFile(previewComboBox.Text);

        }

        private void readTableWithParam(String paramName, String param)
        {
            SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
            tip.TestConnection();
            DataTable t = tip.GetDataTable("SELECT ime, tip, oznaka, opis, kapacitet, etikete, alkohol, pusenje, rezervacije, hendikep, kat_cena, ikona, datum, x,y FROM lokal where " + paramName + "= '" + param + "'; ");
            if (t.Rows.Count == 0)
            {
                ToolTip ttip = new ToolTip();
                ttip.Show("Nije pronadjen ni jedan sadržaj parametra " + paramName + " sa imenom " + param + "!", lokaliListView, 3000);
                return;
            }
            else
            {
                //tipoviListView dodavanje ikona tipa + naziva tipa
                ImageList ikone = new ImageList();

                //dodamo sve ikone u lisu
                foreach (DataRow row in t.Rows)
                {
                    String tip_row = row["ime"].ToString();
                    String ico_row = row["ikona"].ToString();
                    if (ico_row.Equals("")) {
                        DataTable tt = tip.GetDataTable("Select tip,opis,ikona from tip where tip= '" + row["tip"] + "';");
                        ico_row = tt.Rows[0]["ikona"].ToString();
                    }

                    ikone.Images.Add(tip_row, Image.FromFile(ico_row));
                }

                //kazemo tipoviListView-u da koristi listu ikona
                lokaliListView.LargeImageList = ikone;

                foreach (DataRow row in t.Rows)
                {
                    ListViewItem tmp = lokaliListView.Items.Add(row["ime"].ToString());
                    tmp.ImageKey = row["ime"].ToString();
                }
            }
        }


        private void readTableWithParamNotEqual(String paramName, String param)
        {
            SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
            tip.TestConnection();
            DataTable t = tip.GetDataTable("SELECT ime, tip, oznaka, opis, kapacitet, etikete, alkohol, pusenje, rezervacije, hendikep, kat_cena, ikona, datum, x,y FROM lokal where " + paramName + "!= '" + param + "'; ");
            if (t.Rows.Count == 0)
            {
                ToolTip ttip = new ToolTip();
                ttip.Show("Nije pronadjen ni jedan sadržaj parametra " + paramName + " sa imenom " + param + "!", lokaliListView, 3000);
                return;
            }
            else
            {
                //tipoviListView dodavanje ikona tipa + naziva tipa
                ImageList ikone = new ImageList();

                //dodamo sve ikone u lisu
                foreach (DataRow row in t.Rows)
                {
                    String tip_row = row["ime"].ToString();
                    String ico_row = row["ikona"].ToString();
                    if (ico_row.Equals(""))
                    {
                        DataTable tt = tip.GetDataTable("Select tip,opis,ikona from tip where tip= '" + row["tip"] + "';");
                        ico_row = tt.Rows[0]["ikona"].ToString();
                    }

                    ikone.Images.Add(tip_row, Image.FromFile(ico_row));
                }

                //kazemo tipoviListView-u da koristi listu ikona
                lokaliListView.LargeImageList = ikone;

                foreach (DataRow row in t.Rows)
                {
                    ListViewItem tmp = lokaliListView.Items.Add(row["ime"].ToString());
                    tmp.ImageKey = row["ime"].ToString();
                }
            }
        }



        private void filterButton_Click(object sender, EventArgs e)
        {

            deleteAllPb();
            if (FilterComboBox.SelectedIndex <= -1)
            {
                ToolTip t = new ToolTip();
                //t.SetToolTip();
                t.Show("Izaberite kategoriju po kojoj se pretražuje!", FilterComboBox, 3000);


                return;
            }
            else {
                
                
                //filter name
                if (FilterComboBox.SelectedItem.ToString() == "Ime" && string.IsNullOrWhiteSpace(filterTextBox.Text))
                {

                    ToolTip t = new ToolTip();
                    //t.SetToolTip();
                    t.Show("Unesite ime lokala!", FilterComboBox, 3000);
                    
                    
                }
                else if (FilterComboBox.SelectedItem.ToString() == "Ime" && !string.IsNullOrWhiteSpace(filterTextBox.Text))

                {
                    clearTable();
                    readTableWithParam("ime", filterTextBox.Text);

                    return;
                }

                //FILTER TIP
                
                else if (FilterComboBox.SelectedItem.ToString() == "Tip" && previewComboBox.SelectedIndex == -1)
              {

                    ToolTip t = new ToolTip();
                    //t.SetToolTip();
                    t.Show("Izaberite tip za pretragu!", FilterComboBox, 3000);


                }
                else if (FilterComboBox.SelectedItem.ToString() == "Tip" && previewComboBox.SelectedIndex > -1)
                {
                    clearTable();
                    readTableWithParam("tip", previewComboBox.SelectedItem.ToString());

                    return;
                }
            
                //FILTER ETIKETA

                else if (FilterComboBox.SelectedItem.ToString() == "Etiketa" && previewComboBox.SelectedIndex == -1)
                {

                    ToolTip t = new ToolTip();
                    //t.SetToolTip();
                    t.Show("Izaberi etiketu za pretragu!", FilterComboBox, 3000);


                }
                else if (FilterComboBox.SelectedItem.ToString() == "Etiketa" && previewComboBox.SelectedIndex > -1)
                {
                    clearTable();
                    
                    SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
                    DataTable tt = tip.GetDataTable("Select etikete from lokal;");
                    bool found;
                    foreach (DataRow d in tt.Rows) {
                        found = false;
                        String[] check = d["etikete"].ToString().Trim().Split(',');
                        foreach (String c in check)
                        {
                            if (c.Trim().Equals(previewComboBox.SelectedItem.ToString()))
                            {
                                found = true;
                                break;
                            }
                            
                        
                        }
                        if (found)
                        {
                            readTableWithParam("etikete", d["etikete"].ToString());
                        }
                        
                    }
                    
                    //readTableWithParam("etikete", filterTextBox.Text);

                    return;
                }

                //FILTER OZNAKA

                else if (FilterComboBox.SelectedItem.ToString() == "Oznaka" && string.IsNullOrWhiteSpace(filterTextBox.Text))
                {

                    ToolTip t = new ToolTip();
                    //t.SetToolTip();
                    t.Show("Unesite oznaku lokala!", FilterComboBox, 3000);


                }
                else if (FilterComboBox.SelectedItem.ToString() == "Oznaka" && !string.IsNullOrWhiteSpace(filterTextBox.Text))
                {
                    clearTable();
                    readTableWithParam("oznaka", filterTextBox.Text);

                    return;
                }

                //FILTER OPIS

                else if (FilterComboBox.SelectedItem.ToString() == "Opis" && string.IsNullOrWhiteSpace(filterTextBox.Text))
                {

                    ToolTip t = new ToolTip();
                    //t.SetToolTip();
                    t.Show("Unesite opis lokala!", FilterComboBox, 3000);


                }
                else if (FilterComboBox.SelectedItem.ToString() == "Opis" && !string.IsNullOrWhiteSpace(filterTextBox.Text))
                {
                    clearTable();
                    readTableWithParam("opis", filterTextBox.Text);

                    return;
                }

                //FILTER KAPACITET

                else if (FilterComboBox.SelectedItem.ToString() == "Kapacitet" && string.IsNullOrWhiteSpace(filterTextBox.Text))
                {

                    ToolTip t = new ToolTip();
                    //t.SetToolTip();
                    t.Show("Unesite kapacitet lokala!", FilterComboBox, 3000);


                }
                else if (FilterComboBox.SelectedItem.ToString() == "Kapacitet" && !string.IsNullOrWhiteSpace(filterTextBox.Text))
                {
                    clearTable();
                    readTableWithParam("kapacitet", filterTextBox.Text);

                    return;
                }

                //FILTER ALKOHOL

                else if (FilterComboBox.SelectedItem.ToString() == "Alkohol" && previewComboBox.SelectedIndex == -1)
                {

                    ToolTip t = new ToolTip();
                    //t.SetToolTip();
                    t.Show("Izaberite kategoriju alkohola za pretragu!", FilterComboBox, 3000);


                }
                else if (FilterComboBox.SelectedItem.ToString() == "Alkohol" && previewComboBox.SelectedIndex > -1)
                {
                    clearTable();
                    readTableWithParam("alkohol", previewComboBox.SelectedItem.ToString());

                    return;
                }

                //FILTER PUSENJE

                else if (FilterComboBox.SelectedItem.ToString() == "Pušenje" && previewComboBox.SelectedIndex == -1)
                {

                    ToolTip t = new ToolTip();
                    //t.SetToolTip();
                    t.Show("Izaberite kategoriju pušenja za pretragu!", FilterComboBox, 3000);


                }
                else if (FilterComboBox.SelectedItem.ToString() == "Pušenje" && previewComboBox.SelectedIndex > -1)
                {
                    clearTable();
                    readTableWithParam("pusenje", previewComboBox.SelectedItem.ToString());

                    return;
                }
                
                //FILTER REZERVACIJE
                
                else if (FilterComboBox.SelectedItem.ToString() == "Rezervacije" && previewComboBox.SelectedIndex == -1)
                {

                    ToolTip t = new ToolTip();
                    //t.SetToolTip();
                    t.Show("Izaberite kategoriju rezervacija za pretragu!", FilterComboBox, 3000);


                }
                else if (FilterComboBox.SelectedItem.ToString() == "Rezervacije" && previewComboBox.SelectedIndex > -1)
                {
                    clearTable();
                    String s;
                    if (previewComboBox.SelectedItem.ToString().Equals("Ne"))
                    {
                        s = "0";
                    }
                    else s = "1";

                    readTableWithParam("rezervacije", s);

                    return;
                }
            
            
                //FILTER CENE
                else if (FilterComboBox.SelectedItem.ToString() == "Cene" && previewComboBox.SelectedIndex == -1)
                {

                    ToolTip t = new ToolTip();
                    //t.SetToolTip();
                    t.Show("Izaberite kategoriju cena za pretragu!", FilterComboBox, 3000);


                }
                else if (FilterComboBox.SelectedItem.ToString() == "Cene" && previewComboBox.SelectedIndex > -1)
                {
                    clearTable();
                    readTableWithParam("kat_cena", previewComboBox.SelectedItem.ToString());

                    return;
                }

                //FILTER DATUM
                
                else if (FilterComboBox.SelectedItem.ToString() == "Datum")
                {
                    clearTable();
                    DateTime s = dateTimePicker1.Value;
                    TimeSpan t = new TimeSpan(00, 0, 0);
                    s = s.Date + t;

                    readTableWithParam("datum", s.ToString());

                    return;
                }

                //FILTER HENDIKEP
                else if (FilterComboBox.SelectedItem.ToString() == "Hendikepirani" && previewComboBox.SelectedIndex == -1)
                {

                    ToolTip t = new ToolTip();
                    //t.SetToolTip();
                    t.Show("Izaberite kategoriju hendikepiranih za pretragu!", FilterComboBox, 3000);


                }
                else if (FilterComboBox.SelectedItem.ToString() == "Hendikepirani" && previewComboBox.SelectedIndex > -1)
                {
                    clearTable();
                    String s;
                    if (previewComboBox.SelectedItem.ToString().Equals("Ne"))
                    {
                        s = "0";
                    }
                    else s = "1";

                    readTableWithParam("hendikep", s);

                    return;
                }
            
                //FILTER NA MAPI

                else if (FilterComboBox.SelectedItem.ToString() == "Na mapi" && previewComboBox.SelectedIndex == -1)
                {

                    ToolTip t = new ToolTip();
                    //t.SetToolTip();
                    t.Show("Izaberite kategoriju za pretragu!", FilterComboBox, 3000);


                }
                else if (FilterComboBox.SelectedItem.ToString() == "Na mapi" && previewComboBox.SelectedIndex > -1)
                {
                    clearTable();
                    String x = "-1";
                    if (previewComboBox.SelectedItem.ToString().Equals("Ne"))
                    {
                        readTableWithParam("x", x);

                    }
                    else {
                        readTableWithParamNotEqual("x", x);
                    }


                    return;
                }
            
                //FILTER IKONE
                
                else if (FilterComboBox.SelectedItem.ToString() == "Ikona" && previewComboBox.SelectedIndex == -1)
                {

                    ToolTip t = new ToolTip();
                    //t.SetToolTip();
                    t.Show("Izaberite ikonu za pretragu!", FilterComboBox, 3000);


                }
                else if (FilterComboBox.SelectedItem.ToString() == "Ikona" && previewComboBox.SelectedIndex > -1)
                {
                    clearTable();
                    SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
                    tip.TestConnection();
                    DataTable t = tip.GetDataTable("SELECT ime, tip, oznaka, opis, kapacitet, etikete, alkohol, pusenje, rezervacije, hendikep, kat_cena, ikona, datum, x,y FROM lokal where  ikona = '"+previewComboBox.SelectedItem.ToString()+"'; ");
                    if (t.Rows.Count < 1)
                        readTableWithParamTIP("ikona", previewComboBox.SelectedItem.ToString());
                    else
                        readTableWithParam("ikona", previewComboBox.SelectedItem.ToString());
                    return;
                }
                //FILTER SVE
                else if (FilterComboBox.SelectedItem.ToString() == "Prikaži sve")
                {
                    clearTable();
                    readTable();
                    return;
                }

            }
            

        }
        private void readTableWithParamTIP(String paramName, String param)
        {
            SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
            tip.TestConnection();
            DataTable t = tip.GetDataTable("SELECT tip,ikona FROM tip where " + paramName + "= '" + param + "'; ");
            if (t.Rows.Count == 0)
            {
                ToolTip ttip = new ToolTip();
                ttip.Show("Nije pronadjen ni jedan sadržaj parametra " + paramName + " sa imenom " + param + "!", lokaliListView, 3000);
                return;
            }
            else
            {

                //tipoviListView dodavanje ikona tipa + naziva tipa
                ImageList ikone = new ImageList();
                DataTable tt = tip.GetDataTable("SELECT ime,tip FROM lokal where tip ='" + t.Rows[0]["tip"].ToString() + "'; ");
                String icooo = t.Rows[0]["ikona"].ToString();
                //dodamo sve ikone u lisu
                foreach (DataRow row in tt.Rows)
                {
                    String tip_row = row["ime"].ToString();
                    String ico_row = icooo;

                    ikone.Images.Add(tip_row, Image.FromFile(ico_row));
                }

                //kazemo tipoviListView-u da koristi listu ikona
                lokaliListView.LargeImageList = ikone;

                foreach (DataRow row in tt.Rows)
                {
                    ListViewItem tmp = lokaliListView.Items.Add(row["ime"].ToString());
                    tmp.ImageKey = row["ime"].ToString();
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pusenjeLabel_Click(object sender, EventArgs e)
        {

        }

        private void deleteEntery_Click(object sender, EventArgs e)
        {
            String wop = lokaliListView.SelectedItems[0].Text.Trim();
            SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
            tip.TestConnection();
            tip.Delete("Lokal", "ime = '" + wop.Trim() + "'");
            clearTable();
            readTable();
            Refresh();


                
        }

        private void IzmeniButton_Click(object sender, EventArgs e)
        {
            String wop = lokaliListView.SelectedItems[0].Text.Trim();


            
            DodavanjeKafica t = new DodavanjeKafica(wop);
            t.ShowDialog(this);
            //this.Close();
            clearTable();
            readTable();
            Refresh();

        }

        private void LokalPrikaz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                // the user pressed the F1 key
                HelpNavigator navigator = HelpNavigator.TopicId;
                Help.ShowHelp(this, "help.chm", navigator, "68");
            }
        }

       }
}
