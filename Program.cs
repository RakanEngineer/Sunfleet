using System.Threading;
using static System.Console;

namespace Sunfleet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool shouldNotExit = true;
            Car[] cars = new Car[100];
            int carCounter = 0;

            while (shouldNotExit)
            {
                Clear();

                WriteLine("1. Add car");
                WriteLine("2. List cars");
                WriteLine("3. Charge car");
                WriteLine("4. Exit");

                ConsoleKeyInfo keyPressed = ReadKey(true);

                Clear();

                switch (keyPressed.Key)
                {
                    case ConsoleKey.D1:

                        Write("Registration number: ");

                        string registrationNumber = ReadLine();

                        Write("Brand: ");

                        string brand = ReadLine();

                        Write("Model: ");

                        string model = ReadLine();

                        Write("Car type: ");

                        string carType = ReadLine();

                        cars[carCounter++] = new Car(registrationNumber, brand, model, carType);

                        Clear();

                        WriteLine("Car added");

                        Thread.Sleep(2000);

                        break;

                    case ConsoleKey.D2:

                        WriteLine("Registration number      Type              Is Charged?");
                        WriteLine("------------------------------------------------------");

                        foreach (var theCar in cars)
                        {
                            if (theCar == null) continue;

                            Write(theCar.registrationNumber);

                            Write(theCar.carType);

                            if (theCar.isCharged)
                            {
                                Write("Yes");
                            }
                            else
                            {
                                Write("No");
                            }

                            WriteLine();
                        }


                        WriteLine("<Press any key to continue");

                        ReadKey();

                        break;

                    case ConsoleKey.D3:

                        Write("Registration number: ");

                        string regNumber = ReadLine();

                        Clear();

                        Car car = null;

                        for (int i = 0; i < cars.Length; i++)
                        {
                            if (cars[i] != null && cars[i].registrationNumber == regNumber)
                            {
                                car = cars[i];
                                break;
                            }
                        }

                        if (car != null)
                        {
                            car.isCharged = true;

                            WriteLine("Car charged");
                        }
                        else
                        {
                            WriteLine("Car not found");
                        }

                        Thread.Sleep(2000);

                        break;

                    case ConsoleKey.D4:

                        shouldNotExit = false;

                        break;

                }

            }


        }


        class Car
        {
            public string registrationNumber;
            public string brand;
            public string model;
            public string carType;
            public bool isCharged;
            public short velocity;
            public Car(string registrationNumber, string brand, string model, string carType)
            {
                this.registrationNumber = registrationNumber;
                this.brand = brand;
                this.model = model;
                this.carType = carType;
            }
        }
    }
}