using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingManagmentOfDiagonosticCenterApp.Model
{
    public class Order
    {
        public int PatientId { get; set; }
        public int TestId { get; set; }
        public string BillNo { get; set; }

        public Order(int patientId,int testId,string billNo)
        {
            this.PatientId = patientId;
            this.TestId = testId;
            this.BillNo = billNo;
        }
    }
}