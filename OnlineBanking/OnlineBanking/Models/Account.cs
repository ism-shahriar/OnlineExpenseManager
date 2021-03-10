using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace OnlineBanking.Models
{

    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [DisplayName("Account Number")]
        
        public int AccountNumber { get; set; }
        [DisplayName("Account Type")]
        public string AccountType { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Account Opening Date")]
        public DateTime OpenDate { get; set; }
        [DisplayName("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }


    }
}

