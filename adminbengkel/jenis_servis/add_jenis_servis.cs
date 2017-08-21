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


namespace adminbengkel.jenis_servis
{
    public partial class add_jenis_servis : MetroFramework.Forms.MetroForm
    {
        MySqlConnection konek = koneksi.koneksi.getkoneksi();
        private Form frm;
        public void ToggleForm()
        {
            if (frm == null)
            {
                frm = new Form();
                frm.Show();
            }
            else
            {
                frm.Close();
                frm = null;
            }
        }


        public add_jenis_servis()
        {
            InitializeComponent();
        }
        private bool ValidationSave()
        {
            if (string.IsNullOrEmpty(nama.Text))
            {
                MessageBox.Show("nama servis di isi Lohhhh !!!");
                nama.Focus();
            }
            else if (string.IsNullOrEmpty(harga.Text))
            {
                MessageBox.Show("harap cantumkan harga !!!");
                harga.Focus();
            }
            
            else
            {
                return true;
            }

            return false;

        }


        private void add_jenis_servis_Load(object sender, EventArgs e)
        {

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidationSave())
                {
                    string Query = "insert into bengkel.jenis_servis(nama_servis,harga) values('" +this.nama.Text + "','" + this.harga.Text + "');";
                    konek.Open();
                    MySqlCommand cmd = new MySqlCommand(Query, konek);
                    MySqlDataReader read;
                    read = cmd.ExecuteReader();
                    MessageBox.Show("Save Data");
                    while (read.Read())
                    {

                    }
                    konek.Close();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errornya adalah : " + ex.Message.ToString());
            }
        }
    }
}
