using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace OnlineBanking.Models
{

    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        [DisplayName("Transaction Type") ]
        public string TransactionType { get; set; }
        [DisplayName("Amount")]
        public decimal TransactionAmount { get; set; }
        [DisplayName("Balance")]
        public decimal EndBalance { get; set; }
        [DisplayName("Account")]
        public int AccountID { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date")]
        public DateTime TransactionDate { get; set; }
        public Account Accouont { get; set; }

    }
}

