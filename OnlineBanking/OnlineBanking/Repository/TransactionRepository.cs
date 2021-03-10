using Microsoft.EntityFrameworkCore;
using OnlineBanking.Models;
using OnlineBanking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBanking.Repository
{
    public class TransactionRepository : ITransaction
    {
        private DB_Context db;
        public TransactionRepository(DB_Context _db)
        {
            db = _db;
        }
        //Getting all the client from the Database in the following line 
        public IEnumerable<Transaction> GetTransactions => db.Transactions.Include(global=>global.Accouont);
        public void Add(Transaction _Transaction)
        {
            db.Transactions.Add(_Transaction);
            db.SaveChanges();
        }

        public Transaction GetTransaction(int? Id)
        {
            Transaction dbEntity = db.Transactions.Find(Id);
            return dbEntity;
        }

        public void Remove(int? Id)
        {
            Transaction dbEntity = db.Transactions.Find(Id);
            db.Transactions.Remove(dbEntity);
            db.SaveChanges();
        }

    }
}
