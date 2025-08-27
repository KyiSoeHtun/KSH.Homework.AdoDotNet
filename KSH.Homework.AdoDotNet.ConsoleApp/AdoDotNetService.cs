using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSH.Homework.AdoDotNet.ConsoleApp
{
    public class AdoDotNetService
    {
        SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder()
        {
            DataSource = ".",// local SQL Server
            InitialCatalog = "KSH.Homework.AdoDotNet",// database name
            UserID = "sa",// user name
            Password = "sasa@123",// password
            TrustServerCertificate = true// for local SQL Server
        };
        public void Read()
        {
            SqlConnection conn = new SqlConnection(sb.ConnectionString);
            conn.Open();
        string query = @"SELECT [ClientID]
            ,[ClientName]
            ,[FatherName]
            ,[Gender]
            ,[DateOfBirth]
            ,[ClientType]
            ,[PhoneNo]
            ,[Address]
            ,[DeleteFlag]
            FROM [dbo].[ClientRegistration]";// Select query
            SqlCommand cmd = new SqlCommand(query, conn);// Select query
            int result = cmd.ExecuteNonQuery();// Execute the query

            conn.Close();
        }
        public void Create()
        {
            SqlConnection conn = new SqlConnection(sb.ConnectionString);
            conn.Open();
            string query = @"INSERT INTO [dbo].[ClientRegistration]
           ([ClientName]
           ,[FatherName]
           ,[Gender]
           ,[DateOfBirth]
           ,[ClientType]
           ,[PhoneNo]
           ,[Address]
           ,[DeleteFlag])
     VALUES
           ('Aung Aung'
           ,'U Hein'
           ,'Male'
           ,'2020-01-01'
           ,'001'
           ,'01234231'
           ,'Yangon'
           ,0
		   )";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
                Console.WriteLine(i);

            conn.Close();

        }
        public void Update()
        {
            SqlConnection conn = new SqlConnection(sb.ConnectionString);
            conn.Open();
            string query = @"UPDATE [dbo].[ClientRegistration]
   SET [ClientName] = 'Nge Nge'
 WHERE ClientID = 1";
            SqlCommand cmd = new SqlCommand(query, conn);
            int result = cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void Delete()
        {
        SqlConnection conn = new SqlConnection(sb.ConnectionString);
        conn.Open();
            string query = @"UPDATE [dbo].[ClientRegistration]
   SET [DeleteFlag] = 1
 WHERE ClientID = 1";

        SqlCommand cmd = new SqlCommand(query, conn);
        int result = cmd.ExecuteNonQuery();
        conn.Close();
        }
        public void ExampleMetihod() { }
    }
}
