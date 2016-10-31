using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using BillingManagmentOfDiagonosticCenterApp.Model;

namespace BillingManagmentOfDiagonosticCenterApp.DAL
{
    public class BillGateway
    {
        string connectionString =
           WebConfigurationManager.ConnectionStrings["DiagnosticCenterManagementDBConnectionString"].ConnectionString;

        public int Save(Bill bill)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO Bills(BillNo,Date,Status) VALUES('" + bill.BillNo + "','" + bill.Date + "'," + bill.Status + ")";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

    }
}