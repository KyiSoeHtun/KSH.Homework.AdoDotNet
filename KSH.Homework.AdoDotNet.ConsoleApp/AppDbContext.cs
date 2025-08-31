using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSH.Homework.AdoDotNet.ConsoleApp
{
    public class AppDbContext : DbContext

    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder()
            {
                DataSource = ".",// local SQL Server
                InitialCatalog = "KSH.Homework.AdoDotNet",// database name
                UserID = "sa",// user name
                Password = "sasa@123",// password
                TrustServerCertificate = true// for local SQL Server
            };
            optionsBuilder.UseSqlServer(sb.ConnectionString);
        }
        public DbSet<StudentDto> Students { get; set; }
    }
}
