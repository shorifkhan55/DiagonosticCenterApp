using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingManagmentOfDiagonosticCenterApp.Model
{
    public class Bill
    {
        public string BillNo { get; set; }
        public DateTime Date { get; set; }
        public byte Status { get; set; }

        public Bill(string billNo, DateTime date, byte status)
        {
            this.BillNo = billNo;
            this.Date = date;
            this.Status = status;
        }
    }
}