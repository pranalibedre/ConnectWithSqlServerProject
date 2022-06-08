using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWithSqlServerProject
{
    class Gender 
    {
        public string GenderName { get; set; }
        public int GenderId { get; set; }
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public const string connectionString = "Data Source=MUM-LAP-1597\\SQLEXPRESS;Initial Catalog=EMPLOYEE;Integrated Security=True";
        public SqlConnection sqlConnection = new SqlConnection(connectionString);

        public List<Gender> GetGenders()
        {
            var listGenders = new List<Gender>();
            SqlCommand sqlCommand = new SqlCommand("spGetGenders", sqlConnection);
            sqlConnection.Open();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Gender gender = new Gender
                {
                    GenderId = (int)reader[0],
                    GenderName = reader[1].ToString(),
                    PersonId = (int)reader[2],
                    FirstName = reader[3].ToString(),
                    LastName = reader[4].ToString(),
                };
                listGenders.Add(gender);
            }
            Console.WriteLine("Gender Details");
            foreach (var list in listGenders)
            {
                Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}", list.GenderId, list.GenderName, list.PersonId, list.FirstName, list.LastName);
            }
            reader.Close();
            sqlConnection.Close();
            return listGenders;
        }
        public void GetEmployeeByGender(string Gender)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("spGetEmployeeByGender", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = Gender;


                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = "@EmployeeCount";
                sqlParameter.SqlDbType = SqlDbType.Int;
                sqlParameter.Direction = ParameterDirection.Output;
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.ExecuteNonQuery();

                string EmpCount = sqlParameter.Value.ToString();
                Console.WriteLine("Count of Person By Passing Gender");
                Console.WriteLine("Employee Count of {0} = {1} ", Gender, EmpCount);

                sqlConnection.Close();
            }
        }
    }
}
