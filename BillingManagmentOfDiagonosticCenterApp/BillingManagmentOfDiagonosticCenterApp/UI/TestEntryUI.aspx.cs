using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingManagmentOfDiagonosticCenterApp.BLL;
using BillingManagmentOfDiagonosticCenterApp.Model;

namespace BillingManagmentOfDiagonosticCenterApp.UI
{
    public partial class TestEntryUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dangerDiv.Visible = false;
            successfullDiv.Visible = false;
            
            if (!IsPostBack)
            {
                LoadTestTypeDropDownList();
            }
        }

        public void LoadTestTypeDropDownList()
        {
            TestTypeManager testTypeManager=new TestTypeManager();
            List<TestType> testTypeList = testTypeManager.GetAllTypesList();
            testTypeSelectDropDownList.DataSource = testTypeList;
            testTypeSelectDropDownList.DataTextField = "Name";
            testTypeSelectDropDownList.DataValueField = "Id";
            testTypeSelectDropDownList.DataBind();

        }

        protected void testsSaveButton_Click(object sender, EventArgs e)
        {
            if (testNameTextBox.Text.Trim() != "" && testFeeTextBox.Text.Trim() != "")
            {
                double testFee;
                bool isDouble = Double.TryParse(testFeeTextBox.Text.Trim(), out testFee);
                if (isDouble)
                {
                    TestManager testManager = new TestManager();
                    string testName = testNameTextBox.Text.Trim();

                    int typeId = int.Parse(testTypeSelectDropDownList.SelectedValue);

                    Test test = new Test(testName, testFee, typeId);
                    if (!testManager.IsTestExist(test))
                    {
                        int rowAffected = testManager.Save(test);

                        if (rowAffected > 0)
                        {
                            successfullAlartLabel.Text = "Successfully Saved!!";
                            dangerDiv.Visible = false;
                            successfullDiv.Visible = true;
                        }
                        else
                        {
                            dangerAlartLabel.Text = "Test Entry Failed!!";
                            dangerDiv.Visible = true;
                            successfullDiv.Visible = false;
                        }
                    }
                    else
                    {
                        dangerAlartLabel.Text = "Test Entry is exist!!";
                        dangerDiv.Visible = true;
                        successfullDiv.Visible = false;
                    }
                    
                }
                else
                {
                    dangerAlartLabel.Text = "Please, Enter numeric value as fee";
                    dangerDiv.Visible = true;
                    successfullDiv.Visible = false;
                }
                

            }
            else
            {
                dangerAlartLabel.Text = "Please, Input required for all field.";
                dangerDiv.Visible = true;
                successfullDiv.Visible = false;
            }
            


        }
    }
}