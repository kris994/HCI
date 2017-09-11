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
    public partial class EtiketaPrikaz : Form
    {

        public EtiketaPrikaz()
        {

            InitializeComponent();
            readTable();
        }

        private void readTable()
        {

            SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
            tip.TestConnection();
            DataTable t = tip.GetDataTable("SELECT etiketa,boja FROM etiketa; ");

            //tipoviListView dodavanje ikona tipa + naziva tipa
            //ImageList ikone = new ImageList();

            //pravimo novi list view item i dodeljujemo mu boju
            foreach (DataRow row in t.Rows)
            {

                ListViewItem it = new ListViewItem();

                it.ForeColor = Color.FromName(row["boja"].ToString());
                it.Text = row["etiketa"].ToString();
                etiketeListView.Items.Add(it);

            }

        }


        private void enterEntery_Click(object sender, EventArgs e)
        {

            DodajEtiketu t = new DodajEtiketu();
            t.ShowDialog(this);

            clearTable();
            readTable();
            Refresh();
            
        }

        private void clearTable() {

            for (int i = etiketeListView.Items.Count - 1; i >= 0; i--)
                etiketeListView.Items.RemoveAt(i);


        }

        private void deleteEntery_Click(object sender, EventArgs e)
        {

            try
            {
                String wop = etiketeListView.SelectedItems[0].Text.Trim();
                List<String> nadjene_etikete = new List<string>();

                SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
                tip.TestConnection();
                DataTable testt = tip.GetDataTable("select ime,etikete from lokal;");
                for (int i = 0; i < testt.Rows.Count; i++) {

                    String[] trenutneEtikete = testt.Rows[i]["etikete"].ToString().Split(',');
                    
                    foreach(String current in trenutneEtikete){
                        if (current.Trim().Equals(wop))
                        {
                            nadjene_etikete.Add(testt.Rows[i]["ime"].ToString());
                        }
                    }

                }


                if (nadjene_etikete.Count > 0)
                {
                    String lok = "";
                    foreach (String r in nadjene_etikete)
                    {
                        lok += r + ", ";
                    }
                    ToolTip t = new ToolTip();
                    t.Show("Nije moguće obrisati tip zato što je dodeljen " + lok + "lokalu/lokalima!", deleteEntery, 3000);
                    return;
                }
                else
                {
                    tip.Delete("Etiketa", "etiketa = '" + wop + "'");
                    clearTable();
                    readTable();
                    //EtiketaPrikaz p = new EtiketaPrikaz();
                    //p.Show();
                    Refresh();
                }
            }
            catch (NullReferenceException n)
            {
                this.Close();
                EtiketaPrikaz p = new EtiketaPrikaz();
                p.Show();
            }
            catch (ArgumentOutOfRangeException a)
            {
                //String wop = tipTable.Rows[0].Cells[0].Value.ToString();
                SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
                tip.TestConnection();
                //tip.Delete("Etiketa", "etiketa = '" + wop + "'");
                this.Close();
                EtiketaPrikaz p = new EtiketaPrikaz();
                p.Show();
            }
           


        }

        private void EtiketaPrikaz_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void EtiketaPrikaz_Load(object sender, EventArgs e)
        {
            deleteEntery.Enabled = false;
            IzmeniButton.Enabled = false;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(EtiketaPrikaz_KeyDown);
        }

        private void etiketeListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (etiketeListView.SelectedItems.Count == 0)
            {
                deleteEntery.Enabled = false;
                IzmeniButton.Enabled = false;
                ImeLabel.Text = "nije selektovana ni jedna etiketa";
                opisLabel.Text = "nije selektovana ni jedna etiketa";
                bojaLabel.Text = "nije selektovana ni jedna etiketa";
                bojaLabel.ForeColor = Color.Black;
            }
            else
            {
                deleteEntery.Enabled = true;
                IzmeniButton.Enabled = true;

                String wop = etiketeListView.SelectedItems[0].Text.Trim();

                SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
                tip.TestConnection();
                DataTable t = tip.GetDataTable("Select etiketa,opis,boja from etiketa where etiketa= '"+wop+"';");
                
                ImeLabel.Text = t.Rows[0]["etiketa"].ToString();
                opisLabel.Text = t.Rows[0]["opis"].ToString();
                bojaLabel.Text = t.Rows[0]["boja"].ToString();
                bojaLabel.ForeColor = Color.FromName(t.Rows[0]["boja"].ToString());

            }
        }

        private void InfoPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            if (FilterComboBox.SelectedItem.ToString() == "Prikaži sve")
            {
                filterTextBox.Visible = false;
                //previewComboBox.Visible = false;
                //previewPictureBox.Visible = false;
                filterTextBox.Text = "dd";
                return;

            }

            else
            {
                filterTextBox.Visible = true;
                //previewPictureBox.Visible = false;
                //previewComboBox.Visible = false;
                //filterTextBox.Text = "";
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(filterTextBox.Text))
            {
                ToolTip t = new ToolTip();
                //t.SetToolTip();

                //t.AutoPopDelay = 300;
                t.Show("Tekstualno polje ne sme ostati prazno!", filterTextBox, 3000);

                t.UseFading = true;


                return;
            }

            if (FilterComboBox.SelectedIndex <= -1)
            {
                ToolTip t = new ToolTip();
                //t.SetToolTip();
                t.Show("Izaberite kategoriju po kojoj se pretražuje!", FilterComboBox, 3000);


                return;
            }

            if (FilterComboBox.SelectedItem.ToString() == "Ime")
            {
                clearTable();
                readTableWithParam("etiketa", filterTextBox.Text);
                return;
            }

            if (FilterComboBox.SelectedItem.ToString() == "Opis")
            {
                clearTable();
                readTableWithParam("opis", filterTextBox.Text);
                return;
            }

            if (FilterComboBox.SelectedItem.ToString() == "Boja")
            {
                clearTable();
                readTableWithParam("boja", filterTextBox.Text);
                return;
            }

            if (FilterComboBox.SelectedItem.ToString() == "Prikaži sve")
            {
                clearTable();
                readTable();
                return;
            }
        }

        private void readTableWithParam(string paramName, string param)
        {
            SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
            tip.TestConnection();
            DataTable t = tip.GetDataTable("SELECT etiketa,boja FROM etiketa where " + paramName + " ='" + param + "'; ");

            //tipoviListView dodavanje ikona tipa + naziva tipa
            //ImageList ikone = new ImageList();
            if (t.Rows.Count == 0)
            {
                ToolTip ttip = new ToolTip();
                ttip.Show("Nije pronadjen ni jedan sadržaj parametra " + paramName + " sa imenom " + param + "!", etiketeListView, 3000);
                return;
            }
            else
            {
                //pravimo novi list view item i dodeljujemo mu boju
                foreach (DataRow row in t.Rows)
                {

                    ListViewItem it = new ListViewItem();

                    it.ForeColor = Color.FromName(row["boja"].ToString());
                    it.Text = row["etiketa"].ToString();
                    etiketeListView.Items.Add(it);

                }
            }
        }

        private void IzmeniButton_Click(object sender, EventArgs e)
        {
            String wop = etiketeListView.SelectedItems[0].Text.Trim();



            DodajEtiketu t = new DodajEtiketu(wop);
            t.ShowDialog(this);
            //this.Close();
            clearTable();
            readTable();
            Refresh();
        }

        private void EtiketaPrikaz_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                // the user pressed the F1 key
                HelpNavigator navigator = HelpNavigator.TopicId;
                Help.ShowHelp(this, "help.chm", navigator, "236");
            }
        }
        }
}
