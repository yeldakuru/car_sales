using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Araba_Kiralama
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("server=YELDA\\SQLEXPRESS; initial catalog = otoKiraDB;integrated security = sspi");
        SqlCommand cmd;
        SqlDataAdapter da ;  


        void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.Text = "";
            pictureBox1.ImageLocation = "";

        }
        void listele () //bu fonksiyon datagridview e verileri listelesin
        {
            da = new SqlDataAdapter("select * from arabalar ", con);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            temizle();
        }
        public Form1()
        {
            InitializeComponent();
        }

     

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into arabalar(Plaka,Marka,Model,ÜretimYılı,Km,Renk,YakıtTuru,KiraÜcreti,Durum,Resim)values ('" + textBox1.Text+ "','"+textBox2.Text+ "','"+textBox3.Text+"','"+int.Parse( textBox4.Text )+ "','"+int.Parse( textBox5.Text )+"','"+textBox6.Text+"','"+textBox7.Text+"','"+int.Parse( textBox8.Text )+ "','"+comboBox1.Text+ "','"+pictureBox1.ImageLocation+ "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt Eklendi");
            listele();
         dataGridView1.Visible=true;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of1= new OpenFileDialog();
            of1.Filter = "Resim dosyalari |*.jpg; *.png; *.tif|Tüm dosyalar |*.* ";
            of1.ShowDialog();
            pictureBox1.ImageLocation = of1.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand(" update arabalar set Plaka='" + textBox1.Text + "'Marka= '" + textBox2.Text + "',Model='" + textBox3.Text + "',ÜretimYili='" + int.Parse(textBox4.Text) + "',Km='" + int.Parse(textBox5.Text) + "',Renk='" + textBox6.Text + "',YakıtTuru='" + textBox7.Text + "', KiraÜcreti='" + int.Parse(textBox8.Text) + "',Durum='" + comboBox1.Text + "',Resim='" + pictureBox1.ImageLocation + "' where id = '" + int.Parse( dataGridView1.CurrentRow.Cells[0].Value.ToString() ) + "'    ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt güncellendi");
            listele();
        }

        
        private void button4_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand(" DELETE from  arabalar where id = '" + int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()) + "'    ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayıt silindi");
            listele();
       
       
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[10].Value.ToString();


            
        }
        private void button5_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select * from arabalar WHERE marka like '"+textBox9.Text+"'", con);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            temizle();
        }

      
    }

}
    

