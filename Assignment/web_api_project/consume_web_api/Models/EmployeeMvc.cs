using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace consume_web_api.Models
{
    public class EmployeeMvc
    {
        public decimal Request_Id { get; set; }
        public Nullable<System.DateTime> Request_Date { get; set; }
        public string From_Location { get; set; }
        public string To_Location { get; set; }
        public Nullable<decimal> User_type_Id { get; set; }
        public string Current_Status { get; set; }
    }
}