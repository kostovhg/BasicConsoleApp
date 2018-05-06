using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Test.Commands
{
    public class GetMonthOverMonthGrowRate : IRunnable
    {
        private readonly int Number = 12;

        public void Run()
        {
            getMonthGrowRate();
            Console.WriteLine();
        }

        private void getMonthGrowRate()
        {
            try
            {
                string connetionString;
                connetionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=db_posts;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection cnn = new SqlConnection(connetionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader;

                // NOTE: only for debugging 
                string cd = Environment.CurrentDirectory;
                cd = cd.Substring(0, cd.IndexOf("\\bin\\Debug")) + "\\database\\SQLQuery3.sql";

                cmd.CommandText = File.ReadAllText(cd);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cnn;
                cnn.Open();
                Console.WriteLine("Connection Open  !");

                reader = cmd.ExecuteReader();

                Console.WriteLine("{0,-12} {1,-10} {2,-10}", reader.GetName(0), reader.GetName(1), reader.GetName(2));
                Console.WriteLine(new String('-', 57));
                while (reader.Read())
                {
                    Console.WriteLine("{0,-12:yyyy-MM-dd} {1,-10} {2,-10}", reader.GetDateTime(0).Date, reader.GetInt32(1), reader.GetString(2));
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