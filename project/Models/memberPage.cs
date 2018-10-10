using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectWith中佑.Models
{
    public class memberPage
    {
     
        public IEnumerable<Store> Store { get; set; }
        public IEnumerable<GameRecord> GameRecord { get; set; }
        public IEnumerable<memberShopAndProduct1> memberShopAndProduct { get; set; }


    }
}