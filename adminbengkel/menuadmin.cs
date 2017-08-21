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
namespace adminbengkel.koneksi
{
    public partial class menuadmin : MetroFramework.Forms.MetroForm
    {
        private DataGridViewButtonColumn btnEdit, btnDelete;
        MySqlConnection konek = koneksi.getkoneksi();
        public void lihatdata()
        {
            MySqlCommand cmd;
            cmd = konek.CreateCommand();
            cmd.CommandText = "select * from jenis_servis";
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            vjenis_servis.DataSource = ds.Tables[0];
            vjenis_servis.AutoGenerateColumns = false;
            vjenis_servis.AllowUserToAddRows = false;
            
            
        }

   
        public menuadmin()
        {
            InitializeComponent();
        }

        private void menuadmin_Load(object sender, EventArgs e)
        {
            lihatdata();


            btnEdit = new DataGridViewButtonColumn();
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.Width = 70;
            btnEdit.Text = "Edit";
            vjenis_servis.Columns.Add(btnEdit);
            btnDelete = new DataGridViewButtonColumn();

            btnDelete.UseColumnTextForButtonValue = true;
            btnDelete.Width = 70;
            btnDelete.Text = "Hapus";
            vjenis_servis.Columns.Add(btnDelete);
        




    }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroGrid1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            using (jenis_servis.add_jenis_servis frm = new jenis_servis.add_jenis_servis())
            {
                frm.ShowDialog();
            }
               
        }

        private void metroGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id_jenis_servis = vjenis_servis.SelectedRows[0].Cells["id_jenis_servis"].Value.ToString();
            if (vjenis_servis.Columns[e.ColumnIndex] == btnEdit)
            {
               
            }
        }
    }
}
