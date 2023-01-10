using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rally
{
    public delegate void CarFinishEvent();
    internal class Program
    {
        static void Main(string[] args)
        {
            RaceCar Suba = new RaceCar("Impreza", 190);
            JustCar Mitsuba = new JustCar("Evolution", 170);
            SportCar Porshe = new SportCar("Cayene", 220);
            Race race = new Race(Suba, Mitsuba, Porshe, 1000);
            race.RaceGame();
        }
    }
    public abstract class Vehicle
    {
        public event CarFinishEvent CarFinish;
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public int TraveledDistance { get; set; }
        public abstract void Drive();
    }
    class RaceCar : Vehicle
    {
        public event CarFinishEvent CarFinish;
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public int TraveledDistance { get; set; }
        private Random rand;
        public RaceCar(string name, int maxspeed)
        {
            Name = Name;
            MaxSpeed = maxspeed;
            TraveledDistance = 0;
            rand = new Random();
        }
        public RaceCar()
        {
            Name = "AnyCar";
            MaxSpeed = 150;
            TraveledDistance = 0;
            rand = new Random();
        }
        public override void Drive()
        {
            int Move = rand.Next(1, MaxSpeed);
            TraveledDistance += Move;
            if (TraveledDistance >= Race._racedistance)
            {
                CarFinish();
            }
        }
        public override string ToString()
        {
            return Name.ToString();
        }
    }

    class JustCar : Vehicle
    {
        public event CarFinishEvent CarFinish;
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public int TraveledDistance { get; set; }
        private Random rand;
        public JustCar(string name, int maxspeed)
        {
            Name = Name;
            MaxSpeed = maxspeed;
            TraveledDistance = 0;
            rand = new Random();
        }
        public JustCar()
        {
            Name = "AnyCar";
            MaxSpeed = 150;
            TraveledDistance = 0;
            rand = new Random();
        }
        public override void Drive()
        {
            int Move = rand.Next(1, MaxSpeed);
            TraveledDistance += Move;
            if (TraveledDistance >= Race._racedistance)
            {
                CarFinish();
            }
        }
        public override string ToString()
        {
            return Name.ToString();
        }
    }
    class SportCar : Vehicle
    {
        public event CarFinishEvent CarFinish;
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public int TraveledDistance { get; set; }
        private Random rand;
        public SportCar(string name, int maxspeed)
        {
            Name = Name;
            MaxSpeed = maxspeed;
            TraveledDistance = 0;
            rand = new Random();
        }
        public SportCar()
        {
            Name = "AnyCar";
            MaxSpeed = 150;
            TraveledDistance = 0;
            rand = new Random();
        }
        public override void Drive()
        {
            int Move = rand.Next(1, MaxSpeed);
            TraveledDistance += Move;
            if (TraveledDistance >= Race._racedistance)
            {
                CarFinish();
            }
        }
        public override string ToString()
        {
            return Name.ToString();
        }
    }

    class Race
    {
        RaceCar _racecar;
        JustCar _justcar;
        SportCar _sportcar;
        public static int _racedistance { get; set; }
        public Race()
        {
            _racecar = new RaceCar() { Name = "AnyCar", MaxSpeed = 8 };
            _justcar = new JustCar() { Name = "AnyCar", MaxSpeed = 6 };
            _sportcar = new SportCar() { Name = "AnyCar", MaxSpeed = 10 };
            _racedistance = 100;
        }
        public Race(RaceCar racecar, JustCar justcar, SportCar sportcar, int racedistance)
        {
            _racecar = racecar;
            _justcar = justcar;
            _sportcar = sportcar;
            _racedistance = racedistance;
        }
        public void RaceGame()
        {
            _racecar.CarFinish += () =>
            {
                Console.WriteLine($"Субарик {_racecar.Name} доехал до финиша!");
            };
            _justcar.CarFinish += () =>
            {
                Console.WriteLine($"Митсуба {_justcar.Name} доехал до финиша!");
            };
            _sportcar.CarFinish += () =>
            {
                Console.WriteLine($"Порш {_sportcar.Name} доехал до финиша!");
            };
            int timecount = 1;
            Console.WriteLine("Time:\t\tСубарик{0}\t\t\tМитсуба{1}\t\t\tПорш{2}", _racecar.Name, _justcar.Name, _sportcar.Name);
            Console.WriteLine("===================================================================");
            while (true)
            {
                _racecar.Drive();
                _justcar.Drive();
                _sportcar.Drive();
                Console.WriteLine("{0}\t\t{1}км\t\t\t{2}км\t\t\t{3}км", timecount++, _racecar.TraveledDistance, _justcar.TraveledDistance, _sportcar.TraveledDistance);
                if (_racecar.TraveledDistance >= _racedistance || _justcar.TraveledDistance >= _racedistance || _sportcar.TraveledDistance >= _racedistance)
                {
                    break;
                }
            }
        }
    }
}
