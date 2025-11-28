using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaOne.Entities
{
    public class Status
    {
        int _id;
        string _description;
        List<Result> _results;

        public Status(int id, string description)
        {
            _id = id;
            Description = description;
            _results = new List<Result>();
        }

        public List<Result> Results { get => _results; set => _results = value; }
        public string Description { get => _description; set => _description = value; }
    }
}
