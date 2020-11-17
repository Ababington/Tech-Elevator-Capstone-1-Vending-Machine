using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Capstone.Classes
{
    public class ActionData
    {

        public string PurchaseDate { get; set; }
        public string Choice { get; set; }
        public decimal StartBalance { get; set; }
        public decimal EndBalance { get; set; }
        public string LogLine { get; set; }


        public ActionData(string name,string location, decimal startBalance, decimal endBalance)
        {
            Choice= $"{name}  {location}";
            StartBalance = startBalance;
            EndBalance = endBalance;
            PurchaseDate = DateTime.Now.ToString();
        }
        public ActionData( string action, decimal startBalance, decimal endBalance)
        {
            Choice = action;
            StartBalance = startBalance;
            EndBalance = endBalance;
            PurchaseDate = DateTime.Now.ToString();
        }
        public string PrepLogLine()
        {
            
            LogLine = $"{PurchaseDate} {Choice} {StartBalance:C2} {EndBalance:C2}";
            return LogLine;
        }
        

    }
}


