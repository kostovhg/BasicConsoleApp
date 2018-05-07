using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Test.Commands
{
    public class GetSalesTotaling : BaseCommand
    {
        public override int Number { get { return 11; } }

        public override string Name { get { return "SQL Bug Fixing: Fix the QUERY - Totaling"; } }

        public override string ProgramInfo
        {
            get
            {
                return "A products count by day and department";
            }
        }
      
        public override void Run()
        {
            getTotalSales();
            writer.WriteLine("");
        }

        private void getTotalSales()
        {
            try
            {
                string connetionString;
                connetionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=db_sales;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection cnn = new SqlConnection(connetionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                string cd = Environment.CurrentDirectory;
                cd = cd.Substring(0, cd.IndexOf("\\bin\\Debug")) + "\\database\\SQLQuery2.sql";

                cmd.CommandText = File.ReadAllText(cd);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                cnn.Open();
                writer.WriteLine("Connection Open  !");

                reader = cmd.ExecuteReader();

                writer.WriteLine("\nResult: ");
                writer.WriteLine("{0,17} {1,-20} {2,-20}", new object[] { reader.GetName(0), reader.GetName(1), reader.GetName(2) });
                writer.WriteLine(new String('-', 57));
                while (reader.Read())
                {
                    writer.WriteLine("{0} {1} {2}", new object[] { reader.GetDateTime(0), reader.GetString(1), reader.GetInt32(2) });
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