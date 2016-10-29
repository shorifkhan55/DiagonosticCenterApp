using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillingApp.BLL;
using DiagnosticCenterBillingApp.Model;

namespace DiagnosticCenterBillingApp.UI
{
    public partial class TestRequestEntryUI : System.Web.UI.Page
    {
        TestRequestManager _testRequestManager = new TestRequestManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadeAllTest();
        }

        protected void addGridviewButton_Click(object sender, EventArgs e)
        {

        }

        public void LoadeAllTest()
        {
            List<Tests> tests = _testRequestManager.GetAllTestsWithFee();
            testSelectDropDownList.DataSource = tests;
            testSelectDropDownList.DataTextField = "TestName";
            testSelectDropDownList.DataValueField = "TestId";
            testSelectDropDownList.DataBind();
        }

        protected void testSelectDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int testId = Convert.ToInt32(testSelectDropDownList.SelectedValue);

            decimal fee = _testRequestManager.GetTestFee(testId);
            testFeeTextBox.Text = fee.ToString();
        }
    }
}