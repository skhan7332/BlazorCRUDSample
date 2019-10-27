using BlazorCrud.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCrud.Server.DataAccess
{
    public class DataBaseContext : DbContext
    {
        public const string SharedSchema = "dbo";

        public DataBaseContext(string connectionString) : base(GetOptions(connectionString))
        {
            Database.EnsureCreated();
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}
