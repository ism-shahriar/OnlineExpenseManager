using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace OnlineBanking.Models
{

    public class SpendingDetail
    {
        [Key]
        public int SpendingID { get; set; }
        [DisplayName("Client")]
        public int ClientID { get; set; }
        [DisplayName("Category")]
        public int CategoryID { get; set; }
        [DisplayName("Amount Spent")]
        public decimal AmountSpent { get; set; }
        public Client Client { get; set; }
        public SpendingCategory SpendingCategory { get; set; }

    }
}

