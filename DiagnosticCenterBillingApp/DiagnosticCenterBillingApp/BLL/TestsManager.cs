using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillingApp.DAL;
using DiagnosticCenterBillingApp.Model;

namespace DiagnosticCenterBillingApp.BLL
{
    public class TestsManager
    {
        TestsGateway _testsGateway=new TestsGateway();

        public List<TestType> GetAllTestType()
        {
            return _testsGateway.GetAllTestType();
        }

        public bool IsExistsTestsName(Tests tests)
        {
            bool isExists = false;
            if (_testsGateway.GetTestsByTestName(tests.TestName) != null)
            {
                isExists = true;
            }
            return isExists;
        }

        public string SaveAllTests(Tests tests)
        {
            if (IsExistsTestsName(tests))
            {
                return "Test Already Exists!!";
            }
            else
            {
                if (_testsGateway.InsertTests(tests)>0)
                {
                    return "Test Saved Successfully Done!!";
                }
                else
                {
                    return "Test Saved Faild!!";
                }
            }
        }

        public List<Tests> GetAllTests()
        {
            return _testsGateway.GetAllTests();
        }

    }
}