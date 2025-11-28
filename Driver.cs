using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaOne.Entities
{
    public class Driver
    {
        int _id;
        string _firstName;
        string _lastName;
        string _code;
        int _number;
        string _nationality;
        DateTime _dob;
        List<Crew> _crews;


        public Driver(int id, string firstName, string lastName, int number, string nationality, DateTime dob)
        {
            _id = id;
            FirstName = firstName;
            LastName = lastName;
            Number = number;
            Nationality = nationality;
            Dob = dob;

        }

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Nationality { get => _nationality; set => _nationality = value; }
        public DateTime Dob { get => _dob; set => _dob = value; }
        public List<Crew> Crews { get => _crews; set => _crews = value; }
        public int Number { get => _number; set => _number = value; }
        public string Code { get => _code; private set => _code = value; }
    }
}
