using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using BillingManagmentOfDiagonosticCenterApp.Model;

namespace BillingManagmentOfDiagonosticCenterApp.DAL
{
    public class TestTypeGateway
    {
        string connectionString =
            WebConfigurationManager.ConnectionStrings["DiagnosticCenterManagementDBConnectionString"].ConnectionString;

        public int Save(TestType testType)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "INSERT INTO Types(Name) VALUES('"+testType.Name+"')";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public List<TestType> GetAllTypesList()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT *FROM Types ORDER BY Name";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<TestType> typeList=new List<TestType>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["Id"].ToString());
                    string name = reader["Name"].ToString();

                    TestType testType=new TestType(id,name);
                    typeList.Add(testType);
                }
                reader.Close();
            }
            connection.Close();
            return typeList;         
        }

        public bool IsTestTypeExist(TestType testType)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT *FROM Types WHERE Name='"+testType.Name+"'";

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
    }
}