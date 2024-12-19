using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    interface IConnectable
    {
        void Connect(Computer other);
        void Disconnect(Computer other);
        void SendData(Computer receiver, string data);
    }

    class Computer
    {
        public string IpAddress { get; set; }
        public string OperatingSystem { get; set; }
        public int Power { get; set; }

        public Computer(string ipAddress, string operatingSystem, int power)
        {
            IpAddress = ipAddress;
            OperatingSystem = operatingSystem;
            Power = power;
        }
    }

    class Server : Computer
    {
        public Server(string ipAddress, string operatingSystem, int power) : base(ipAddress, operatingSystem, power) { }
    }

    class Workstation : Computer
    {
        public Workstation(string ipAddress, string operatingSystem, int power) : base(ipAddress, operatingSystem, power) { }
    }

    class Router : Computer, IConnectable
    {
        private List<Computer> connectedDevices = new();

        public Router(string ipAddress, string operatingSystem, int power) : base(ipAddress, operatingSystem, power) { }

        public void Connect(Computer other)
        {
            connectedDevices.Add(other);
            Console.WriteLine($"Пристрій з IP {other.IpAddress} підключений до маршрутизатора {IpAddress}.");
        }

        public void Disconnect(Computer other)
        {
            connectedDevices.Remove(other);
            Console.WriteLine($"Пристрій з IP {other.IpAddress} відключений від маршрутизатора {IpAddress}.");
        }

        public void SendData(Computer receiver, string data)
        {
            if (connectedDevices.Contains(receiver))
            {
                Console.WriteLine($"Дані \"{data}\" передано на {receiver.IpAddress}.");
            }
            else
            {
                Console.WriteLine($"Неможливо передати дані на {receiver.IpAddress}: пристрій не підключено.");
            }
        }
    }

    class Program2
    {
        static void Main()
        {
            var server = new Server("192.168.1.1", "Linux", 1000);
            var workstation = new Workstation("192.168.1.2", "Windows", 500);
            var router = new Router("192.168.1.254", "Embedded OS", 300);

            router.Connect(server);
            router.Connect(workstation);

            router.SendData(server, "Hello Server!");
            router.SendData(workstation, "Hello Workstation!");
            router.Disconnect(server);
            router.SendData(server, "Are you there?");
        }
    }
}
