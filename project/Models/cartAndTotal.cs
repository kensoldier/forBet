using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectWith中佑.Models
{
    public class cartAndTotal
    {
        public IEnumerable<cart> cart { get; set; }
        public int Total { get; set; }
    }
}