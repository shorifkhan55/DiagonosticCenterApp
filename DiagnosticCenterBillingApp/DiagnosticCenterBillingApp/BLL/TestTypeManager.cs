using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillingApp.DAL;
using DiagnosticCenterBillingApp.Model;

namespace DiagnosticCenterBillingApp.BLL
{
    public class TestTypeManager
    {
        TestTypeGateway _testTypeGateway=new TestTypeGateway();


        public bool IsExistsForByTypeName(TestType testType)
        {
            bool IsExists = false;
            if (_testTypeGateway.GetTestTypeName(testType.TypeName)!=null)
            {
                IsExists = true;
            }
            return IsExists;
        }

        public string SaveTestType(TestType testType)
        {
           if (IsExistsForByTypeName(testType))
            {

              return "Allready Exists!!";
            }
            else
            {
            if (_testTypeGateway.InsertTestType(testType) > 0)
                {
                  return "Data Saved Successfully Done !!";
                }
                 else
                {
                  return "Data Saved Failed!!";
                 }
            }
        }

        public List<TestType> GetAllTestType()
        {
            return _testTypeGateway.GetAllTestTypes();
        }

    }
}