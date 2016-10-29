using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillingApp.Model
{
    public class TestType
    {
        public int TestTypeId { get; set; }
        public string TypeName { get; set; }
        public int SerialNo { get; set; }

        public TestType(string typeName)
        {
            this.TypeName = typeName;
        }

        public TestType(int testTypeId, string typeName) : this(typeName)
        {
            this.TestTypeId = testTypeId;
        }

        public TestType(int testTypeId, string typeName, int serialNo) : this(testTypeId, typeName)
        {
            this.SerialNo = serialNo;
        }
    }
}