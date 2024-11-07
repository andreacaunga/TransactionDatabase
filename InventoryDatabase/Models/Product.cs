using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDatabase.Models
{
    public class Product
    {
        public int productID;
        public string productName = "";
        public int quantity;
        public string category = "";
        public double itemPrice;
    }
}
