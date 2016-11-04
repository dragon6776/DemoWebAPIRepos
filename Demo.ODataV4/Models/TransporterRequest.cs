using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.ODataV4.Models
{
    public enum TransporterRequestStatus
    {
        Pending = 0,
        Completed = 1,
        Cancelled = -1, // Hủy do hết phiên hoặc ko gửi request để update status
    }

    public class TransporterRequest
    {
        public TransporterRequest()
        {
            DateCreated = DateTime.Now;
        }

        public int Id { get; set; }
        public Guid TokenKey { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Note { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Completed { get; set; }
        public TransporterRequestStatus Status { get; set; }
    }
}