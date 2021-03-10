using OnlineBanking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace OnlineBanking.Services
{
    public interface IClient
    {
        IEnumerable<Client> GetClients { get; }
        Client GetClient(int? Id);
        void Add(Client _Client);
        void Remove(int? Id);
    }
}
