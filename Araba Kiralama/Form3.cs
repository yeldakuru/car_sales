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
    public partial class Form3 : Form
    {

        SqlConnection con = new SqlConnection("server=YELDA\\SQLEXPRESS; initial catalog = otoKiraDB;integrated security = sspi");
        SqlCommand cmd;
        SqlDataAdapter da;

       

        public Form3()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
          

             listele();  

        }
        void listele() //bu fonksiyon datagridview e verileri listelesin
        {
            da = new SqlDataAdapter("select * from arabalar ", con);
          
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView3.DataSource = tablo;

            

        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
         


        }

        private void button2_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select * from Müşteriler ", con);

            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView3.DataSource = tablo;

        }
    }
}
    


