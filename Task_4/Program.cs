using Connectors;
using ExchangeBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
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


                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                CreateJsonFile(Path.Combine(path, "BTCUSD.json"), BTCUSD);      // we can use nameof(nameOfVariable) instead "BTHUSD.json" 
                CreateJsonFile(Path.Combine(path, "ETHUSD.json"), ETHUSD);
                CreateJsonFile(Path.Combine(path, "DASHUSD.json"), DASHUSD);

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("All done");

                Console.ForegroundColor = ConsoleColor.Gray;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error:  {e.GetType()}");
                Console.WriteLine($"Error Message:  {e.Message}");
            }

        }

        private static void CreateJsonFile(string path, Pair pair)
        {
            pair.SaveAsJsonFile(path);

            Console.WriteLine("File {0} was created!", path);
        }
    }
}
