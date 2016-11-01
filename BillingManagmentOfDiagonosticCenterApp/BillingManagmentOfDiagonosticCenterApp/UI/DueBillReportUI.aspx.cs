using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingManagmentOfDiagonosticCenterApp.BLL;
using BillingManagmentOfDiagonosticCenterApp.Model.ViewModels;

namespace BillingManagmentOfDiagonosticCenterApp.UI
{
    public partial class DueBillReportUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void reportShowButton_Click(object sender, EventArgs e)
        {

            DateTime lowerDate = DateTime.Parse(lowerDateTextBox.Value.ToString());
            DateTime upperDate = DateTime.Parse(upperDateTextBox.Value.ToString());


            BillManager billManager = new BillManager();

            List<ViewUnpaidBill> viewUnpaidBillList = billManager.GetUnpaidBillsByDate(lowerDate, upperDate);
            billShowGridView.DataSource = viewUnpaidBillList;
            billShowGridView.DataBind();
            double totalAmount = 0;
            foreach (ViewUnpaidBill viewUnpaidBill in viewUnpaidBillList)
            {
                totalAmount += viewUnpaidBill.BillAmount;
            }

            totalAmountTextBox.Value = totalAmount.ToString();
        }
    }
}