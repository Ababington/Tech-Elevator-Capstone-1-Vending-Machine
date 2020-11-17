using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Transactions;
using System.Xml.Schema;

namespace Capstone.Classes
{
    public class Money
        // rearranged for legibility 
    {
        public decimal AllSales { get; set; }
        public decimal balance = 0M;
        public decimal Nickels { get { return .05M; } }
        public decimal Dimes { get { return .10M; } }
        public decimal Quarters { get { return .25M; } }
        public decimal Balance { get { return balance; } set { } }
        public string ChangeOut(decimal currentBalance)
        {
            if(currentBalance <0)
            {
                currentBalance = 0 - currentBalance;
            }

            decimal changeAmount = currentBalance;
            decimal numberOfNickles = 0;
            decimal numberOfDimes = 0;
            decimal numberOfQuarters = 0;

            while (changeAmount > 0)
            {
                if (changeAmount >= Quarters)
                {
                    numberOfQuarters = (int)(changeAmount / Quarters);
                    changeAmount -= numberOfQuarters * Quarters;
                }
                else if (changeAmount >= Dimes)
                {
                    numberOfDimes = (int)(changeAmount / Dimes);
                    changeAmount -= numberOfDimes * Dimes;
                }
                else if (changeAmount >= Nickels)
                {
                    numberOfNickles = (int)(changeAmount / Nickels);
                    changeAmount -= numberOfNickles * Nickels;
                }
            }
            balance = 0M;
            return $" You recieved {numberOfNickles} Nickles, {numberOfDimes} Dimes, and {numberOfQuarters} Quarters in Change";
        }
        public decimal FeedMoney(decimal newMoney)
        {
            if (newMoney <= 0) { newMoney = 0 - newMoney; }

            balance += newMoney;
            
            return Balance;
            
        }
        
    }
}

//AllSales += newMoney;
//  01/01/2016 12:00:00 PM FEED MONEY: $5.00 $5.00
//  01/01/2016 12:00:15 PM FEED MONEY: $5.00 $10.00
//  01/01/2016 12:00:20 PM Crunchie B4 $10.00 $8.50
//  01/01/2016 12:01:25 PM Cowtales B2 $8.50 $7.50
//  01/01/2016 12:01:35 PM GIVE CHANGE: $7.50 $0.00
// just checking 
