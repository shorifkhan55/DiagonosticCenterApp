using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillingApp.BLL;
using DiagnosticCenterBillingApp.DAL;
using DiagnosticCenterBillingApp.Model;

namespace DiagnosticCenterBillingApp.UI
{
    public partial class TestTypeEntryUI : System.Web.UI.Page
    {
        TestTypeManager _testTypeManager=new TestTypeManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            testTypeDangerDiv.Visible = false;
            testTypeSuccessfullDiv.Visible = false;
            FillAllTestType();
        }

        protected void testTypeSaveButton_Click(object sender, EventArgs e)
        {
            string testType = testTypeNameTextBox.Value;

            TestType testTypes=new TestType(testType);


            string message = _testTypeManager.SaveTestType(testTypes);

            if (message == "Allready Exists!!" || message == "Data Saved Failed!!")
            {
                testTypeDangerAlartLabel.Text = message;
                testTypeSuccessfullDiv.Visible = false;
                testTypeDangerDiv.Visible= true;
            }
            else
            {
                if (message == "Data Saved Successfully Done !!")
                {
                    testTypeSuccessfullAlartLabel.Text = message;
                    testTypeDangerDiv.Visible = false;
                    testTypeSuccessfullDiv.Visible = true;
                }
            }
            FillAllTestType();
            testTypeNameTextBox.Value = "";
        }

        public void FillAllTestType()
        {
            List<TestType> testTypes = _testTypeManager.GetAllTestType();
            testTypeShowGridView.DataSource = testTypes;
            testTypeShowGridView.DataBind();
        }
    }
}