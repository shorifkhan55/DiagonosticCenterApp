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

            string query = "SELECT *FROM ViewAllTestWithType ORDER BY Name";

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

        public List<Test> GetAllTestsList()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT *FROM Tests";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            List<Test> testsList = new List<Test>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = int.Parse(reader["Id"].ToString());
                    string name = reader["Name"].ToString();
                    double fee = double.Parse(reader["Fee"].ToString());
                    int typeId = int.Parse(reader["TypeId"].ToString());

                    Test test = new Test(id, name,fee,typeId);
                    testsList.Add(test);
                }
                reader.Close();
            }
            connection.Close();
            return testsList;
        }

        public double GetFeeByTestId(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT Fee FROM Tests WHERE Id='"+ id +"'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            double fee=0;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    fee = double.Parse(reader["Fee"].ToString());
                }
                reader.Close();
            }
            connection.Close();
            return fee;
        }

        public Test GetTestById(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Tests WHERE Id='" + id + "'";

            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            Test test = null;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    test=new Test();
                    test.Id = int.Parse(reader["Id"].ToString());
                    test.Fee = double.Parse(reader["Fee"].ToString());
                    test.Name = reader["Name"].ToString();
                    test.TypeId = int.Parse(reader["TypeId"].ToString());
                }
                reader.Close();
            }
            connection.Close();
            return test;
        }
    }
}