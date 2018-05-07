using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Test.Commands
{
    public class GetProducts : BaseCommand
    {
        public override int Number { get { return 10; } }

        public override string Name { get { return "SQL Basics: Simple JOIN?"; } }

        public override string ProgramInfo
        {
            get
            {
                return "Return all columns from the products table joined with company table, to fetch the company name.";
            }
        }

        public override void Run()
        {
            getProducts();
            writer.WriteLine("");
        }

        private List<object> getProducts()
        {
            string connetionString;
            connetionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=db_test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection cnn = new SqlConnection(connetionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "SELECT p.id, p.name, p.isbn, c.name, p.price FROM products AS p JOIN company AS c ON p.company_id = c.id";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            cnn.Open();
            writer.WriteLine("\nConnection Open  !");
            writer.WriteLine("\nExecuting query:");
            writer.WriteLine(cmd.CommandText);

            reader = cmd.ExecuteReader();

            List<object> result = new List<object>();
            writer.WriteLine("\nResult: ");
            writer.WriteLine("{0,4} {1,-20} {2,-16} {3,-20} {4,-10}", 
                new object[] {
                    reader.GetName(0),
                    reader.GetName(1),
                    reader.GetName(2),
                    reader.GetName(3),
                    reader.GetName(4)
                });
            writer.WriteLine(new String('-', 70));
            while (reader.Read())
            {
                writer.WriteLine(
                    "{0,4} {1,-20} {2,-16} {3,-20} {4,-10}",
                    new object[]
                    {
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetDecimal(4)
                    });
            }
            cnn.Close();
            return new List<object>();
        }
    }
}