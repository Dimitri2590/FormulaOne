using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FormulaOne.Entities
{
    public class Result
    {
        int _position;
        TimeSpan _time;
        Race _race;
        Crew _crew;
        Ranking _rank;
        Status _status;

        public Result(Race race, Crew crew, TimeSpan time, Status status)
        {
            Time = time;
            Race = race;
            Crew = crew;
            Status = status;

        }

        public Race Race { get => _race; set => _race = value; }
        public Crew Crew { get => _crew; set => _crew = value; }
        public Ranking Rank { get => _rank; set => _rank = value; }
        public Status Status { get => _status; set => _status = value; }
        public TimeSpan Time { get => _time; set => _time = value; }
        public int Position { get => _position; private set => _position = value; }

        public void CalculatePosition()
        {

        }

    }
}
