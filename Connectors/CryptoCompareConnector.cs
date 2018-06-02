using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using ExchangeBasic;

namespace Connectors
{
    public class CryptoCompareConnector : BaseConnector
    {

        const string CryptoCompareBaseUrl = @"https://min-api.cryptocompare.com/data/";

        const string CoinPriceUrl = @"pricemulti?fsyms=BTC,ETH,DASH&tsyms=USD,RPL";

        public CryptoCompareConnector()
            :base(CryptoCompareBaseUrl)
        {

        }

        public override List<Pair> GetCurrencyPairsExample() // just for task 1;
        {
            var resp = GetBaseResponse(CoinPriceUrl);
            List<Pair> pairs = new List<Pair>();

            foreach (var baseCurrency in JObject.FromObject(resp))
                foreach (var quoteCurrency in JObject.FromObject(baseCurrency.Value))
                    pairs.Add(new Pair(baseCurrency.Key, quoteCurrency.Key, quoteCurrency.Value.ToObject<decimal>()));


            return pairs;
        }
        

        public override Pair GetCurrencyPair(Currency BaseCurrency, Currency QuoteCurrency)
        {
            string url = $@"pricemulti?fsyms={BaseCurrency.ToString()}&tsyms={QuoteCurrency.ToString()}";
            var resp = GetBaseResponse(url);

            decimal price = resp.SelectToken($"{BaseCurrency.ToString()}.{QuoteCurrency.ToString()}", true).Value<decimal>();
            Pair pair = new Pair(BaseCurrency, QuoteCurrency, price);
            return pair;
        }

        public override Pair GetCurrencyPair(string BaseCurrency, string QuoteCurrency)
        {
            string url = $@"pricemulti?fsyms={BaseCurrency}&tsyms={QuoteCurrency}";
            var resp = GetBaseResponse(url);

            decimal price = resp.SelectToken($"{BaseCurrency}.{QuoteCurrency}", true).Value<decimal>();
            Pair pair = new Pair(BaseCurrency, QuoteCurrency, price);
            return pair;
        }
    }
}
