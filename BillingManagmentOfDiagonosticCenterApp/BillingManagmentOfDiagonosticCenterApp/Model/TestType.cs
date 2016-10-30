using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingManagmentOfDiagonosticCenterApp.Model
{
    public class TestType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TestType(string name)
        {
            this.Name = name;
        }
        public TestType(int id,string name):this(name)
        {
            this.Id = id;
        }
    }
}