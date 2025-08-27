// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//Console.WriteLine();

using KSH.Homework.AdoDotNet.ConsoleApp;
using Microsoft.Data.SqlClient;

//SqlConnectionStringBuilder ssb = new SqlConnectionStringBuilder();
//ssb.DataSource = ".";// local SQL Server
//ssb.InitialCatalog = "KSH.Homework.AdoDotNet";// database name
//ssb.UserID = "sa";// user name
//ssb.Password = "sasa@123";// password
//ssb.TrustServerCertificate = true;// for local SQL Server

AdoDotNetService adoDotNetService = new AdoDotNetService();

adoDotNetService.Read();
adoDotNetService.Create();
adoDotNetService.Update();
adoDotNetService.Delete();
Console.WriteLine();



