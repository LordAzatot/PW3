using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    interface IReproducible
    {
        void Reproduce();
    }

    interface IPredator
    {
        void Hunt(LivingOrganism prey);
    }

    class LivingOrganism
    {
        public int Energy { get; set; }
        public int Age { get; set; }
        public double Size { get; set; }

        public LivingOrganism(int energy, int age, double size)
        {
            Energy = energy;
            Age = age;
            Size = size;
        }
    }

    class Animal : LivingOrganism, IReproducible, IPredator
    {
        public string Species { get; set; }

        public Animal(int energy, int age, double size, string species) : base(energy, age, size)
        {
            Species = species;
        }

        public void Reproduce()
        {
            Console.WriteLine($"{Species} розмножується.");
        }

        public void Hunt(LivingOrganism prey)
        {
            Console.WriteLine($"{Species} полює на організм розміром {prey.Size}.");
            Energy += 10;
        }
    }

    class Plant : LivingOrganism, IReproducible
    {
        public bool IsFlowering { get; set; }

        public Plant(int energy, int age, double size, bool isFlowering) : base(energy, age, size)
        {
            IsFlowering = isFlowering;
        }

        public void Reproduce()
        {
            Console.WriteLine($"Рослина {(IsFlowering ? "цвіте" : "не цвіте")} і розмножується.");
        }
    }

    class Microorganism : LivingOrganism
    {
        public Microorganism(int energy, int age, double size) : base(energy, age, size) { }
    }

    class Ecosystem
    {
        private List<LivingOrganism> organisms = new();

        public void AddOrganism(LivingOrganism organism)
        {
            organisms.Add(organism);
        }

        public void Simulate()
        {
            foreach (var organism in organisms)
            {
                Console.WriteLine($"Організм: енергія {organism.Energy}, вік {organism.Age}, розмір {organism.Size}.");
            }
        }
    }

    class Program1
    {
        static void Main()
        {
            var lion = new Animal(50, 5, 1.5, "Лев");
            var deer = new Animal(30, 2, 1.0, "Олень");
            var grass = new Plant(10, 1, 0.2, true);

            lion.Hunt(deer);
            grass.Reproduce();

            var ecosystem = new Ecosystem();
            ecosystem.AddOrganism(lion);
            ecosystem.AddOrganism(deer);
            ecosystem.AddOrganism(grass);
            ecosystem.Simulate();
        }
    }
}