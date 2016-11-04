using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.ODataV4.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public double TotalAmount { get; set; }
    }
}