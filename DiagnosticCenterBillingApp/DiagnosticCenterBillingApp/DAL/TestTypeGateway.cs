using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DiagnosticCenterBillingApp.Model;

namespace DiagnosticCenterBillingApp.DAL
{
    public class TestTypeGateway
    {

        string connectionString = WebConfigurationManager.ConnectionStrings["DiagosustingCenterConnectionString"].ConnectionString;

        public int InsertTestType(TestType testType)
        {
            SqlConnection connection=new SqlConnection(connectionString);

            

            string query = "INSERT INTO TestType (TypeName) VALUES ('"+testType.TypeName+"')";

            SqlCommand command=new SqlCommand(query, connection);

            connection.Open();

            int rowAffacted = command.ExecuteNonQuery();

            connection.Close();

            return rowAffacted;
        }

        public TestType GetTestTypeName(string testType)
        {
            SqlConnection connection =new SqlConnection(connectionString);

            string query = "SELECT * FROM TestType WHERE TypeName='"+testType+"'";

            SqlCommand command =new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            TestType testTypes = null;
            if (reader.HasRows)
            {
                reader.Read();
                int typeId = Convert.ToInt32(reader["TestTypeId"]);
                string typeName = reader["TypeName"].ToString();

                testTypes=new TestType(typeId, typeName);
            }
            connection.Close();
            return testTypes;
        }

        public List<TestType> GetAllTestTypes()
        {
            SqlConnection connection=new SqlConnection(connectionString);
            
            string query = "SELECT * FROM TestType";
            
            SqlCommand command=new SqlCommand(query, connection);
            
            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<TestType> testTypeList=new List<TestType>();
            int serialNo = 1;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int typeId = Convert.ToInt32(reader["TestTypeId"]);
                    string typeName = reader["TypeName"].ToString();

                    TestType testTypes=new TestType(typeId, typeName, serialNo);
                    serialNo++;
                    testTypeList.Add(testTypes);
                }
                reader.Close();
                connection.Close();
            }
            return testTypeList;

        }

    }
}