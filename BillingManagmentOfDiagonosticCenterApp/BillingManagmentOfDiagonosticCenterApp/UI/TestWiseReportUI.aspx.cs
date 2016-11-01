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
    public partial class TestWiseReportUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void showReportButton_Click(object sender, EventArgs e)
        {
            DateTime lowerDate = DateTime.Parse(lowerDateTextBox.Value.ToString());
            DateTime upperDate = DateTime.Parse(upperDateTextBox.Value.ToString());

            TestManager testManager=new TestManager();
            List<ViewTestWithTotalTest> viewTestWithTotalTestslList = testManager.GetTestWiseReportByDate(lowerDate,upperDate);
            testShowGridView.DataSource = viewTestWithTotalTestslList;
            testShowGridView.DataBind();

            double totalAmount = 0;
            foreach (ViewTestWithTotalTest viewTestWithTotalTest in viewTestWithTotalTestslList)
            {
                totalAmount += viewTestWithTotalTest.TotalAmount;
            }

            totalTextBox.Value = totalAmount.ToString();
        }
    }
}