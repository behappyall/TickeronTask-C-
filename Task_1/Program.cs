using Connectors;
using ExchangeBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            CryptoCompareConnector connector = new CryptoCompareConnector();
            try
            {
                List<Pair> pairs = connector.GetCurrencyPairsExample();
                pairs.Where(p => p.BaseCurrency == Currency.BTC).ToList().ForEach(Console.WriteLine);
                //pairs.Where(p => p.BaseCurrencySTR == "BTC").ToList().ForEach(Console.WriteLine); // its works too.
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error:  {e.GetType()}\n");
                Console.WriteLine($"Error Message:  {e.Message}");
            }

           
        }
    }
}
