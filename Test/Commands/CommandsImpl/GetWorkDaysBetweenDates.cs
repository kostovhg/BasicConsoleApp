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
        public override int Number { get { return 13; } }

        public override string Name { get { return "Count Weekdays"; } }

        public override string ProgramInfo
        {
            get
            {
                return "Use (create) User defined function to calculate the working days between two dates." + Environment.NewLine +
                    "Using SQLQuery4.sql file from Test.database";
            }
        }

        public override void Run()
        {
            writer.WriteLine("");
            writer.WriteLine(@"Enter two dates in format <yyyy-MM-dd yyyy-MM-dd> : ");
            DateTime dt;
            List<DateTime> dates = new List<DateTime>();
            reader.ReadInputParameters(" ").ForEach(x =>
           {
               DateTime.TryParseExact(x,
                          "yyyy-MM-dd",
                          CultureInfo.InvariantCulture,
                          DateTimeStyles.None,
                          out dt);
               dates.Add(dt);

           });

            getWorkDaysBetweenDates(dates[0], dates[1]);
            writer.WriteLine("");
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

                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand("SELECT dbo.weekdays(@FirstDate, @SecondDate) AS 'weekdays'", conn);
                    SqlParameter first = cmd.Parameters.AddWithValue("@FirstDate", conn);
                    SqlParameter second = cmd.Parameters.AddWithValue("@SecondDate", conn);
                    first.Value = firstDate;
                    second.Value = secondDate;
                    writer.WriteLine(cmd.ExecuteScalar().ToString());
                }

            }
            catch (Exception e)
            {
                writer.WriteLine(e.GetBaseException().ToString());
            }
        }
    }
}