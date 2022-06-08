using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ConnectWithSqlServerProject
{
    class Person
    {
        public int CountryId { get; set; }
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GenderName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public long TelephoneNo { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string CountryName { get; set; }
        public int Pincode { get; set; }
        public string State { get; set; }
        public const string connectionString = "Data Source=MUM-LAP-1597\\SQLEXPRESS;Initial Catalog=EMPLOYEE;Integrated Security=True";
        public SqlConnection sqlConnection = new SqlConnection(connectionString);

        public List<Person> GetAllEPersons()
        {
            var listPersons = new List<Person>();
            SqlCommand sqlCommand = new SqlCommand("spPersonDetails", sqlConnection);
            sqlConnection.Open();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Person person = new Person
                {
                    PersonId = (int)reader[0],
                    FirstName = reader[1].ToString(),
                    LastName = reader[2].ToString(),
                    Age = (int)reader[3],
                    GenderName = reader[4].ToString(),
                    DateOfBirth = (DateTime)reader[5],
                    Email = reader[6].ToString(),
                    TelephoneNo = (long)reader[7],
                    AddressLine1 = reader[8].ToString(),
                    AddressLine2 = reader[9].ToString(),
                    City = reader[10].ToString(),
                    CountryName = reader[11].ToString(),
                    Pincode = (int)reader[12],
                    State = reader[13].ToString(),
                };
                listPersons.Add(person);
            }
            foreach (var list in listPersons)
            {
                Console.WriteLine($"{list.PersonId}\t{list.FirstName}\t{list.LastName}\t{list.Age}\t{list.GenderName}\t{list.DateOfBirth}\t{list.Email}\t{list.TelephoneNo}\t{list.AddressLine1}\t{list.AddressLine2}\t{list.City}\t{list.CountryName}\t{list.Pincode}\t{list.State}");
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------------------------------");
            }
            //foreach (var list in listPersons)
            //    Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}\t{11}\t{12}", list.PersonId, list.FirstName, list.LastName, list.Age, list.Gender, list.DateOfBirth, list.Email, list.TelephoneNo, list.AddressLine1, list.AddressLine2, list.City, list.City, list.Pincode);

            reader.Close();
            sqlConnection.Close();
            return listPersons;
        }
        public Person GetEmpById(int PersonId)
        {
            var person = new Person();
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spGetPersonDetailsByID", sqlConnection);
                sqlConnection.Open();
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("@PersonId", SqlDbType.Int).Value = PersonId;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.Read())
                {
                    person = new Person
                    {
                        PersonId = (int)reader[0],
                        FirstName = reader[1].ToString(),
                        LastName = reader[2].ToString(),
                        Age = (int)reader[3],
                        GenderName = reader[4].ToString(),
                        DateOfBirth = (DateTime)reader[5],
                        Email = reader[6].ToString(),
                        TelephoneNo = (long)reader[7],
                        AddressLine1 = reader[8].ToString(),
                        AddressLine2 = reader[9].ToString(),
                        City = reader[10].ToString(),
                        CountryName = reader[11].ToString(),
                        Pincode = (int)reader[12],
                    };
                    Console.WriteLine("Details By Passing Employee Id");
                    Console.WriteLine($"{person.PersonId}\t{person.FirstName}\t{person.LastName}\t{person.Age}\t{person.GenderName}\t{person.DateOfBirth}\t{person.Email}\t{person.TelephoneNo}\t{person.AddressLine1}\t{person.AddressLine2}\t{person.City}\t{person.CountryName}\t{person.Pincode}");
                }
                else
                {
                    throw new Exception("Id does not exists");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close();
            }

            return person;
        }

    }


}


