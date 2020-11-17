using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine
    {

        public List<Product> Inventory = new List<Product>();// list of all products in vending machine after stocking
        private List<ActionData> SalesAudit = new List<ActionData>();


        public Money money = new Money();// tell the vending machine what money is
        public Logger logger = new Logger();

        public int Amount { get; private set; } = 5;

        // Begin talking to the user --jh
        public void UI()
        {
            Approach();
            Console.WriteLine();
            Menu();
            WalkAway();
        }

        // All of the menus live here --jh
        public void Menu()
        {

            bool shouldContinue = false;
            do
            {

                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(3) Exit");
                Console.WriteLine();
                // prompt user for choice
                Console.Write(" Your choice:  ");
                ConsoleKeyInfo userinput1 = Console.ReadKey();
                Console.WriteLine();

                // depending on the users choice
                if (userinput1.KeyChar == '1')
                {// provide a list of items 
                    
                    InventoryWriter();
                    shouldContinue = true;
                }
                else if (userinput1.KeyChar == '2')
                {// allow user to make feed money, make purchases, and get back change.

                    bool choseOneOfTheChoices = false;// need this for later

                    ConsoleKeyInfo userinput2 = new ConsoleKeyInfo();
                    do
                    {
                        // prompt user with options -- jh
                        
                        Console.WriteLine("(1) Feed Money");
                        Console.WriteLine("(2) Select Product");
                        Console.WriteLine("(3) Finish Transaction");
                        Console.WriteLine();

                        // let them know if another user left money in the vending machine.. should never be the case but IRL might be. --jh
                        Console.WriteLine($"Current Money Provided: {money.Balance:C2}");
                        // submenu for transactions
                        try
                        {
                            // prompt user for input
                            Console.WriteLine();
                            Console.Write(" Your choice:  ");
                            userinput2 = Console.ReadKey();
                            Console.WriteLine();
                            // depending on the user choice 
                            if (userinput2.KeyChar == '1')
                            {
                                // they want to feed money into the system 
                                bool doneFeedingMoney = false;
                                ConsoleKeyInfo billsOrCoins = new ConsoleKeyInfo();
                                try
                                {
                                    do
                                    {
                                        
                                        Console.WriteLine("Press 1 for Bills");
                                        Console.WriteLine("Press 2 for Coins");
                                        Console.WriteLine("PRESS 3 TO RETURN TO THE PREVIOUS MENU");
                                        Console.WriteLine($"Current Money Provided: {money.Balance:C2}");
                                        Console.WriteLine();
                                        Console.Write(" Your Choice: ");
                                        billsOrCoins = Console.ReadKey();
                                        Console.WriteLine();
                                        if (billsOrCoins.KeyChar == '1')
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("Insert Bills ($1, $2, $5, $10, $20). Then press enter");
                                            Console.Write("  $");
                                            string userInput = Console.ReadLine();
                                            Console.WriteLine();
                                            decimal dollars = decimal.Parse(userInput);

                                            switch (userInput)
                                            {
                                                case "1":
                                                    money.FeedMoney(dollars);
                                                    break;
                                                case "2":
                                                    money.FeedMoney(dollars);
                                                    break;
                                                case "5":
                                                    money.FeedMoney(dollars);
                                                    break;
                                                case "10":
                                                    money.FeedMoney(dollars);
                                                    break;
                                                case "20":
                                                    money.FeedMoney(dollars);
                                                    break;

                                                default:
                                                    Console.WriteLine("Please insert valid dollar amount.");
                                                    Console.WriteLine();
                                                    break;
                                            }

                                            Console.WriteLine($"Current Money Provided: {money.Balance:C2}");
                                            Console.WriteLine();
                                            ActionData feedmoney = new ActionData("Feed Money: ", dollars, money.Balance);
                                            logger.WriteLogLine(feedmoney.PrepLogLine());
                                        }
                                        else if (billsOrCoins.KeyChar == '2')
                                        {
                                            Console.WriteLine();
                                            Console.WriteLine("Insert Coins (¢5, ¢10, ¢25). Then press enter");
                                            Console.Write("  ¢");
                                            string userInput = ($".{Console.ReadLine()}");
                                            if (userInput == ".5")
                                            {
                                                userInput = ".05";
                                            }
                                            Console.WriteLine();
                                            decimal dollars = decimal.Parse(userInput);
                                            switch (userInput)
                                            {
                                                case ".05":
                                                    money.FeedMoney(dollars);
                                                    break;
                                                case ".10":
                                                    money.FeedMoney(dollars);
                                                    break;
                                                case ".25":
                                                    money.FeedMoney(dollars);
                                                    break;
                                                default:
                                                    Console.WriteLine("Please insert valid Coin amount.");
                                                    Console.WriteLine();// space for legibility --ab
                                                    break;
                                            }
                                            Console.WriteLine($"Current Money Provided: {money.Balance:C2}"); Console.WriteLine();
                                            ActionData feedmoney = new ActionData("Feed Money: ", dollars, money.Balance);
                                            logger.WriteLogLine(feedmoney.PrepLogLine());
                                        }
                                        else if (billsOrCoins.KeyChar == '3')
                                        {
                                            doneFeedingMoney = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Sorry that is an invalid choice please choose again.");
                                            Console.WriteLine();// space for legibility --ab
                                        }
                                    } while (!doneFeedingMoney);


                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Please enter valid Currency amount.");
                                }
                                choseOneOfTheChoices = true;
                            }
                            else if (userinput2.KeyChar == '2')
                            {
                                Console.WriteLine();
                                InventoryWriter();
                                Searcher();

                                choseOneOfTheChoices = true;
                            }
                            else if (userinput2.KeyChar == '3')
                            {
                                Console.WriteLine();
                                decimal preChangeOutBalance = money.Balance;
                                Console.WriteLine(money.ChangeOut(money.Balance));
                                ActionData changeOut = new ActionData("Change Out: ", preChangeOutBalance, money.Balance);
                                logger.WriteLogLine(changeOut.PrepLogLine());
                                choseOneOfTheChoices = false;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Sorry that wasn't one of the choices. ");
                                choseOneOfTheChoices = true;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Sorry that was not one of the choices.");
                        }
                    } while (choseOneOfTheChoices);
                    Console.WriteLine();
                    shouldContinue = true;
                }
                else if (userinput1.KeyChar == '4')
                {// hidden fourth option to read a log of items sold 

                }
                else
                {// dont let them move on if they havent chosen a viable option
                    shouldContinue = false;
                }
            } while (shouldContinue);

        }

        // method to print out list of items and their availability --jh
        public void InventoryWriter()
        {
            Console.WriteLine();
            foreach (Product item in Inventory)
            {
                string amount = "";
                if (item.Amount == 0)
                {
                    amount = "SOLD OUT!!!";
                }
                else { amount = $"{item.Amount}"; }
                Console.WriteLine($"{item.SuggestedLocation} -- {item.Name} - Cost:{item.Price} - Remaining:{amount}");
            }
            Console.WriteLine();// space for legibility
        }

        // Handles greeting --jh
        public void Approach()
        {
            try
            {
                string directory = "C:\\Users\\Student\\workspace\\Capstone\\csharp-capstone-module-1-team-1";
                string fileName = "vending_macine_logo.txt";
                string filePath = Path.Combine(directory, fileName);
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("could not load logo");
            }
            //Console.WriteLine("Welcome to Umbrella Corp's Vendo-Matic 800.");
        }

        // handles good byes --jh
        public void WalkAway()
        {
            Console.WriteLine("Thank you for choosing the Vendo-Matic 800. Have a great day.");
        }

        // handles selection of item --jh
        public void Searcher()
        {
            bool foundAnItem = false;
            bool HaveMoney = true;
            do
            {
                // prompt user for selection--jh
                Console.WriteLine("Which item would you like? (Input location [i.e. A1, B2, C3, D4, ...])");
                Console.Write(" Your Choice: ");
                string userinput = Console.ReadLine().ToUpper();

                // look for their selection in inventory --jh
                 foreach (Product item in Inventory)
                {
                    // with user selection in mind  find item associated with reference --jh
                    if (userinput == item.SuggestedLocation)
                    {


                        // check first if user can purchase item --jh
                        if (money.balance < item.Price)
                        {

                            Console.WriteLine($"Current Balance: {money.Balance:C2} Item Cost: {item.Price} ");
                            Console.WriteLine("Sorry you do not have enough money for this item, please feed more or make a different selection.");
                            Console.WriteLine();
                            
                            HaveMoney = false;
                            break;
                        }
                        // check if item is available to purchase --jh
                        if (item.Amount == 0)
                        {
                            Console.WriteLine("Sorry we are all out of that prouct. Please choose a different product.");
                            Console.WriteLine();
                            HaveMoney = false;
                            break;
                        }
                        // if user has enough money and item is available to purchase .. complete transaction --jh
                        if (item.Amount > 0 && money.Balance > item.Price)
                        {
                            Console.Write($"{ item.Name} { item.Price:C2}");
                            item.Amount -= 1;
                            decimal prePurchaseBalance = money.balance;
                            money.balance -= item.Price;




                            ActionData purchase = new ActionData(item.Name, item.SuggestedLocation, prePurchaseBalance, money.Balance);
                            logger.WriteLogLine(purchase.PrepLogLine());



                            if (item.Type == "Drink")
                            {
                                Console.Write("  Glug Glug, Yum!"); Console.WriteLine();
                                foundAnItem = true;
                                break;
                            }
                            else if (item.Type == "Chip")
                            {
                                Console.WriteLine("  Crunch Crunch, Yum!"); Console.WriteLine();
                                foundAnItem = true;
                                break;
                            }
                            else if (item.Type == "Candy")
                            {
                                Console.WriteLine("  Munch Munch, Yum!"); Console.WriteLine();
                                foundAnItem = true;
                                break;
                            }
                            else if (item.Type == "Gum")
                            {
                                Console.WriteLine("  Chew Chew, Yum!"); Console.WriteLine();
                                foundAnItem = true;
                                break;
                            }
                            else { Console.WriteLine("Something went wrong "); }




                            money.balance -= item.Price;




                            Console.WriteLine("Remaining Balance " + money.Balance);
                        }

                    }
                    


                }
                //else
                //    {
                //        Console.WriteLine("Item doesn't exist. Please choose again.");
                        
                //    }
                if (!HaveMoney)// never found a valid option
                {
                    
                    break;
                }
                if ( foundAnItem == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid selection.");
                    Console.WriteLine();
                }

            } while (!foundAnItem);




        }
        public void StockerMethod()// will stock the vendign machine upon opening of the program --JM//
        {
            {
                string directory = Environment.CurrentDirectory;
                int indexOf = directory.LastIndexOf("Capstone");
                directory = directory.Substring(0, indexOf);
                string fileName = "vendingmachine.csv";
                string filePath = Path.Combine(directory, fileName);

                using ( StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {

                        string line = sr.ReadLine();
                        string[] data = line.Split('|', StringSplitOptions.RemoveEmptyEntries);
                        Product item = new Product(data[1], decimal.Parse(data[2]), data[0], data[3]);
                        Inventory.Add(item);
                    }
                }
            }
        }
        public void PurchaseOneItem(int amount)
        {
            //if (Amount > 0)
            //{
            //    Amount -= 1;
            //    money.Balance -= item.Price;
            //}
            //else if (Amount == 0)
            //{
            //    Console.WriteLine("Sorry we are all out of that prouct. Please choose a different product.");
            //}
        }

    }//End of class
}
