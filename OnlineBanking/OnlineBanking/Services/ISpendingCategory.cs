using OnlineBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace OnlineBanking.Services
{
    public interface ISpendingCategory
    {
        IEnumerable<SpendingCategory> GetSpendingCategories { get; }


        SpendingCategory GetSpendingCategory(int? Id);
        void Add(SpendingCategory _SpendingCategory);
        void Remove(int? Id);

    }
}
