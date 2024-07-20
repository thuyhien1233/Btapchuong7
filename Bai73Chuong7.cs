using System;
using System.Data.SqlClient;
namespace Database_Operation
{
    class SelectStatement
    {
        static void Main()
        {
            Read();
            Console.ReadKey();
        }

        static void Read()
        {
            string constr;
            SqlConnection conn;
            constr = @"Data Source=EMBEHAYKHOC\SQLEXPRESS;Initial Catalog=Demodb;User ID=sa;Password=Mailinh02.";
            conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand cmd;
            SqlDataReader dreader;
            string sql, output = "";
            sql = "Select articleID, articleName from demo";
            cmd = new SqlCommand(sql, conn);
            dreader = cmd.ExecuteReader();
            // Đọc từng dòng của bảng
            while (dreader.Read())
            {
                output = output + dreader.GetValue(0) + " - " +
                                    dreader.GetValue(1) + "\n";
            }
            Console.Write(output);
            // to close all the objects
            dreader.Close();
            cmd.Dispose();
            conn.Close();
        }
    }
}