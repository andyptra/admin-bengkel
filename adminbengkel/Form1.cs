using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace adminbengkel
{
    public partial class Form1 : Form
    {
        MySqlConnection konek = koneksi.koneksi.getkoneksi();
        public Form1()
        {
            InitializeComponent();
        }
       public DataTable loginku(string Username, string Password)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("select username,password,level from admin where username=@username and password=@password", konek);
                cmd.Parameters.AddWithValue("@username",Username );
                cmd.Parameters.AddWithValue("@password",Password);
                konek.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);
                konek.Close();
                return dt;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void pictureBox2_Click(object sender, EventArgs e)
        {

            
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(username.Text=="" || password.Text == "")
            {
                MessageBox.Show("masukkan username dan password anda");
                return;
            }
            try
            {
                DataTable result = loginku(username.Text, password.Text);
                if (result.Rows.Count == 1)
                {
                    this.Hide();
                    string level = result.Rows[0]["level"].ToString();

                    switch (level)
                    {
                        case "admin":
                            koneksi.menuadmin menu = new koneksi.menuadmin();
                            menu.ShowDialog();
                            this.Close();
                            break;
                        case "karyawan":
                            menukaryawan menus = new menukaryawan();
                            menus.ShowDialog();
                            this.Close();
                            break;

                    }
                }
                else
                {
                    MessageBox.Show("username dan password salah");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
