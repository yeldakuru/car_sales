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
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection("server=YELDA\\SQLEXPRESS; initial catalog = otoKiraDB;integrated security = sspi");
        SqlCommand cmd;
        SqlDataAdapter da;
        public Form5()
        {
            InitializeComponent();
        }

     

        private void button1_Click(object sender, EventArgs e)
        { 
            da = new SqlDataAdapter("select * from arabalar WHERE Marka like '" + textBox1.Text + "'", con);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView4.DataSource = tablo;
            

        }
    }
}
