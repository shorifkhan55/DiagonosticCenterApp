using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DiagnosticCenterBillingApp.Model;

namespace DiagnosticCenterBillingApp.DAL
{
    public class TestRequestGateway
    {
       string connectionString = WebConfigurationManager.ConnectionStrings["DiagosustingCenterConnectionString"].ConnectionString;

        public List<Tests> GetAllTestsWithFee()
        {
            SqlConnection connection =new SqlConnection(connectionString);

            string query = "SELECT * FROM Tests";

            SqlCommand command =new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Tests> testsList=new List<Tests>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int testId = Convert.ToInt32(reader["TestId"]);
                    string testName = reader["TestName"].ToString();
                    decimal fee = Convert.ToDecimal(reader["Fee"]);
                    int testType = Convert.ToInt32(reader["TestType"]);
                    Tests tests=new Tests(testId, testName, fee, testType);

                    testsList.Add(tests);
                }
                reader.Close();
                connection.Close();
            }
            return testsList;
        }
       
        public decimal GetTestFee(int testId)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT Fee FROM Tests WHERE TestId="+testId+"";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            decimal fee = 0;

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                fee = (decimal)reader["Fee"];
            }
            connection.Close();
            return fee;
        }
    }
}