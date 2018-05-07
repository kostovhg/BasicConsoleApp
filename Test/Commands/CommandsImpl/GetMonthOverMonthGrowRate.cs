using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Test.Commands
{
    public class GetMonthOverMonthGrowRate : BaseCommand
    {
        public override int Number { get { return 12; } }

        public override string Name { get { return "Calculating Month-Over-Month Percentage Growth Rate"; } }

        public override string ProgramInfo
        {
            get
            {
                return "A products count by day and department. ";
            }
        }

        public override void Run()
        {
            getMonthGrowRate();
            writer.WriteLine("");
        }

        private void getMonthGrowRate()
        {
            try
            {
                string connetionString;

                string cd = Environment.CurrentDirectory;
                string sql_file = cd.Substring(0, cd.IndexOf("\\bin\\Debug")) + "\\database\\SQLQuery3.sql";
                
                string db_file = cd.Substring(0, cd.IndexOf("\\bin\\Debug")) + "\\database\\db_test.mdf";
                //db_file = "\"" + db_file + "\"";
                connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + db_file + ";Integrated Security=True;Connect Timeout=30";
                SqlConnection cnn = new SqlConnection(connetionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

               

                cmd.CommandText = File.ReadAllText(sql_file);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                cnn.Open();
                writer.WriteLine("Connection Open  !");

                reader = cmd.ExecuteReader();

                writer.WriteLine("\nResult: ");
                writer.WriteLine(String.Format("{0,-12} {1,-10} {2,-10}", reader.GetName(0), reader.GetName(1), reader.GetName(2)));
                writer.WriteLine(new String('-', 57));
                while (reader.Read())
                {
                   writer.WriteLine(String.Format("{0,-12:yyyy-MM-dd} {1,-10} {2,-10}", reader.GetDateTime(0).Date, reader.GetInt32(1), reader.GetString(2)));
                }
                cnn.Close();
                writer.WriteLine("Connection Closed  !");
            }
            catch (Exception e)
            {
                writer.WriteLine(e.GetBaseException().ToString());
            }
        }
    }
}