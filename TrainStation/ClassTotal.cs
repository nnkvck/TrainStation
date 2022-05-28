using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainStation
{
    class ClassTotal
    {
        public static string connectionString = @"Data Source=DESKTOP-0V2DD44\SQLEXPRESS;Initial Catalog=TrainStation; Integrated Security=True";  //Строка подключения
        public static SqlConnection connection = new SqlConnection(connectionString);
        public static int id;
        public static int idDepartament;
        //public enum Mode { Просмотр, Редактирование, Добавление };
    }
}
