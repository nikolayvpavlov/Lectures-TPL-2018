using System;
using System.Threading;

namespace A.BarSimulator
{
    class Customer
    {
        const int sleepInterval = 500;

        private static Random rand = new Random();

        public string Name { get; private set; }

        public Bar Bar { get; private set; }

        public bool InTheBar { get; set; }

        private int GetRandomValue(int boundary)
        {
            lock (rand) return rand.Next(boundary);
        }

        public Customer(string name, Bar bar)
        {
            Name = name;
            Bar = bar;
        }

        private string ChooseDrink()
        {
            var options = Bar.DrinkTypes;
            int optionIndex = GetRandomValue(options.Count);
            return options[optionIndex]; 
        }

        public void Go()
        {
            while (true)
            {
                Thread.Sleep(sleepInterval);
                int action = GetRandomValue(3);
                if (InTheBar)
                {
                    switch(action)
                    {
                        case 0:
                            string desiredDrink;
                            do
                            {
                                desiredDrink = ChooseDrink();
                            }
                            while (!Bar.PlaceOrder(desiredDrink));
                            Console.WriteLine($"{Name} is drinking {desiredDrink}.");
                            break;
                        case 1:
                            Console.WriteLine($"{Name} is dancing.");
                            break;
                        case 2:
                            Console.WriteLine($"{Name} is leaving the bar.");
                            Bar.LeaveBar();
                            InTheBar = false;
                            break;
                        default:
                            throw new ArgumentOutOfRangeException("Customer action is invalid: " + action.ToString());
                    }
                }
                else
                {
                    switch(action)
                    {
                        case 0:
                            Console.WriteLine($"{Name} is going for a walk.");
                            break;
                        case 1:
                            Console.WriteLine($"{Name} is getting in the line for the bar.");
                            Bar.EnterBar();
                            Console.WriteLine($"{Name} just got in the bar.");
                            InTheBar = true;
                            break;
                        case 2:
                            Console.WriteLine($"{Name} is going home.");
                            return;
                        default:
                            throw new ArgumentOutOfRangeException("Invalid custom behavior: " + action.ToString());
                    }
                }
            }
        }
    }
}
