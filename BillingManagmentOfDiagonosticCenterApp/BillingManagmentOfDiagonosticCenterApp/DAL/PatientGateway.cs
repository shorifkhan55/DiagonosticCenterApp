using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using BillingManagmentOfDiagonosticCenterApp.Model;

namespace BillingManagmentOfDiagonosticCenterApp.DAL
{
    public class PatientGateway
    {

        string connectionString =
           WebConfigurationManager.ConnectionStrings["DiagnosticCenterManagementDBConnectionString"].ConnectionString;

        public int Save(Patient patient)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO Patients(Name,DateOfBirth,Mobile) VALUES('" + patient.Name + "','" + patient.DateOfBirth + "','" + patient.MobileNo + "')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public int GetLastPatientId()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT IDENT_CURRENT('Patients') as LastId";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            int id = 0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    id = int.Parse(reader["LastId"].ToString());
                }
                reader.Close();
            }
            connection.Close();

            return id;
        }
    }
}