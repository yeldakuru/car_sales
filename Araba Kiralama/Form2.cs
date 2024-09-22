using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Araba_Kiralama
{
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection("server=YELDA\\SQLEXPRESS; initial catalog = otoKiraDB;integrated security = sspi");
        SqlCommand cmd;
        SqlDataAdapter da;

        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            listele();


        }
        void temizle()
        {
            txmüsteri.Text = "";
            txmüsterisoyadı.Text = "";
            txtelefon.Text = "";
            txadres.Text = "";
        

        }
        void listele() //bu fonksiyon datagridview e verileri listelesin
        {
            da = new SqlDataAdapter("select * from Müşteriler ", con);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView2.DataSource = tablo;
            //temizle();
        }
        private void form1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into Müşteriler(MüşteriAdı,MüşteriSoyadı,Telefon,Adres,AlınanPlaka)values ('" + txmüsteri.Text + "','" + txmüsterisoyadı.Text + "','" + txtelefon.Text + "','" +txadres.Text + txalınanplaka+  "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Eklendi");
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand(" DELETE  from Müşteriler where id ='" + int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString()) + "'  ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt silindi");
            listele();
        }
    }
}
