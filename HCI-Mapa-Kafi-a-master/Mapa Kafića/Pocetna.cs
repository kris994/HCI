using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
//using Finisar.SQLite;

namespace Mapa_Kafića
{
    public partial class Pocetna : Form
    {
        String imageLocation;
        //ListViewItem item;
        String itemName;
        String itemColor;
        List<customPB> pb;
        
        
        public Pocetna()
        {
            
            InitializeComponent();
            this.pb = new List<customPB>();
            readTable();
            //this.pb = new List<customPB>();
            this.imageLocation = "";
          //  this.item = new ListViewItem();
            //this.itemName = "";
          this.itemColor = "";
          Refresh();
        }




        public void addToList(ListViewItem it) {
            lokaliListView.Items.Add(it);
            lokaliListView.Refresh();
        }

        public Pocetna(ListViewItem it) {
            InitializeComponent();
            readTable();
            this.imageLocation = "";
            this.itemColor = "";
            lokaliListView.Items.Add(it);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TipPrikaz t = new TipPrikaz();
            t.ShowDialog(this);
            //deleteAllPb();
            clearTable();
            readTable();
            refreshList();
            Refresh();
            
            
        }
        public void clearTable() {

            deleteAllPb();
            for (int i = lokaliListView.Items.Count-1; i >= 0; i--)
                lokaliListView.Items.RemoveAt(i);


        }

        public void deleteAllPb() {
            foreach (customPB p in pb)
            {
                mapPicture.Controls.Remove(p);
                //pb.Remove(p);
            }
            pb.Clear();
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
            foreach (DataRow r in t.Rows) {

                //ako je na tabeli
                //if(r["na_tabeli"].Equals(1) {continue;}
               //ako ikona ne postoji stavljamo ikonu tipa
                if (r["ikona"].Equals("")) {
                    DataTable tipTabela = tip.GetDataTable("SELECT ikona FROM tip where tip='" + r["tip"] + "';");
                    DataRow tr = tipTabela.Rows[0];
                    ikone.Images.Add(r["ime"].ToString(), Image.FromFile(tr["ikona"].ToString()));
                }
                else
                {

                    //TODO 1: ukoliko postoji ikona
                    ikone.Images.Add(r["ime"].ToString(), Image.FromFile(r["ikona"].ToString())) ;
                }
                //svakako iz ove tabele vucemo boju
                DataTable etiketaTabela = tip.GetDataTable("SELECT boja FROM etiketa WHERE etiketa = '" + r["etikete"].ToString().Split(',')[0] + "'");
                String boja;
                if (etiketaTabela.Rows.Count == 0) {
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
                if(Convert.ToInt32(r["x"]) != -1 ) {
                    String name = r["ime"].ToString();
                    String color = "";
                        for (int w = 0; w < getLokalColor(name).Length; w++) {
                            color += getLokalColor(name)[w]+" ";
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
                    pbox.Show();
                    pb.Add(pbox);
                    mapPicture.Controls.Add(pbox);





                    continue;}
                ListViewItem it = lokaliListView.Items.Add(r["ime"].ToString());
                
               // it.ForeColor = Color.FromName(boje[j]);
                j++;
                it.ImageKey = r["ime"].ToString();
                

                

            }

        
        }

        public void refreshList() {
            lokaliListView.Refresh();
        }
        
        private void Pocetak_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Pocetna_KeyDown);
        }
        
        // Call the base class
      
        private void button1_Click(object sender, EventArgs e)
        {
            LokalPrikaz f = new LokalPrikaz();
            f.ShowDialog(this);
            //deleteAllPb();
            clearTable();
            readTable();
            refreshList();
            Refresh();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            EtiketaPrikaz t = new EtiketaPrikaz();
            t.ShowDialog(this);
            //deleteAllPb();
            clearTable();
            readTable();
            refreshList();
            Refresh();
            
        }

        private void Pocetna_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Pocetna_DragDrop(object sender, DragEventArgs e)
        {
            int x = this.PointToClient(new Point(e.X, e.Y)).X;

            int y = this.PointToClient(new Point(e.X, e.Y)).Y;

            if (x >= mapPicture.Location.X && x <= mapPicture.Location.X + mapPicture.Width && y >= mapPicture.Location.Y && y <= mapPicture.Location.Y + mapPicture.Height)
            //???
            {

                Point point = mapPicture.PointToClient(Cursor.Position);

                customPB pb = new customPB(itemName,itemColor,imageLocation,point);
                this.pb.Add(pb);
                itemColor = "";
                mapPicture.Controls.Add(pb);
                lokaliListView.SelectedItems[0].Remove();
                lokaliListView.Refresh();

                //cuvanje lokala, odnosno njihovih koordinata
                Dictionary<string, string> d = new Dictionary<string, string>();
                d.Add("x",point.X.ToString());
                d.Add("y", point.Y.ToString());
                SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
                tip.Update("Lokal", d, "ime ='" + itemName + "'");
            }
        }

        private void Pocetna_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void lokaliListView_MouseDown(object sender, MouseEventArgs e)
        {
            //System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; 
            if (lokaliListView.SelectedItems.Count == 1) 
                button1.DoDragDrop(button1.Text, DragDropEffects.Copy | DragDropEffects.Move);
        
        }

        private void lokaliListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lokaliListView.SelectedItems.Count == 1)
            {
                //if (item == null)
                ListViewItem item = lokaliListView.SelectedItems[0];
                itemName = item.Text;
                //itemColor = getLokalColor(itemName);
                for (int i = 0; i < getLokalColor(itemName).Length; i++) {
                    itemColor += getLokalColor(itemName)[i]+" ";
                }
                    imageLocation = getLokalImage(itemName);
            }
        }

        private String[] getLokalColor(String name)
        {
            SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
            tip.TestConnection();
            
            DataTable t = tip.GetDataTable("SELECT ime, etikete, tip, ikona FROM Lokal WHERE ime ='"+name+"'; ");
            String[] etikete = t.Rows[0]["etikete"].ToString().Split(',');
            String[] boje = new String[etikete.Length];

            for (int i = 0; i < etikete.Length; i++ )
            {

                if (!etikete[i].Trim().Equals(""))
                {
                    DataTable e = tip.GetDataTable("SELECT boja FROM etiketa WHERE etiketa ='" + etikete[i].Trim() + "'; ");
                    boje[i] = e.Rows[0]["boja"].ToString();
                }
            }

            return boje;
        }

        private String getLokalImage(string name) {

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

        private void lokaliListView_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (e.Effect == DragDropEffects.Move)
            {
                e.UseDefaultCursors = false;
                Cursor.Current = Cursors.Hand;
            }
            else if (e.Effect == DragDropEffects.Copy)
            {
                e.UseDefaultCursors = false;
                Cursor.Current = Cursors.Cross;
            }
            else if (e.Effect == DragDropEffects.None)
            {
                e.UseDefaultCursors = false;
                Cursor.Current = Cursors.No;
            }
            else
            {
                e.UseDefaultCursors = true;
            }
        }

        private void mapPicture_DoubleClick(object sender, EventArgs e)
        {

        }

        private void mapPicture_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TutorialIntro t = new TutorialIntro();
            t.ShowDialog(this);
            //this.Close();
        }

        private void Pocetna_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "F1")
            {
                // the user pressed the F1 key
                HelpNavigator navigator = HelpNavigator.TopicId;
                Help.ShowHelp(this,  "help.chm", navigator, "12");
            }
        }

            }
}
