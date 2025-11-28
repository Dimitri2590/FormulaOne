using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaOne.Entities
{
    public class Constructor
    {
        int _id;
        string _name;
        string _nationality;
        string _url;
        List<Crew> _crews;


        public Constructor(int id, string name, string nationality, string url)
        {
            Id = id;
            Name = name;
            Nationality = nationality;
            Url = url;
        }

        public List<Crew> Crews { get => _crews; set => _crews = value; }
        public string Name { get => _name; set => _name = value; }
        public string Nationality { get => _nationality; set => _nationality = value; }
        public string Url { get => _url; set => _url = value; }
        public int Id { get => _id; private set => _id = value; }
    }
}
