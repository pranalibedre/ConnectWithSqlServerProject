using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectWithSqlServerProject
{
    public class PersonAddress
    {
        public int AddressId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int PinCode { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }
    }
}
