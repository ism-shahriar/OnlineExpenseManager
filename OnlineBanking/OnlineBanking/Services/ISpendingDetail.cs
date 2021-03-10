using OnlineBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace OnlineBanking.Services
{
    public interface ISpendingDetail
    {
        IEnumerable<SpendingDetail> GetSpendingDetails { get; }


        SpendingDetail GetSpendingDetail(int? Id);
        void Add(SpendingDetail _SpendingDetail);
        void Remove(int? Id);

    }
}
