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

        public List<ViewTypeWithTotalTest> GetTypeReportByDate(DateTime lowerDate, DateTime upperDate)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT Tp.Name,ISNULL(SUM(Te.TotalTest),0) TotalTest,ISNULL(SUM(Te.TotalAmount),0) TotalAmount FROM Types Tp LEFT JOIN (SELECT T.TypeId, COUNT(R.BillNo) TotalTest, T.Fee*COUNT(R.BillNo) AS TotalAmount FROM (SELECT O.TestId,O.BillNo FROM Orders O INNER JOIN Bills B ON O.BillNo=B.BillNo WHERE B.Date>='"+lowerDate+"' AND B.Date<='"+upperDate+"') R INNER JOIN Tests T ON R.TestId=T.Id GROUP BY T.TypeId,T.Fee) Te ON Tp.Id=Te.TypeId GROUP BY Tp.Name";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            List<ViewTypeWithTotalTest> viewTypeWithTotalTestsList = new List<ViewTypeWithTotalTest>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ViewTypeWithTotalTest viewTypeWithTotalTest=new ViewTypeWithTotalTest();
                    viewTypeWithTotalTest.Name = reader["Name"].ToString();
                    viewTypeWithTotalTest.TotalTest = int.Parse(reader["TotalTest"].ToString());
                    viewTypeWithTotalTest.TotalAmount = double.Parse(reader["TotalAmount"].ToString());

                    viewTypeWithTotalTestsList.Add(viewTypeWithTotalTest);
                }
                reader.Close();
            }
            connection.Close();

            return viewTypeWithTotalTestsList;
        }
    }
}