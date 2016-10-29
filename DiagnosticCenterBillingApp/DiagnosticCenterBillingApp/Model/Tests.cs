using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillingApp.Model
{
    public class Tests
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public decimal Fee { get; set; }
        public int TestType { get; set; }
        public int SerialNo { get; set; }

        public Tests(string testName, decimal fee, int testType)
        {
            this.TestName = testName;
            this.Fee = fee;
            this.TestType = testType;
        }

        public Tests(int testId, string testName, decimal fee, int testTyp) : this(testName, fee, testTyp)
        {
            this.TestId = testId;
        }

        public Tests(int testId, int testType, string testName, decimal fee)
            : this(testId, testName, fee)
        {
            this.TestType = testType;
        }

        public Tests(string testName, decimal fee)
        {
            // TODO: Complete member initialization
            this.TestName = testName;
            this.Fee = fee;
        }

        public Tests(int testId, string testName, decimal fee)
        {
            // TODO: Complete member initialization
            this.TestId = testId;
            this.TestName = testName;
            this.Fee = fee;
        }
    }
}