using System;
using System.Collections.Generic;
using System.Threading;

namespace A.BarSimulator
{
    class Bar
    {
        private Semaphore semaphore;
        private string[] drinkTypes = new string[] { "rakiya", "whiskey", "beer" };
        private const string unlimitedDrinkType = "beer";

        private object drinkOrderLock = new object();

        private Dictionary<string, int> inventory;

        public List<string> Orders { get; private set; }

        public IReadOnlyList<string> DrinkTypes
        {
            get { return drinkTypes; }
        }

        public Bar(int seats = 10)
        {
            semaphore = new Semaphore(seats, seats);
            inventory = new Dictionary<string, int>();
            Orders = new List<string>();
        }

        public void InitInventory(int initialInventory = 30)
        {
            foreach (var d in DrinkTypes)
            {
                inventory.Add(d, initialInventory);
            }
            inventory[unlimitedDrinkType] = int.MaxValue;
        }

        public void EnterBar()
        {
            semaphore.WaitOne();
        }

        public void LeaveBar()
        {
            semaphore.Release();
        }

        public bool PlaceOrder(string drinkType)
        {
            lock (drinkOrderLock)
            {
                if (inventory[drinkType] > 0)
                {
                    inventory[drinkType]--;
                    Orders.Add(drinkType);
                    return true;
                }
                else return false;
            }
        }
    }
}
