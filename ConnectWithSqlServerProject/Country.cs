using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWithSqlServerProject
{
    class Country 
    {
        public const string connectionString = "Data Source=MUM-LAP-1597\\SQLEXPRESS;Initial Catalog=EMPLOYEE;Integrated Security=True";
        public SqlConnection sqlConnection = new SqlConnection(connectionString);
        public int CountryId { get; set; }
        public string  CountryName { get; set; }
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Country> GetCountries()
        {
            var listCountries = new List<Country>();
            SqlCommand sqlCommand = new SqlCommand("spGetCountries", sqlConnection);
            sqlConnection.Open();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Country country = new Country
                {
                    CountryId = (int)reader[0],
                    CountryName = reader[1].ToString(),
                    PersonId = (int)reader[2],
                    FirstName = reader[3].ToString(),
                    LastName = reader[4].ToString(),
                };
                listCountries.Add(country);
            }
            Console.WriteLine("Country Details");
            foreach (var list in listCountries)
            {
                Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}", list.CountryId, list.CountryName, list.PersonId, list.FirstName, list.LastName);
            }
            reader.Close();
            sqlConnection.Close();
            return listCountries;
        }
    }
}
