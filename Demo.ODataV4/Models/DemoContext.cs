using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Demo.ODataV4.Models
{
    public class DemoContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<TransporterRequest> TransporterRequests { get; set; }
    }
}