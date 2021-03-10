using OnlineBanking.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBanking.Repository
{
    public class DB_Context : DbContext
    {
        public DB_Context(DbContextOptions<DB_Context> options) : base(options)
        {
        }
        //We should keep the name that we use in front of DbSets exactly the same as of our database tables name.
        public DbSet<Client> Clients { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<SpendingDetail> SpendingDetails { get; set; }
        public DbSet<SpendingCategory> SpendingCategories { get; set; }
    }
}
