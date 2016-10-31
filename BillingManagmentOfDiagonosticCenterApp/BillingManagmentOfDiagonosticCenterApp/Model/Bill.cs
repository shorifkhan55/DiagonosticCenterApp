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
        public double Amount { get; set; }
        public string Status { get; set; }

        public Bill(string billNo, DateTime date,double amount, string status)
        {
            this.BillNo = billNo;
            this.Date = date;
            this.Amount = amount;
            this.Status = status;
        }

        public Bill()
        { }
    }
}