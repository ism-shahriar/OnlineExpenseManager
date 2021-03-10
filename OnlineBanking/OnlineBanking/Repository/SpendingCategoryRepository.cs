using OnlineBanking.Models;
using OnlineBanking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace OnlineBanking.Repository
{
    public class SpendingCategoryRepository : ISpendingCategory
    {
        private DB_Context db;
        public SpendingCategoryRepository(DB_Context _db)
        {
            db = _db;
        }
        //Getting all the client from the Database in the following line 
        public IEnumerable<SpendingCategory> GetSpendingCategories => db.SpendingCategories;
        public void Add(SpendingCategory _SpendingCategory)
        {
            db.SpendingCategories.Add(_SpendingCategory);
            db.SaveChanges();
        }

        public SpendingCategory GetSpendingCategory(int? Id)
        {
            SpendingCategory dbEntity = db.SpendingCategories.Find(Id);
            return dbEntity;
        }

        public void Remove(int? Id)
        {
            SpendingCategory dbEntity = db.SpendingCategories.Find(Id);
            db.SpendingCategories.Remove(dbEntity);
            int v = db.SaveChanges();
        }

    }
}
