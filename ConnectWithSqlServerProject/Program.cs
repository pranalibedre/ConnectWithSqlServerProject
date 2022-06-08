using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWithSqlServerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.GetAllEPersons();

            //person.GetEmpById(2);
            //Gender genderClass = new Gender();
            //genderClass.GetGenders();
            //genderClass.GetEmployeeByGender("Male");
            //Country countryClass = new Country();
            //countryClass.GetCountries();
            //State statesClass = new State();
            //statesClass.GetStates();
            //PeronAddress personAddressClass = new PeronAddress();

            Console.Read();
        }
    }
}
