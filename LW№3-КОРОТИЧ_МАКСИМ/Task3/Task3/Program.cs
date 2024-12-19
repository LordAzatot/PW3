using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    interface IDriveable
    {
        void Move();
        void Stop();
    }

    class Road
    {
        public double Length { get; set; }
        public int Lanes { get; set; }
        public double TrafficLevel { get; set; }

        public Road(double length, int lanes, double trafficLevel)
        {
            Length = length;
            Lanes = lanes;
            TrafficLevel = trafficLevel;
        }
    }

    class Vehicle : IDriveable
    {
        public double Speed { get; set; }
        public string Type { get; set; }

        public Vehicle(double speed, string type)
        {
            Speed = speed;
            Type = type;
        }

        public void Move()
        {
            Console.WriteLine($"{Type} рухається зі швидкістю {Speed} км/год.");
        }

        public void Stop()
        {
            Console.WriteLine($"{Type} зупинився.");
        }
    }

    class Simulation
    {
        public void SimulateTraffic(Vehicle vehicle, Road road)
        {
            Console.WriteLine($"Дорога довжиною {road.Length} км з {road.Lanes} смугами.");
            vehicle.Move();
            Console.WriteLine($"Рівень трафіку: {road.TrafficLevel * 100}%.");
            vehicle.Stop();
        }
    }

    class Program3
    {
        static void Main()
        {
            var road = new Road(10, 3, 0.5);
            var car = new Vehicle(60, "Автомобіль");

            var simulation = new Simulation();
            simulation.SimulateTraffic(car, road);
        }
    }
}