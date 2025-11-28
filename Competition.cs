using System;
using System.Collections.Generic;
using System.Text;


namespace FormulaOne.Entities
{
    public class Competition
    {
        const int NUMBER_OF_CREWS = 2;
        List<Circuit> _circuits;
        List<Status> _status;
        List<Season> _seasons;
        List<Ranking> _rankings;
        List<Constructor> _constructors;
        List<Driver> _drivers;

        public Competition()
        {
            Circuits = new List<Circuit>();
            Status = new List<Status>();
            Seasons = new List<Season>();
            Rankings = new List<Ranking>();
            Constructors = new List<Constructor>();
            Drivers = new List<Driver>();
        }

        public List<Circuit> Circuits { get => _circuits; set => _circuits = value; }
        public List<Status> Status { get => _status; set => _status = value; }
        public List<Season> Seasons { get => _seasons; set => _seasons = value; }

        public List<Ranking> Rankings { get => _rankings; set => _rankings = value; }
        public List<Constructor> Constructors { get => _constructors; set => _constructors = value; }
        public List<Driver> Drivers { get => _drivers; set => _drivers = value; }


        #region code OK
        public int AddCircuit(string name, string location, string country, double lat, double @long)
        {
            Circuit circuit = new Circuit(_circuits.Count + 1, name, location, country, lat, @long);
            _circuits.Add(circuit);
            return _circuits.Count;
        }

        public int AddSeason(int year, string url)
        {
            Season season = new Season(year, url);
            _seasons.Add(season);
            return _seasons.Count;
        }

        public int AddConstructor(string name, string nationality, string url)
        {
            Constructor constructor = new Constructor(_constructors.Count + 1, name, nationality, url);
            _constructors.Add(constructor);
            return _constructors.Count;
        }




        public int AddStatus(string description)
        {
            Status status = new Status(_status.Count, description);
            _status.Add(status);
            return _status.Count;
        }

        public int AddScoring(int points)
        {
            Ranking ranking = new Ranking(_rankings.Count, points);
            _rankings.Add(ranking);
            return _rankings.Count;
        }
        #endregion


        /// <summary> 
        /// Add a driver if the number is OK
        /// </summary>
        /// <param name="number"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="dateTime"></param>
        /// <param name="nationality"></param>
        /// <returns> code or invalid number if the number has been already used </returns>

        public string AddDriver(int number, string firstName, string lastName, DateTime dateTime, string nationality)
        {
            string result = "Invalid Number";

            if (_drivers.Find(d => d.Number == number) == null)
            {
                result = lastName.Substring(0, Math.Min(3, lastName.Length)).ToUpper();
                Driver driver = new Driver(_drivers.Count + 1, firstName, lastName, number, nationality, dateTime);
                return result;
            }
            return result;
        }

        /// <summary>
        /// add a race 
        /// only if the circuit and the season are in the data
        /// </summary>
        /// <param name="seasonYear"></param>
        /// <param name="circuitId"></param>
        /// <returns> 0 if there is an error </returns>

        public int AddRace(int seasonYear, int circuitId)
        {
            int result = 0;

            if (_seasons.Find(season => season.Year == seasonYear) != null && 
                _circuits.Find(circuit => circuit.Id == circuitId) != null)
            {
                Season season = _seasons.Find(season => season.Year == seasonYear);
                Circuit circuit = _circuits.Find(circuit => circuit.Id == circuitId);
                _circuits.Add(circuit);
                _seasons.Add(season);
                result = 1;
            }
            return result;
            
        }

        /// <summary>
        /// add a new crew if the data are OK
        /// </summary>
        /// <param name="driverCode"></param>
        /// <param name="constructorId"></param>
        /// <param name="seasonYear"></param>
        /// <returns> 
        /// "Unknown Driver"      : if the driver is not in the data
        /// "Unknown Constructor" : if the Constructor is not in the data
        /// "Unknown Season"      : if the Season is not in the data
        /// "Already in a crew"   : if for this season the driver is already in a crew
        /// "Too many crews for this constructor" : if   for this season the constructor has already the number of crews defined 
        /// </returns>

        public string AddCrew(string driverCode, int constructorId, int seasonYear)
        {
            string result = "New Crew added";

            if (_seasons.Find(season => season.Year == seasonYear) != null &&
                _constructors.Find(constructor => constructor.Id == constructorId) != null &&
                _drivers.Find(driver => driver.Code == driverCode) != null)
            {
                Season season = _seasons.Find(season => season.Year == seasonYear);
                Constructor constructor = _constructors.Find(constructor => constructor.Id == constructorId);
                Driver driver = _drivers.Find(driver => driver.Code == driverCode);
                Crew crew = new Crew(constructor, driver, season);
                driver.Crews.Add(crew);
                constructor.Crews.Add(crew);
                season.Crews.Add(crew);
            }

            return result;
        }

        /// <summary>
        ///  add a new qualification if the data are OK
        ///  a crew has 3 tries 
        ///  you have to save the three times
        /// </summary>
        /// <param name="circuitName"></param>
        /// <param name="seasonYear"></param>
        /// <param name="driverCode"></param>
        /// <param name="time"></param>
        /// <returns>
        /// "Unknown circuit"      : if the circuit is not in the data
        /// "Unknown Season"      : if the Season is not in the data
        /// "no race"             : if there is no race on the circuit for this season
        /// "Unknown Driver"      : if the driver is not in the data
        /// "driver not in a crew for this season" : if the driver is not in a crew for the season 
        ///  "too many qualifying"     : if the three tries have been already saved
        /// </returns>

        public string AddQualifying(string circuitName, int seasonYear, string driverCode, TimeSpan time, TimeSpan qualifyingTime1,TimeSpan qualifyingTime2,TimeSpan qualifyingTime3)
        {
            string result = "Qualifying saved";

            if (_seasons.Find(season => season.Year == seasonYear) != null &&
                _circuits.Find(circuit => circuit.Name == circuitName) != null &&
                _drivers.Find(driver => driver.Code == driverCode) != null)
            {
                Season season = _seasons.Find(season => season.Year == seasonYear);
                Circuit circuit = _circuits.Find(circuit => circuit.Name == circuitName);
                Driver driver = _drivers.Find(driver => driver.Code == driverCode);
                Crew crew = driver.Crews.Find(c => c.Season == season);
                crew.Qualifyings.Add(new Qualifying(season.Races.Find(r => r.Circuit == circuit),  crew, time, qualifyingTime1, qualifyingTime2, qualifyingTime3));
            }

            return result;
        }

        /// <summary>
        /// calculate the positions
        /// </summary>
        /// <param name="circuitName"></param>
        /// <param name="seasonYear"></param>
        /// <returns></returns>
        public List<string> UpdateQualifyingPositions(string circuitName, int seasonYear)
        {

            List<string> drivers = new List<string>();




            return drivers;
        }

        private TimeSpan Min(Qualifying qualifying)
        {
            TimeSpan minimum = new TimeSpan(1, 0, 0, 0, 0);

            return minimum;
        }

        public string GeFirstDriverQualifications(string circuitName, int seasonYear)
        {
            string result = "XXX";



            return result;
        }


        /// <summary>
        /// add new Result WITHOUT TESTS
        /// </summary>
        /// <param name="circuitName"></param>
        /// <param name="seasonYear"></param>
        /// <param name="driverCode"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public string AddResult(string circuitName, int seasonYear, string driverCode, TimeSpan time, string status)
        {
            string result = "Result saved";
            Circuit circuit = _circuits.Find(circuit => circuit.Name == circuitName);
            Season season = _seasons.Find(season => season.Year == seasonYear);
            Driver driver = _drivers.Find(d => d.Code == driverCode);
            Crew crew = driver.Crews.Find(c => c.Season == season);
            Race race = season.Races.Find(r => r.Circuit == circuit);
            Status statut = _status.Find(s => s.Description == status);
            Result resultRace = new Result(race, crew, time, statut);
            return result;
        }


        /// <summary>
        /// get Driver who wins  WITHOUT TESTS
        /// </summary>
        /// <param name="circuitName"></param>
        /// <param name="seasonYear"></param>
        /// <returns></returns>
        public string GeFirstDriverResults(string circuitName, int seasonYear)
        {
            string result = "XXX";
            Circuit circuit = _circuits.Find(circuit => circuit.Name == circuitName);
            Season season = _seasons.Find(season => season.Year == seasonYear);
            Race race = season.Races.Find(r => r.Circuit == circuit);
            Result resultRace = race.Results.Find(r => r.Position == 1);
            result = resultRace.Crew.Driver.Code;
            return result;
        }


        // Total points Season , constructor

        // total point season , driver







    }
}
