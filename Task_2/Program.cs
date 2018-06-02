using Connectors;
using ExchangeBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {

            CryptoCompareConnector connector = new CryptoCompareConnector();
            try
            {
                ShowImplementedCurrence();
                
                string BaseCurrencySTR = EnterStringWithRemark("Enter Base Currency:\t");
                
                string QuoteCurrencySTR = EnterStringWithRemark("Enter Quote Currency:\t");


                CheckOnNullArgument(BaseCurrencySTR, QuoteCurrencySTR);

                Pair pair = connector.GetCurrencyPair(BaseCurrencySTR, QuoteCurrencySTR);
                Console.WriteLine(pair);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error:  {e.GetType()}");
                Console.WriteLine($"Error Message:  {e.Message}");
            }

        }
        
        private static void ShowImplementedCurrence()
        {

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Implemented Currencies");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Enum.GetNames(typeof(Currency)).ToList().ForEach(c => Console.Write(c + "\t"));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You can use all Currencies that is available on www.cryptocompare.com.");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private static string EnterStringWithRemark(string remark)
        {
            Console.Write(remark);
            return Console.ReadLine();
        }

        private static void CheckOnNullArgument(string BaseCurrencySTR, string QuoteCurrencySTR)
        {
            if (String.IsNullOrEmpty(BaseCurrencySTR) || String.IsNullOrEmpty(QuoteCurrencySTR))
                throw new ArgumentNullException("BaseCurrencySTR || QuoteCurrencySTR", "You entered empty currency string!");
        }
    }
}
