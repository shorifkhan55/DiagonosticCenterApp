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
    public partial class TypeWiseReportUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void reportShowButton_Click(object sender, EventArgs e)
        {
            DateTime lowerDate = DateTime.Parse(lowerDateTextBox.Value.ToString());
            DateTime upperDate = DateTime.Parse(upperDateTextBox.Value.ToString());

            TestTypeManager testTypeManager = new TestTypeManager();
            List<ViewTypeWithTotalTest> viewTypeWithTotalTestslList = testTypeManager.GetTypeReportByDate(lowerDate,upperDate);
            typeShowGridView.DataSource = viewTypeWithTotalTestslList;
            typeShowGridView.DataBind();

            double totalAmount = 0;
            foreach (ViewTypeWithTotalTest viewTypeWithTotalTest in viewTypeWithTotalTestslList)
            {
                totalAmount += viewTypeWithTotalTest.TotalAmount;
            }

            totalAmountTextBox.Value = totalAmount.ToString();
        }
    }
}