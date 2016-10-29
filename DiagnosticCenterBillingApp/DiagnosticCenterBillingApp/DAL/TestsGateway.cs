using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DiagnosticCenterBillingApp.Model;

namespace DiagnosticCenterBillingApp.DAL
{
    public class TestsGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["DiagosustingCenterConnectionString"].ConnectionString;
        
        public List<TestType>GetAllTestType()
        {
            SqlConnection connection=new SqlConnection(connectionString);

            string query = "SELECT * FROM TestType";

            SqlCommand command=new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<TestType> testTypeList=new List<TestType>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int testTypeId = Convert.ToInt32(reader["TestTypeId"]);
                    string typeName = reader["TypeName"].ToString();

                    TestType testType=new TestType(testTypeId, typeName);

                    testTypeList.Add(testType);
                }
                reader.Close();
                connection.Close();
            }
            return testTypeList;
        }

        public int InsertTests(Tests tests)
        {
            SqlConnection connection=new SqlConnection(connectionString);

            string query = "INSERT INTO Tests (TestName, Fee, TestType) VALUES ('"+tests.TestName+"','"+tests.Fee+"','"+tests.TestType+"')";
            
            SqlCommand command=new SqlCommand(query, connection);

            connection.Open();

            int rowAffacted = command.ExecuteNonQuery();

            connection.Close();
            return rowAffacted;
        }

        public Tests GetTestsByTestName(string testName)
        {
            SqlConnection connection=new SqlConnection(connectionString);

            string query = "SELECT * FROM Tests WHERE TestName='"+testName+"' ";

            SqlCommand command=new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Tests tests = null;
            if (reader.HasRows)
            {
                reader.Read();
                int testId = Convert.ToInt32(reader["TestId"]);
                string testname = reader["TestName"].ToString();
                decimal fee = Convert.ToDecimal(reader["Fee"]);
                int testType = Convert.ToInt32(reader["TestType"]);

                tests=new Tests(testId, testName, fee, testType);
            }
            connection.Close();
            return tests;
        }

        public List<Tests> GetAllTests()
        {
            SqlConnection connection =new SqlConnection(connectionString);

            string query = " SELECT *FROM Tests";

            SqlCommand command=new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<Tests> testList=new List<Tests>();
            int serialNo = 1;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int testId = Convert.ToInt32(reader["TestId"]);
                    string testName = reader["TestName"].ToString();
                    decimal fee = Convert.ToDecimal(reader["Fee"]);
                    
                    Tests tests=new Tests(testId, testName, fee, serialNo);
                    serialNo++;
                    testList.Add(tests);
                }
                reader.Close();
                connection.Close();
            }

            return testList;
        }
    }
}