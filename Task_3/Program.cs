using Connectors;
using ExchangeBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {

            CryptoCompareConnector connector = new CryptoCompareConnector();
            try
            {
                Pair BTCUSD = connector.GetCurrencyPair(Currency.BTC, Currency.USD);
                Pair ETHUSD = connector.GetCurrencyPair(Currency.ETH, Currency.USD);
                Pair DASHUSD = connector.GetCurrencyPair(Currency.DASH, Currency.USD);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(BTCUSD);
                Console.WriteLine(ETHUSD);
                Console.WriteLine(DASHUSD);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error:  {e.GetType()}");
                Console.WriteLine($"Error Message:  {e.Message}");
            }

        }
    }
}
