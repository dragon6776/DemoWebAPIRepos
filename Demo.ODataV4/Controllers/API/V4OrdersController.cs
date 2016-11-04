using Demo.ODataV4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.OData;

namespace Demo.ODataV4.Controllers.API
{
    public class V4OrdersController : ODataController
    {
        DemoContext db = new DemoContext();

        [EnableQuery]
        public IQueryable<Order> Get()
        {
            return db.Orders;
        }

        [EnableQuery]
        public SingleResult<Order> Get([FromODataUri] int key)
        {
            IQueryable<Order> result = db.Orders.Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}