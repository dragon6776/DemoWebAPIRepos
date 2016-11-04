using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;
using System.Web.Http.OData.Routing;
using Demo.ODataV4.Models;
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
    public class ViewModel_OrdersController : ODataController
    {
        private static ODataValidationSettings _validationSettings = new ODataValidationSettings();

        // GET: odata/Orders
        public IHttpActionResult GetOrders(ODataQueryOptions<Order> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<IEnumerable<Order>>(orders);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // GET: odata/Orders(5)
        public IHttpActionResult GetOrder([FromODataUri] int key, ODataQueryOptions<Order> queryOptions)
        {
            // validate the query.
            try
            {
                queryOptions.Validate(_validationSettings);
            }
            catch (ODataException ex)
            {
                return BadRequest(ex.Message);
            }

            // return Ok<Order>(order);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PUT: odata/Orders(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Order> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Put(order);

            // TODO: Save the patched entity.

            // return Updated(order);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // POST: odata/Orders
        public IHttpActionResult Post(Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Add create logic here.

            // return Created(order);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // PATCH: odata/Orders(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Order> delta)
        {
            Validate(delta.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: Get the entity here.

            // delta.Patch(order);

            // TODO: Save the patched entity.

            // return Updated(order);
            return StatusCode(HttpStatusCode.NotImplemented);
        }

        // DELETE: odata/Orders(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            // TODO: Add delete logic here.

            // return StatusCode(HttpStatusCode.NoContent);
            return StatusCode(HttpStatusCode.NotImplemented);
        }
    }
}
