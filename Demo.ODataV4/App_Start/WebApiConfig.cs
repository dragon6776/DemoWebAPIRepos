using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Demo.ODataV4.Models;

namespace Demo.ODataV4
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            /// INIT
            //config.MapHttpAttributeRoutes();
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            /// ODATA V3
            //config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
            /// SU DUNG TRUC TIEP???
            //config.MapODataServiceRoute("ODataRoute", null, builder.GetEdmModel());

            /// ODATA V4
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Order>("Orders");

            // add transporter functions
            //builder.Namespace = "TransporterService";

            //builder.EntityType<Order>().Collection
            //   .Function("Login")
            //   .Returns<Order>();       // hd: Returns<double>();

            //builder.EntityType<Order>().Collection
            //    .Function("UpdateOrderStatus")
            //    .Returns<Order>();      // hd: Returns<double>();


            // New code:
            builder.Namespace = "ProductService";
            builder.EntityType<Order>().Collection
                .Function("MostExpensive")
                .Returns<double>();

            config.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
            config.MapODataServiceRoute("odata", "odata", builder.GetEdmModel()); /// ODATA-V4 MPCT ~ V3
        }
    }
}
