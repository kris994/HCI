using ClosedXML.Excel;
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
    public partial class PrikazTabelarno : Form
    {
        DataTable t1;
        DataTable t2;
        DataTable t3;
        
        public PrikazTabelarno()
        {
            InitializeComponent();
             
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void PrikazTabelarno_Load(object sender, EventArgs e)
        {
            SQLiteDatabase tip = new SQLiteDatabase("", "baza.s3db");
            tip.TestConnection();
            t1 = tip.GetDataTable("SELECT tip,opis,ikona FROM tip; ");
            t2 = tip.GetDataTable("SELECT ime,tip,oznaka,opis,kapacitet,etikete,alkohol,pusenje,rezervacije,hendikep,kat_cena,datum FROM lokal; ");
            t3 = tip.GetDataTable("Select etiketa, opis,boja from etiketa ");

            dataGridView1.DataSource = t1;
            dataGridView2.DataSource = t2;
            dataGridView3.DataSource = t3;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            XLWorkbook table1 = new XLWorkbook();
            XLWorkbook table2 = new XLWorkbook();
            XLWorkbook table3 = new XLWorkbook();
            table1.Worksheets.Add(t1, "tip");
            table2.Worksheets.Add(t2, "lokal");
            table3.Worksheets.Add(t3, "etikete");

            table1.SaveAs("tip.xlsx");
            table2.SaveAs("lokal.xlsx");
            table3.SaveAs("etikete.xlsx");


            this.Close();
        }
    }
}
