using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BillingManagmentOfDiagonosticCenterApp.DAL;
using BillingManagmentOfDiagonosticCenterApp.Model;

namespace BillingManagmentOfDiagonosticCenterApp.BLL
{
    public class PatientManager
    {
        PatientGateway _patientGateway=new PatientGateway();
        public int Save(Patient patient)
        {
            return _patientGateway.Save(patient);
        }

        public int GetLastPatientId()
        {
            return _patientGateway.GetLastPatientId();
        }
    }
}