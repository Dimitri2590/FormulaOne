using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaOne.Entities
{
    public class Crew
    {

        Constructor _constructor;
        Driver _driver;
        Season _season;
        List<Qualifying> _qualifyings;
        List<Result> _results;

        public Crew(
             Constructor constructor,
        Driver driver,
        Season season
            )
        {
            Constructor = constructor;
            Driver = driver;
            Season = season;


        }

        public Constructor Constructor { get => _constructor; private set => _constructor = value; }
        public Driver Driver { get => _driver; private set => _driver = value; }
        public Season Season { get => _season; private set => _season = value; }
        public List<Qualifying> Qualifyings { get => _qualifyings; set => _qualifyings = value; }
        public List<Result> Results { get => _results; set => _results = value; }
    }
}