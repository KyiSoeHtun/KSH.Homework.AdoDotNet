using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSH.Homework.AdoDotNet.ConsoleApp
{
    public class DapperService
    {
        private readonly SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder()
        {
            DataSource = ".",// local SQL Server
            InitialCatalog = "KSH.Homework.AdoDotNet",// database name
            UserID = "sa",// user name
            Password = "sasa@123",// password
            TrustServerCertificate = true// for local SQL Server
        };
        public void Read()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();
            List<Student> lst = db.Query<Student> ("select * from [ClientRegistration]").ToList();
            for (int i = 0; i < lst.Count; i++)
            {
                Student item = lst[i];
                Console.WriteLine($"{i + 1} {item.ClientID} - {item.ClientName}");
            }
        }
        public void Create()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();
            int result = db.Execute(@"INSERT INTO [dbo].[ClientRegistration]
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
           ,'U Than'
           ,'Male'
           ,'2000-01-01'
           ,'001'
           ,'09123456453'
           ,'Yangon'
           ,0");
        }
        public void Update()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();
            int result = db.Execute(@"UPDATE [dbo].[ClientRegistration]
   SET [ClientName] = 'Maung Maung'
 WHERE ClientID = 2");
        }
        public void Delete()
        {
            using IDbConnection db = new SqlConnection(sb.ConnectionString);
            db.Open();
            int result = db.Execute(@"UPDATE [dbo].[ClientRegistration]
   SET [DeleteFlag] = 1
 WHERE ClientID = 2");
            Console.WriteLine(result);
        }
    };
};