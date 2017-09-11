using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Mapa_Kafića.Properties;
using System.Threading;
using System.IO;

namespace Mapa_Kafića
{
    public partial class TipPrikaz : Form
    {
       private bool isButtonPressed;
       private string ime;

        public TipPrikaz()
        {
            this.isButtonPressed = false;
            InitializeComponent();
            readTable();
            //filterButton.Enabled = false;
            IzmeniButton.Enabled = false;


            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void readTable() {

            SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
            tip.TestConnection();
            DataTable t = tip.GetDataTable("SELECT tip,ikona FROM tip; ");
            
            //tipoviListView dodavanje ikona tipa + naziva tipa
            ImageList ikone = new ImageList();

            //dodamo sve ikone u lisu
            foreach (DataRow row in t.Rows)
            {
                String tip_row = row["tip"].ToString();
                String ico_row = row["ikona"].ToString();

                ikone.Images.Add(tip_row, Image.FromFile(ico_row));
            }

            //kazemo tipoviListView-u da koristi listu ikona
            tipoviListView.LargeImageList = ikone;

            foreach (DataRow row in t.Rows)
            {
                ListViewItem tmp = tipoviListView.Items.Add(row["tip"].ToString());
                tmp.ImageKey = row["tip"].ToString();
            }
        }

        private void TipPrikaz_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(TipPrikaz_KeyDown);
            
            deleteEntery.Enabled = false;
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

        private void clearTable() {
            for (int i = tipoviListView.Items.Count - 1; i >= 0; i--)
                tipoviListView.Items.RemoveAt(i);

        
        }

        private void enterEntery_Click(object sender, EventArgs e)
        {
            isButtonPressed = true;
            Tip t = new Tip();
            t.ShowDialog(this);
            //this.Close();
            clearTable();
            readTable();
            Refresh();
        }

        private void TipPrikaz_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void deleteEntery_Click(object sender, EventArgs e)
        {
            isButtonPressed = true;
            try
            {


                String wop = tipoviListView.SelectedItems[0].Text.Trim();
                SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
                tip.TestConnection();

                //proveravamo da li se vec koristi
                DataTable testt = tip.GetDataTable("select ime from lokal where tip ='" + wop + "';");
                if (testt.Rows.Count > 0)
                {
                    String lok = "";
                    foreach (DataRow r in testt.Rows) {
                        lok += r["ime"].ToString()+ " ";
                    }
                    ToolTip t = new ToolTip();
                    t.Show("Nije moguće obrisati tip zato što je dodeljen " + lok + "lokalu/lokalima!",deleteEntery,3000);
                    return;
                }
                else
                {
                    tip.Delete("Tip", "tip = '" + wop.Trim() + "'");
                    clearTable();
                    readTable();
                    Refresh();
                    //this.Close();
                    //TipPrikaz p = new TipPrikaz();
                    //p.Show();
                }
            }
            catch (NullReferenceException n)
            {
                this.Close();
                TipPrikaz p = new TipPrikaz();
                p.Show();
            }
            catch (ArgumentOutOfRangeException a)
            {
                //String wop = tipTable.Rows[0].Cells[0].Value.ToString();
                SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
                tip.TestConnection();
                //tip.Delete("Tip", "tip = '" + wop + "'");
                this.Close();
                TipPrikaz p = new TipPrikaz();
                p.Show();
            }
           


        }

        private void tipoviListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tipoviListView_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (tipoviListView.SelectedItems.Count == 0)
            {
                deleteEntery.Enabled = false;
                IzmeniButton.Enabled = false;
                ImeLabel.Text = "nije selektovan ni jedan tip";
                opisLabel.Text = "nije selektovan ni jedan tip";
                icoPictureBox.Image = icoPictureBox.InitialImage;
            }
            else
            {
                deleteEntery.Enabled = true;
                IzmeniButton.Enabled = true;


                String wop = tipoviListView.SelectedItems[0].Text.Trim();

                SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
                tip.TestConnection();
                DataTable t = tip.GetDataTable("Select tip,opis,ikona from tip where tip= '" + wop + "';");

                ImeLabel.Text = t.Rows[0]["tip"].ToString();
                opisLabel.Text = t.Rows[0]["opis"].ToString();
                //bojaLabel.Text = t.Rows[0]["boja"].ToString();
                //bojaLabel.ForeColor = Color.FromName(t.Rows[0]["boja"].ToString());
                icoPictureBox.Image = Image.FromFile(t.Rows[0]["ikona"].ToString());
            }
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(filterTextBox.Text)) {
                ToolTip t = new ToolTip();
                //t.SetToolTip();

                //t.AutoPopDelay = 300;
                t.Show("Tekstualno polje ne sme ostati prazno!",filterTextBox,3000);
                
                t.UseFading = true;


                return;
            }

            if(FilterComboBox.SelectedIndex <= -1){
            ToolTip t = new ToolTip();
                //t.SetToolTip();
                t.Show("Izaberite kategoriju po kojoj se pretražuje!",FilterComboBox,3000);


                return;
            }
            
            if (FilterComboBox.SelectedItem.ToString() == "Ime")
            {
                clearTable();
                readTableWithParam("tip", filterTextBox.Text);
                return;
            }

            if (FilterComboBox.SelectedItem.ToString() == "Opis")
            {
                clearTable();
                readTableWithParam("opis", filterTextBox.Text);
                return;
            }

            if (FilterComboBox.SelectedItem.ToString() == "Ikona")
            {
                clearTable();
                readTableWithParam("ikona", previewComboBox.Text);
                return;
            }

            if (FilterComboBox.SelectedItem.ToString() == "Prikaži sve")
            {
                clearTable();
                readTable();
                return;
            }
        }

        private void readTableWithParam(String paramName, String param) {
            SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
            tip.TestConnection();
            DataTable t = tip.GetDataTable("SELECT tip,ikona FROM tip where "+paramName+"= '"+param+"'; ");
            if (t.Rows.Count == 0)
            {
                ToolTip ttip = new ToolTip();
                ttip.Show("Nije pronadjen ni jedan sadržaj parametra " + paramName + " sa imenom " + param + "!",tipoviListView,3000);
                return;
            }
            else
            {
                //tipoviListView dodavanje ikona tipa + naziva tipa
                ImageList ikone = new ImageList();

                //dodamo sve ikone u lisu
                foreach (DataRow row in t.Rows)
                {
                    String tip_row = row["tip"].ToString();
                    String ico_row = row["ikona"].ToString();

                    ikone.Images.Add(tip_row, Image.FromFile(ico_row));
                }

                //kazemo tipoviListView-u da koristi listu ikona
                tipoviListView.LargeImageList = ikone;

                foreach (DataRow row in t.Rows)
                {
                    ListViewItem tmp = tipoviListView.Items.Add(row["tip"].ToString());
                    tmp.ImageKey = row["tip"].ToString();
                }
            }
        }

        private void FilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FilterComboBox.SelectedItem.ToString() == "Ikona")
            {
                filterTextBox.Visible = false;
                //filterTextBox.Text = "";
                previewPictureBox.Visible = true;
                previewComboBox.Visible = true;
                return;
            }
            else if (FilterComboBox.SelectedItem.ToString() == "Prikaži sve") {
                filterTextBox.Visible = false;
                previewComboBox.Visible = false;
                previewPictureBox.Visible = false;
                filterTextBox.Text = "dd";
                return;
                
            }

            else
            {
                filterTextBox.Visible = true;
                previewPictureBox.Visible = false;
                previewComboBox.Visible = false;
                //filterTextBox.Text = "";
                return;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            previewPictureBox.Image = Image.FromFile(previewComboBox.Text);

        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void IzmeniButton_Click(object sender, EventArgs e)
        {
            String wop = tipoviListView.SelectedItems[0].Text.Trim();

            
            isButtonPressed = true;
            Tip t = new Tip(wop);
            t.ShowDialog(this);
            //this.Close();
            clearTable();
            readTable();
            Refresh();
        }

        private void TipPrikaz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                // the user pressed the F1 key
                HelpNavigator navigator = HelpNavigator.TopicId;
                Help.ShowHelp(this, "help.chm", navigator, "183");
            }
        }
    }
}
