using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using Test.Commands.dbUtils;

namespace Test.Commands
{
    public class GetWorkDaysBetweenDates : BaseCommand
    {
        private readonly int Number = 13;
        private readonly string Name = "Count Weekdays";

        public override void Run()
        {
            
            Console.WriteLine(@"Enter two dates in format <yyyy-MM-dd yyyy-MM-dd> : ");
            DateTime dt;
            List<DateTime> dates = new List<DateTime>();
            Array.ForEach(Console.ReadLine().Split(" "), x =>
           {
               DateTime.TryParseExact(x,
                          "yyyy-MM-dd",
                          CultureInfo.InvariantCulture,
                          DateTimeStyles.None,
                          out dt);
               dates.Add(dt);

           });

            getWorkDaysBetweenDates(dates[0], dates[1]);
            Console.WriteLine();
        }

        private void getWorkDaysBetweenDates(DateTime firstDate, DateTime secondDate)
        {
            try
            {

                string connectionString;
                connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=db_posts;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                
                string cd = Environment.CurrentDirectory;
                cd = cd.Substring(0, cd.IndexOf("\\bin\\Debug")) + "\\database\\SQLQuery4.sql";
                string query = File.ReadAllText(cd);

                // Getting the result
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Use method to read sql files with "Go" 
                    DBUtils.ExecuteBatchNonQueryWithSplit(query, conn);

                    SqlDataAdapter da2 = new SqlDataAdapter();
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("SELECT dbo.weekdays(@FirstDate, @SecondDate) AS 'weekdays'", conn);
                    //SqlParameter code1 = new SqlParameter("@code", SqlDbType.Int);
                    SqlParameter first = cmd.Parameters.AddWithValue("@FirstDate", conn); 
                    SqlParameter second = cmd.Parameters.AddWithValue("@SecondDate", conn);
                    first.Value = firstDate;
                    second.Value = secondDate;
                    Console.WriteLine(cmd.ExecuteScalar());
                } 
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetBaseException());
            }
        }

        public override void ProgramInfo()
        {
            Console.WriteLine("A products count by day and department");
        }

        public override int GetProgramNumber()
        {
            return this.Number;
        }

        public override string GetCommandName()
        {
            return this.Name;
        }
    }
}