using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Test.Commands
{
    public class GetProducts : BaseCommand
    {
        private readonly int Number = 10;
        private readonly string Name = "SQL Basics: Simple JOIN";
        public override void Run()
        {
            getProducts();
            Console.WriteLine();
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
            Console.WriteLine("Connection Open  !");

            reader = cmd.ExecuteReader();

            List<object> result = new List<object>();
            Console.WriteLine("{0,4} {1,-20} {2,-16} {3,-20} {4,-10}", "id", "name", "isbn", "company", "price");
            Console.WriteLine(new String('-', 70));
            while (reader.Read())
            {
                Console.WriteLine("{0,4} {1,-20} {2,-16} {3,-20} {4,-10}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDecimal(4));
            }
            cnn.Close();
            return new List<object>();
        }

        public override void ProgramInfo()
        {
            Console.WriteLine("Return all columns from the products table joined with company table, to fetch the company name.");
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