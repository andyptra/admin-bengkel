using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace adminbengkel.koneksi
{
    class koneksi
    {
        public static MySqlConnection getkoneksi()
        {
            MySqlConnection konek = null;
            try
            {
                string konekstring = "server=localhost;database=bengkel;uid=root;password=";
                konek = new MySqlConnection(konekstring);
            }
            catch(MySqlException exs)
            {
                throw new Exception(exs.Message.ToString());
            }
            return konek;
        }
    }
}
