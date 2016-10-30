using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingManagmentOfDiagonosticCenterApp.DAL;
using BillingManagmentOfDiagonosticCenterApp.Model;

namespace BillingManagmentOfDiagonosticCenterApp.BLL
{
    public class TestManager
    {
        TestGateway _testGateway=new TestGateway();
        public int Save(Test test)
        {
            return _testGateway.Save(test);
        }

        public bool IsTestExist(Test test)
        {
            return _testGateway.IsTestExist(test);
        }
    }
}