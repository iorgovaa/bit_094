using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz
{
    class Car
    {
        public string CarMake;
        public int CarWeight;
        public int HorsePower;
        public int Boost;
        public float V1;
        public float V2;

        public Car(string carMake, int carWeight, int horsePower, int boost)
        {
            CarMake = carMake;
            CarWeight = carWeight;
            HorsePower = horsePower;
            Boost = boost;
            if (Boost == 100)
            {
                V1 = (((1 / (float)HorsePower) * 1000) / 2) * 0.7f; // 0-100km + Boost
                V2 = ((1 / (float)HorsePower * 1000)); // 100-200km
            }
            else if (Boost == 200)
            {
                V1 = (((1 / (float)HorsePower) * 1000) / 2); // 0-100km
                V2 = ((1 / (float)HorsePower * 1000)) * 0.8f; // 100-200km + Boost
            }


        }
    }
    class Racer
    {
        public string FirstName;
        public string LastName;
        public Car Car;
        public int score = 0;

        public Racer(string firstName, string lastName, Car car)
        {
            FirstName = firstName;
            LastName = lastName;
            Car = car;
        }
    }
    class Race
    {
        public List<Racer> recers = new List<Racer>();
        public void Start()
        {


            for (int i = 0; i < recers.Count; i++)
            {
                var current = recers[i];

                for (int j = i+1; j < recers.Count; j++)
                {
                    var winner = checkWinner(current, recers[j], 'A');
                    System.Console.WriteLine("winner: " + recers[j].FirstName);
                    winner.score += 3;
                }

            }

            for (int i = 0; i < recers.Count; i++)
            {
                var current = recers[i];

                for (int j = i+1; j < recers.Count; j++)
                {
                    var winner = checkWinner(current, recers[j], 'B');
                    System.Console.WriteLine("winner: " + recers[j].FirstName);
                    winner.score += 3;
                }

            }
        }

        public Racer checkWinner(Racer r1, Racer r2, char trace)
        {
            if (trace == 'A')
            {
                if (r1.Car.V1 > r2.Car.V1)
                    return r1;
                else
                    return r2;
            }
            else
            {
                if ((r1.Car.V1 + r1.Car.V2) < (r2.Car.V1 + r2.Car.V2))
                    return r1;
                else
                    return r2;
            }
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Racer> persons = new List<Racer>();

            for (int i = 0; i < 3; i++)
            {
                Console.Write("Въведете името на лицето:");
                string firstName = Convert.ToString(Console.ReadLine());
                Console.Write("Въведете фамилно име на лицето:");
                string LastName = Convert.ToString(Console.ReadLine());
                Console.Write("Въведете марка автомобил на лицето:");


                string carMake = Convert.ToString(Console.ReadLine());
                Console.Write("Въведете тегло на машината:");
                int carWeight = Convert.ToInt32(Console.ReadLine());
                Console.Write("Въведете конски сили за автомобил:");
                int carHourse = Convert.ToInt32(Console.ReadLine());
                Console.Write("Какъв ще бъде буст? :");
                int carBoost = Convert.ToInt32(Console.ReadLine());

                Car Car = new Car(carMake, carWeight, carHourse, carBoost);
                Racer person = new Racer(firstName, LastName, Car);
                persons.Add(person);
            }

            foreach (var p in persons)
            {
                Console.WriteLine(p.FirstName + " " + p.LastName + " " + p.Car.CarMake + " " + p.Car.CarWeight + " " + p.Car.HorsePower + " " + p.Car.V1 + " " + p.Car.V2);
            }

            Race race = new Race();
            race.Start();

            foreach (var p in persons)
            {
                Console.WriteLine(p.FirstName + " " + p.score);
            }






            Console.ReadLine();
        }
    }
}
