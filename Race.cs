using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaOne.Entities
{
    public class Race
    {
        int _id;
        string _name;
        Circuit _circuit;
        List<Qualifying> _qualifyings;
        List<Result> _results;
        Season _season;

        public Race(int id, string name, Circuit circuit, Season season)
        {
            _id = id;
            _name = name;
            Circuit = circuit;
            Qualifyings = new List<Qualifying>();
            Results = new List<Result>();
            Season = season;
        }

        public Circuit Circuit { get => _circuit; private set => _circuit = value; }
        public List<Qualifying> Qualifyings { get => _qualifyings; private set => _qualifyings = value; }
        public List<Result> Results { get => _results; private set => _results = value; }
        public Season Season { get => _season; private set => _season = value; }
    }
}
