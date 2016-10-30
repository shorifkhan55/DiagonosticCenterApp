using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using BillingManagmentOfDiagonosticCenterApp.Model;
using BillingManagmentOfDiagonosticCenterApp.Model.ViewModels;

namespace BillingManagmentOfDiagonosticCenterApp.DAL
{
    public class TestGateway
    {
        string connectionString =
            WebConfigurationManager.ConnectionStrings["DiagnosticCenterManagementDBConnectionString"].ConnectionString;


        public int Save(Test test)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO Tests(Name,Fee,TypeId) VALUES('"+ test.Name +"','"+test.Fee+"',"+test.TypeId+")";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public bool IsTestExist(Test test)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT *FROM Tests WHERE Name='" + test.Name + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<ViewAllTestWithType> GetAllTypesListWithType()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT *FROM ViewAllTestWithType";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<ViewAllTestWithType> testListWithTypeName = new List<ViewAllTestWithType>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ViewAllTestWithType testWithTypeName = new ViewAllTestWithType();
                    testWithTypeName.Id = int.Parse(reader["Id"].ToString());
                    testWithTypeName.Name = reader["Name"].ToString();
                    testWithTypeName.Fee = double.Parse(reader["Fee"].ToString());
                    testWithTypeName.TypeId = int.Parse(reader["TypeId"].ToString());
                    testWithTypeName.TypeName = reader["TypeName"].ToString();

                    testListWithTypeName.Add(testWithTypeName);
                }
                reader.Close();
            }
            connection.Close();

            return testListWithTypeName;
        }
    }
}