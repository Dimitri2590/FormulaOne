using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaOne.Entities
{
    public class Ranking
    {
        int _position;
        int _points;

        List<Result> _results;

        public Ranking(int position, int points)
        {
            _points = points;
            _position = position;
            _results = new List<Result>();

        }
        public List<Result> Results { get => _results; set => _results = value; }
    }
}
