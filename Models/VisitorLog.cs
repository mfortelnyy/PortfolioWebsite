using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioWebsite.Models
{
    public class VisitorLog
    {
        public int Id { get; set; }
        public string IPAddress { get; set; }
        public string UserAgent { get; set; }
        public string Referrer { get; set; }
        public string SessionId { get; set; }
        public DateTime VisitTime { get; set; }
    }
}