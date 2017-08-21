using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace adminbengkel.jenis_servis
{
   public class DBConnection
    {
        
            public MySqlConnection Connection;

            string constring = "server=localhost; database=bengkel; uid=root; pwd=";

        public void ConnectionOpen()
            {
                Connection = new MySqlConnection(constring);
                Connection.Open();
            }
            public void ConnectionClose()
            {
                Connection = new MySqlConnection(constring);
                Connection.Close();
            }
       

    }
}
