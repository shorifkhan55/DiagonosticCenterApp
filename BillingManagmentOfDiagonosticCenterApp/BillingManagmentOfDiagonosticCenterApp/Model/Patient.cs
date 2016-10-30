using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingManagmentOfDiagonosticCenterApp.Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public DateTime DateOfBirth { get; set; }

        
        public Patient(string name,string mobileNo,DateTime dateOfBirth)
        {
            this.Name = name;
            this.MobileNo = mobileNo;
            this.DateOfBirth = dateOfBirth;
        }

        public Patient(int id,string name, string mobileNo, DateTime dateOfBirth):this(name,mobileNo,dateOfBirth)
        {
            this.Id = id;
        }

    }
}