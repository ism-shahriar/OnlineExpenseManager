using Microsoft.EntityFrameworkCore;
using OnlineBanking.Models;
using OnlineBanking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBanking.Repository
{
    public class AccountRepository : IAccount
    {
        private DB_Context db;
        public AccountRepository(DB_Context _db)
        {
            db = _db;
        }
        //Getting all the account from the Database in the following line 
        public IEnumerable<Account> GetAccounts => db.Accounts.Include(global=>global.Client);
        public void Add(Account _Account)
        {
            db.Accounts.Add(_Account);
            db.SaveChanges();
        }

        public Account GetAccount(int? Id)
        {
            Account dbEntity = db.Accounts.Find(Id);
            return dbEntity;
        }

        public void Remove(int? Id)
        {
            Account dbEntity = db.Accounts.Find(Id);
            db.Accounts.Remove(dbEntity);
            db.SaveChanges();
        }

    }
}
