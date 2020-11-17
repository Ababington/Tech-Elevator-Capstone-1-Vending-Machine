using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Capstone
{
    public class Product 
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string SuggestedLocation { get; private set; } 
        public string Type { get; private set; }
        public int Amount { get; set; } = 5;

        /// <summary>
        /// Constructor to set the Name, Price, Type, and Suggested Location properties of the Product. 
        /// </summary>
       
        public Product(string name, decimal price, string location,string type )
        {
            Name = name;
            Price = price;
            SuggestedLocation = location;
            Type = type; 
        }
    }
}
