using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDatabase.Models
{
    public class Transaction
    {
        public int transactionID { get; set; }
        public int userID { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public DateTime transactionDate { get; set; }
        public double totalAmount { get; set; }

    }
}
