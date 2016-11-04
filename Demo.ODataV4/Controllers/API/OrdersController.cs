using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.OData;
using System.Web.OData.Routing;
using Demo.ODataV4.Models;
using System.Web.OData.Query;
using Microsoft.Data.OData;

namespace Demo.ODataV4.Controllers.API
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using Demo.ODataV4.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Order>("Orders");
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class OrdersController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();
        private DemoContext db = new DemoContext();

        // GET: odata/Orders
        //[EnableQuery]
        //public IQueryable<Order> GetOrders()
        //{
        //    return db.Orders;
        //    // {"@odata.context":"http://localhost:2218/odata/$metadata#Orders","value":[{"Id...},...]}
        //}

        [EnableQuery]
        public IHttpActionResult GetOrders(ODataQueryOptions<Order> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);

                var orders = db.Orders;

                var result = Ok<IEnumerable<Order>>(orders);

                return result;

                // {"@odata.context":"http://localhost:2218/odata/$metadata#Orders","value":[{"Id":1,"
                //return StatusCode(HttpStatusCode.NotImplemented);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: odata/Orders(5)
        [EnableQuery]
        public SingleResult<Order> GetOrder([FromODataUri] int key)
        {
            return SingleResult.Create(db.Orders.Where(order => order.Id == key));
        }

        // PUT: odata/Orders(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Order> patch)
        {
            //Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Order order = db.Orders.Find(key);
            if (order == null)
            {
                return NotFound();
            }

            patch.Put(order);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(order);
        }

        // POST: odata/Orders
        public IHttpActionResult Post(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Orders.Add(order);
            db.SaveChanges();

            return Created(order);
        }

        // PATCH: odata/Orders(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Order> patch)
        {
            //Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Order order = db.Orders.Find(key);
            if (order == null)
            {
                return NotFound();
            }

            patch.Patch(order);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(order);
        }

        // DELETE: odata/Orders(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Order order = db.Orders.Find(key);
            if (order == null)
            {
                return NotFound();
            }

            db.Orders.Remove(order);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderExists(int key)
        {
            return db.Orders.Count(e => e.Id == key) > 0;
        }

        #region TRANSPORTER FUNCTIONS

        [HttpPost]
        public IHttpActionResult MostExpensive()
        {
            double product = db.Orders.Count();
            return Ok(product);
        }

        //[HttpPost]
        //public IHttpActionResult Login(TransporterLoginModel user)
        //{
        //    if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
        //    {
        //        ModelState.AddModelError("UserName", "Co the sai");
        //        ModelState.AddModelError("Password", "Co the sai");
        //        ModelState.AddModelError("", "UserName or Password incorrect");

        //        //return BadRequest(ModelState);

        //        //return StatusCode(HttpStatusCode.Unauthorized);

        //        return ResponseMessage(new HttpResponseMessage
        //        {
        //            StatusCode = HttpStatusCode.Unauthorized,
        //            Content = new StringContent("Content: Tên đăng nhập or mật khẩu ko đúng"),
        //            ReasonPhrase = "ReasonPhrase: Tên đn or mk ko đúng",
        //        });
        //    }

        //    user.TokenKey = Guid.NewGuid().ToString();

        //    return Ok(user);
        //}

        #endregion
    }
}
