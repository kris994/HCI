using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Mapa_Kafića
{
    public partial class customPB : PictureBox
    {

        ToolTip tt;
        private string name;
        ContextMenu m;
        Color[] colors;
        string ico;
        public customPB(String name, String color, String ico, Point p)
        {
            InitializeComponent();
            Width = 32;
            Height = 32;
            //BackColor = Color.FromName(color);
            this.ico = ico;
            String[] c = color.Split(' ');
            int l = 0;
            for (int i = 0; i < c.Length; i++)
            {
                if (!c[i].Equals(""))
                {
                    l++;
                }
            }

            colors = new Color[l];
            int w = 0;
            for (int i = 0; i < c.Length; i++)
            {
                if (!c[i].Equals(""))
                {
                    colors[w] = Color.FromName(c[i].Trim());
                    w++;
                }
            }

            if (l == 1)
            { BackColor = colors[0]; }

            
            
            ImageLocation = ico;
            Left = p.X - 16;
            Top = p.Y - 16;
            

                //gradient
                //LinearGradientBrush br = new LinearGradientBrush(this.ClientRectangle, Color.Black, Color.Black, 0, false);
                //ColorBlend cb = new ColorBlend();
                //cb.Positions = new[] { 0, 1 / 6f, 2 / 6f, 3 / 6f, 4 / 6f, 5 / 6f, 1 };
                //cb.Colors = new[] { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Indigo, Color.Violet };
                //br.InterpolationColors = cb;
                //// rotate
                //br.RotateTransform(45);
                //// paint
                //e.Graphics.FillRectangle(br, this.ClientRectangle);


                this.name = name;
            tt = new ToolTip();
            //The below are optional, of course,

            //tt.ToolTipIcon = ToolTipIcon.Info;
            
            tt.SetToolTip(this, name);

            //contex menu
            m = new ContextMenu();
            MenuItem update = new MenuItem("Izmeni lokal");
            MenuItem delete = new MenuItem("Obriši lokal");
            //m.MenuItems.Add(update);
            m.MenuItems.Add(delete);


            // Add functionality to the menu items using the Click event. 
           // update.Click += new System.EventHandler(this.update_Click);
            //delete.Click += new System.EventHandler(this.delete_Click);
            
        }

        protected override void OnMouseHover(EventArgs e)
        {
            tt.Show(name,this);
            base.OnMouseHover(e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.DrawImage(Image.FromFile(ico), 0, 0, 32,32);
            if (colors.Length > 1)
            {
                LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.Black, Color.Black, 0, false);
                ColorBlend cb = new ColorBlend();
                cb.Positions = calcPos(colors);
                cb.Colors = colors;
                brush.InterpolationColors = cb;
                pe.Graphics.FillRectangle(brush, this.ClientRectangle);

                base.OnPaint(pe);
            }

        }


        private float[] calcPos(Color[] c){
            int l = c.Length;
            float[] wop = new float[l];
            wop[0] = 0;
            wop[l - 1] = 1;
            for (int i = 1; i < l-1; i++)
            {
                wop[i] = i / (float)(l - 1);
            }
                return wop;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                m.Show(this, e.Location);
                
            }
            
        }


        /*private void update_Click(object sender, System.EventArgs e)
        {
            // Create a new OpenFileDialog and display it.
            this.BackColor = Color.Black;
        }*/

        private void delete_Click(object sender, System.EventArgs e)
        {

            SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
            tip.TestConnection();
            
            //ovde smestamo listu ikona;
            ImageList ikone = new ImageList();
            
            //promena koordinata na vrednosti ako ne postoje u tabeli

            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("x", "-1");
            d.Add("y", "-1");
            tip.Update("Lokal",d,"ime =+ '"+name+"'");

            //otvaramo tabelu

            DataTable t = tip.GetDataTable("SELECT ime,etikete,tip,ikona,x,y FROM Lokal WHERE ime='" + name + "'; ");

            //pravimo i string za boju i ujedno je trazimo kada trazimo tip
            String[] boje = new String[t.Rows.Count];
            int i = 0;
            foreach (DataRow r in t.Rows)
            {
            
                if (r["ikona"].Equals(""))
                {
                    DataTable tipTabela = tip.GetDataTable("SELECT ikona FROM tip where tip='" + r["tip"] + "';");
                    DataRow tr = tipTabela.Rows[0];
                    ikone.Images.Add(r["ime"].ToString(), Image.FromFile(tr["ikona"].ToString()));
                }
                else
                {

                    //TODO 1: ukoliko postoji ikona
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
            //lokaliListView.LargeImageList = ikone;
            int j = 0;
            //sve povezemo zajedno
            foreach (DataRow r in t.Rows)
            {
                //ako su stavljene ne dodajemo ih nazad
                if (Convert.ToInt32(r["x"]) != -1) { continue; }
                //ListViewItem it = lokaliListView.Items.Add(r["ime"].ToString());
                ListViewItem it = new ListViewItem();
                it.Name = r["ime"].ToString();
                it.Text = r["ime"].ToString();
                // it.ForeColor = Color.FromName(boje[j]);
                j++;
                it.ImageKey = r["ime"].ToString();

                Pocetna p = (Pocetna)Application.OpenForms[0];
                p.addToList(it);





            }

            this.Enabled = false;
            this.Visible = false;
        }

        private DataTable getLokalInfo(String name) { return null; }
    }
}
