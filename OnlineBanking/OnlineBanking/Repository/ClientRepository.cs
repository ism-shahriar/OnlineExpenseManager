using OnlineBanking.Models;
using OnlineBanking.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBanking.Repository
{
    public class ClientRepository : IClient
    {
        private DB_Context db;
        public ClientRepository(DB_Context _db)
        {
            db = _db;
        }
        //Getting all the client from the Database in the following line 
        public IEnumerable<Client> GetClients => db.Clients;
        public void Add(Client _Client)
        {
            db.Clients.Add(_Client);
            db.SaveChanges();
        }

        public Client GetClient(int? Id)
        {
            Client dbEntity = db.Clients.Find(Id);
            return dbEntity;
        }

        public void Remove(int? Id)
        {
            Client dbEntity = db.Clients.Find(Id);
            db.Clients.Remove(dbEntity);
            db.SaveChanges();
        }
        
    }
}
