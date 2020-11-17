using Capstone.Classes;
using System;
using System.Diagnostics;
using System.IO;

namespace Capstone
{
    public class Program
    {
        static void Main(string[] args)
        {
            



            VendingMachine vendomatic800 = new VendingMachine();
            vendomatic800.StockerMethod();
            vendomatic800.UI();





            
        }
    }
}
//// you open your eyes and see a vending machine in front of you 
//VendingMachine vendingMachine = new VendingMachine();

//// you decide to walk up to it 
//vendingMachine.Approach();

////the vending machine whirrs to life 
//UI ui = new UI();
//Console.WriteLine();// space for legibilty

////the vending machine begins speaking to you 
//ui.Menu();
//Console.WriteLine();// space for legibility

//// you have concluded your business with the vending machine it says good-bye.
//vendingMachine.WalkAway();
