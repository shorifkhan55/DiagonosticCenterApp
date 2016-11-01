using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingManagmentOfDiagonosticCenterApp.DAL;
using BillingManagmentOfDiagonosticCenterApp.Model;
using BillingManagmentOfDiagonosticCenterApp.Model.ViewModels;

namespace BillingManagmentOfDiagonosticCenterApp.BLL
{
    public class BillManager
    {
        BillGateway _billGateway=new BillGateway();

        public int Save(Bill bill)
        {
            return _billGateway.Save(bill);
        }

        public Bill GetBillByBillNo(string billNo)
        {
            return _billGateway.GetBillByBillNo(billNo);
        }

        public Bill GetBillByMobileNo(string mobileNo)
        {
            return _billGateway.GetBillByMobileNo(mobileNo);
        }

        public int UpdateBillStatus(string billNo)
        {
            return _billGateway.UpdateBillStatus(billNo);

        }

        public bool IsBillPaid(string billNo)
        {
            return _billGateway.IsBillPaid(billNo);
        }

        public List<ViewUnpaidBill> GetUnpaidBillsByDate(DateTime lowerDate, DateTime upperDate)
        {
            return _billGateway.GetUnpaidBillsByDate(lowerDate, upperDate);
        }
    }
}