using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using BillingManagmentOfDiagonosticCenterApp.Model;

namespace BillingManagmentOfDiagonosticCenterApp.DAL
{
    public class OrderGateway
    {
        string connectionString =
           WebConfigurationManager.ConnectionStrings["DiagnosticCenterManagementDBConnectionString"].ConnectionString;

        public int Save(Order order)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO Orders(PatientId,TestId,BillNo) VALUES(" + order.PatientId + "," + order.TestId+ ",'" + order.BillNo + "')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}