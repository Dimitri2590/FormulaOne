using System;
using System.Collections.Generic;

namespace FormulaOne.Entities
{
    public class Circuit
    {
        int _id;
        string _name;
        string _location;
        string _country;
        double _lat;
        double _long;
        List<Race> _races;

        public Circuit(int id, string name, string location, string country, double lat, double @long)
        {
            Id = id;
            Name = name;
            Location = location;
            Country = country;
            Lat = lat;
            Long = @long;


        }

        public List<Race> Races { get => _races; set => _races = value; }
        public string Name { get => _name; set => _name = value; }
        public string Location { get => _location; set => _location = value; }
        public string Country { get => _country; set => _country = value; }
        public double Lat { get => _lat; set => _lat = value; }
        public double Long { get => _long; set => _long = value; }
        public int Id { get => _id; private set => _id = value; }




    }
}
