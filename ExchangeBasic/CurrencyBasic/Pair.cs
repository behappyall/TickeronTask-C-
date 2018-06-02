using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExchangeBasic
{
    public class Pair
    {
        public readonly string PairName;
        public readonly Currency BaseCurrency;
        public readonly Currency QuoteCurrency;

        public readonly string BaseCurrencySTR;
        public readonly string QuoteCurrencySTR;


        public Pair(Currency BaseCurrency, Currency QuoteCurrency, decimal Price)
        {
            this.BaseCurrencySTR = BaseCurrency.ToString();
            this.QuoteCurrencySTR = QuoteCurrency.ToString();

            this.BaseCurrency = BaseCurrency;
            this.QuoteCurrency = QuoteCurrency;

            this.Price = Price;
            PairName = $"{BaseCurrencySTR}/{QuoteCurrencySTR}";
        }

        public Pair(string BaseCurrencySTR, string QuoteCurrencySTR, decimal Price)
        {
            this.BaseCurrencySTR = BaseCurrencySTR;
            this.QuoteCurrencySTR = QuoteCurrencySTR;

            Enum.TryParse(BaseCurrencySTR, true, out this.BaseCurrency);
            Enum.TryParse(QuoteCurrencySTR, true, out this.QuoteCurrency);

            this.Price = Price;
            PairName =  $"{BaseCurrencySTR}/{QuoteCurrencySTR}";
        }


        public bool IsImplementedPair()
        {
            return BaseCurrency != Currency.Null && QuoteCurrency != Currency.Null;
        }

        public decimal Price { get; set; }

        public override string ToString() => $"{PairName,-30}{Price}";

        
        public void SaveAsJsonFile(string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(this));
        }

        public void SaveAsHtmlFile(string path)
        {
            File.WriteAllText(path, this.ToStringHtml());
        }
        public string ToStringHtml()
        {
            string tabs = String.Concat(Enumerable.Repeat("&emsp;", 4));
            return $"<li>{this.PairName}{tabs}{this.Price}</li>";
        }
    }
    public static class ListPairExtension
    {
        public static void SaveAsHtmlFile(this IList<Pair> pairs, string path)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("<ul>");
            foreach (var pair in pairs)
                builder.AppendLine(pair.ToStringHtml());
            builder.AppendLine("</ul>");
            File.WriteAllText(path, builder.ToString());
        }
        public static void SaveAsJsonFile(this IList<Pair> pairs, string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(pairs));
        }
    }

}
