//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data;
//using System.Data.SqlClient;
//using System.Data.Common;

//namespace SaladCreation
//{
//    class NorthwindConnection
//    {
//        SqlConnection cn = new SqlConnection();
//        public static void ConnectToDB()
//        {
//            string cnStr = GetConnectionString();
//        // Get connection object
//        using (var cn = new SqlConnection())
//         {
//                Console.WriteLine("Connection object --> " + cn.GetType().Name);
//                cn.ConnectionString = cnStr;
//                cn.Open();

//         }
//        }

//        static private string GetConnectionString()
//        {
//            return @"Data Source=EPBYMINW4248\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;Pooling=True";
//        }

//        private static void DBCommand()
//        {
//            // Create command object
//            DbCommand cmd = new SqlCommand();
//            Console.WriteLine("Command object --> " + cmd.GetType().Name);
//            cmd.Connection = cn;
//            cmd.CommandText = "Select top 5 * From Customers";
//        }

//    }
//}
