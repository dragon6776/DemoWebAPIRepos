using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.ODataV4.Models
{
    public class TransporterLoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Return after login success
        /// </summary>
        public string TokenKey { get; set; }
    }
}