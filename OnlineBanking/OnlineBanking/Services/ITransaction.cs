using OnlineBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBanking.Services
{
    public interface ITransaction
    {
        IEnumerable<Transaction> GetTransactions { get; }


        Transaction GetTransaction(int? Id);
        void Add(Transaction _Transaction);
        void Remove(int? Id);

    }
}
