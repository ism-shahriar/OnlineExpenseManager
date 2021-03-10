using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineBanking.Models;

namespace OnlineBanking.Models
{
    public class OnlineBankingContext : DbContext
    {
        public OnlineBankingContext (DbContextOptions<OnlineBankingContext> options)
            : base(options)
        {
        }

        public DbSet<OnlineBanking.Models.Account> Account { get; set; }

        public DbSet<OnlineBanking.Models.Client> Client { get; set; }

        public DbSet<OnlineBanking.Models.SpendingCategory> SpendingCategory { get; set; }

        public DbSet<OnlineBanking.Models.SpendingDetail> SpendingDetail { get; set; }

        public DbSet<OnlineBanking.Models.Transaction> Transaction { get; set; }
    }
}
