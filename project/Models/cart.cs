using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectWith中佑.Models
{
    public class cart
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public int productStore { get; set; }
        public int productPrice { get; set; }
        public string productImage { get; set; }
        public string memberShopID { get; set; }
        public string payState { get; set; }
        public int shopNumber { get; set; }
        public int Shop { get; set; }
        public int totalMoney { get; set; }
    }

}