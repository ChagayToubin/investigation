using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using investigationChagay.DB.Connection;
using MySql.Data.MySqlClient;

namespace investigationChagay.DB.DAl
{
    internal class gamesessionsDAL
    {
        MySqlConnection Connect = ConnectioN.InitConnection();
    }
}
