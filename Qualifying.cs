using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaOne.Entities
{
    public class Qualifying
    {
        int _id;
        int _position;
        TimeSpan _qualifyingTime1;
        TimeSpan _qualifyingTime2;
        TimeSpan _qualifyingTime3;
        Race _race;
        Crew _crew;
        private TimeSpan time;

        public Qualifying(Race race, Crew crew, TimeSpan time, TimeSpan qualifyingTime1, TimeSpan qualifyingTime2, TimeSpan qualifyingTime3)
        {
            Race = race;
            Crew = crew;
            this.time = time;
            QualifyingTime1 = qualifyingTime1;
            QualifyingTime2 = qualifyingTime2;
            QualifyingTime3 = qualifyingTime3;
        }

        public Qualifying(int id, int position,
            TimeSpan qualifyingTime1,
            TimeSpan qualifyingTime2,
            TimeSpan qualifyingTime3,
            Race race,
            Crew crew)
        {
            _id = id;
            Position = position;
            QualifyingTime1 = qualifyingTime1;
            QualifyingTime2 = qualifyingTime2;
            QualifyingTime3 = qualifyingTime3;

        }

        public int Position { get => _position; set => _position = value; }
        public Race Race { get => _race; private set => _race = value; }
        public Crew Crew { get => _crew; private set => _crew = value; }
        public TimeSpan QualifyingTime1 { get => _qualifyingTime1; set => _qualifyingTime1 = value; }
        public TimeSpan QualifyingTime2 { get => _qualifyingTime2; set => _qualifyingTime2 = value; }
        public TimeSpan QualifyingTime3 { get => _qualifyingTime3; set => _qualifyingTime3 = value; }
    }
}
