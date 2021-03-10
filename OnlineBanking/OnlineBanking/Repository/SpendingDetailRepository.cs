using Microsoft.EntityFrameworkCore;
using OnlineBanking.Models;
using OnlineBanking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace OnlineBanking.Repository
{
    public class SpendingDetailRepository : ISpendingDetail
    {
        private DB_Context db;
        public SpendingDetailRepository(DB_Context _db)
        {
            db = _db;
        }
        //Getting all the client from the Database in the following line 
        public IEnumerable<SpendingDetail> GetSpendingDetails => 
            db.SpendingDetails.Include(c=>c.Client).Include(s=>s.SpendingCategory);
        public void Add(SpendingDetail _SpendingDetail)
        {
            db.SpendingDetails.Add(_SpendingDetail);
            db.SaveChanges();
        }

        public SpendingDetail GetSpendingDetail(int? Id)
        {
            SpendingDetail dbEntity = db.SpendingDetails.Find(Id);
            return dbEntity;
        }

        public void Remove(int? Id)
        {
            SpendingDetail dbEntity = db.SpendingDetails.Find(Id);
            db.SpendingDetails.Remove(dbEntity);
            db.SaveChanges();
        }

    }
}
