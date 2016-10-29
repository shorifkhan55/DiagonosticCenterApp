using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillingApp.DAL;
using DiagnosticCenterBillingApp.Model;

namespace DiagnosticCenterBillingApp.BLL
{
    public class TestRequestManager
    {
        TestRequestGateway _testRequestGateway=new TestRequestGateway();

        public List<Tests> GetAllTestsWithFee()
        {
            return _testRequestGateway.GetAllTestsWithFee();
        }

        

        public decimal GetTestFee(int testId)
        {
            return _testRequestGateway.GetTestFee(testId);
        }
    }
}