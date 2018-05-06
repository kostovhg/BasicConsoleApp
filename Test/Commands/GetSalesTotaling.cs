using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Test.Commands
{
    public class GetSalesTotaling : IRunnable
    {
        private readonly int Number = 11;

        public void Run()
        {
            getTotalSales();
            Console.WriteLine();
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

                // NOTE: only for debugging 
                string cd = Environment.CurrentDirectory;
                cd = cd.Substring(0, cd.IndexOf("\\bin\\Debug")) + "\\database\\SQLQuery2.sql";

                cmd.CommandText = File.ReadAllText(cd);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                cnn.Open();
                Console.WriteLine("Connection Open  !");

                reader = cmd.ExecuteReader();

                Console.WriteLine("{0,17} {1,-20} {2,-20}", reader.GetName(0), reader.GetName(1), reader.GetName(2));
                Console.WriteLine(new String('-', 57));
                while (reader.Read())
                {
                    Console.WriteLine("{0} {1} {2}", reader.GetDateTime(0), reader.GetString(1), reader.GetInt32(2));
                }
                cnn.Close();
                Console.WriteLine("Connection Closed  !");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
            }
        }

        public void ProgramInfo()
        {
            Console.WriteLine("A products count by day and department");
        }

        public int GetProgramNumber()
        {
            return this.Number;
        }
    }
}