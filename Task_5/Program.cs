using Connectors;
using ExchangeBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
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
                CreateHTMLFile(Path.Combine(path, "BTCUSD.html"), BTCUSD);      // we can use nameof(nameOfVariable) instead "BTHUSD.json" 
                CreateHTMLFile(Path.Combine(path, "ETHUSD.html"), ETHUSD);
                CreateHTMLFile(Path.Combine(path, "DASHUSD.html"), DASHUSD);

                (new List<Pair>() { BTCUSD, ETHUSD, DASHUSD }).SaveAsHtmlFile(Path.Combine(path,"ALL.html"));

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

        private static void CreateHTMLFile(string path, Pair pair)
        {
            pair.SaveAsHtmlFile(path);

            Console.WriteLine("File {0} was created!", path);
        }
    }
}
