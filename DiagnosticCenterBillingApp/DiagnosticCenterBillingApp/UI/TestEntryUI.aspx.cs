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
    public partial class TestEntryUI : System.Web.UI.Page
    {
        TestsManager _testsManager=new TestsManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            dangerDiv.Visible = false;
            successfullDiv.Visible = false;
            LoadeAllTestTypeOnDropDownList();
            FillAllTest();
        }

        protected void testsSaveButton_Click(object sender, EventArgs e)
        {
            string testName=testNameTextBox.Text;
            decimal fee = Convert.ToDecimal(testFeeTextBox.Text);
            int testType = Convert.ToInt32(testTypeSelectDropDownList.SelectedValue);

            Tests tests = new Tests(testName, fee, testType);

            string message = _testsManager.SaveAllTests(tests);

            if (message == "Test Already Exists!!" || message== "Test Saved Faild!!")
            {
                dangerAlartLabel.Text = message;
                successfullDiv.Visible = false;
                dangerDiv.Visible = true;
            }
            else
            {
                if (message == "Test Saved Successfully Done!!")
                {
                    successfullAlartLabel.Text = message;
                    dangerDiv.Visible = false;
                    successfullDiv.Visible = true;
                }
            }
            
            FillAllTest();
        }

        public void FillAllTest()
        {
            List<Tests> tests = _testsManager.GetAllTests();

            testShowGridView.DataSource = tests;
            testShowGridView.DataBind();
        }

        public void LoadeAllTestTypeOnDropDownList()
        {
            List<TestType> testTypes = _testsManager.GetAllTestType();
            testTypeSelectDropDownList.DataSource = testTypes;
            testTypeSelectDropDownList.DataTextField = "TypeName";
            testTypeSelectDropDownList.DataValueField = "TestTypeId";
            testTypeSelectDropDownList.DataBind();
        }
    }
}