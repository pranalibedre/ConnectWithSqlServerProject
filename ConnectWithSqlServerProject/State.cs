using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWithSqlServerProject
{
    class State 
    {
        public string StateName { get; set; }
        public int StateId { get; set; }
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public const string connectionString = "Data Source=MUM-LAP-1597\\SQLEXPRESS;Initial Catalog=EMPLOYEE;Integrated Security=True";
        public SqlConnection sqlConnection = new SqlConnection(connectionString);
        public List<State> GetStates()
        {
            var listStates = new List<State>();
            SqlCommand sqlCommand = new SqlCommand("spGetStates", sqlConnection);
            sqlConnection.Open();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                State states = new State
                {
                    StateId = (int)reader[0],
                    StateName = reader[1].ToString(),
                    PersonId = (int)reader[2],
                    FirstName = reader[3].ToString(),
                    LastName = reader[4].ToString(),
                };
                listStates.Add(states);
            }
            Console.WriteLine("State Details");
            foreach (var list in listStates)
            {
                Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}", list.StateId, list.StateName, list.PersonId, list.FirstName, list.LastName);
            }
            reader.Close();
            sqlConnection.Close();
            return listStates;
        }
    }
}
