using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaOne.Entities
{
    public class Season
    {

        int _year;
        string _url;
        List<Crew> _crews;
        List<Race> _races;

        public Season(int year, string url)
        {
            Year = year;
            _url = url;


        }

        public List<Crew> Crews { get => _crews; private set => _crews = value; }
        public List<Race> Races { get => _races; private set => _races = value; }
        public int Year { get => _year; private set => _year = value; }

    }
}
