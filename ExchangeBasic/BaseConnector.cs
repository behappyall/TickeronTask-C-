using Newtonsoft.Json.Linq;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeBasic
{
    public abstract class BaseConnector
    {
        readonly string ApiBaseUrl;

        protected BaseConnector(string ApiBaseUrl)
        {
            this.ApiBaseUrl = ApiBaseUrl;
        }


        protected  JToken GetBaseResponse(string url)
        {
            var client = new RestClient(ApiBaseUrl);
            var request = new RestRequest(url);
            IRestResponse response = client.Execute(request);
            return JToken.Parse(response.Content);
            
        }
        protected  Task<JToken> GetBaseResponseAsync(string url)
        {
            return Task.Run(() => GetBaseResponse(url));
        }


        public abstract List<Pair> GetCurrencyPairsExample();

        public abstract Pair GetCurrencyPair(Currency BaseCurrency, Currency QuoteCurrency);


        public abstract Pair GetCurrencyPair(string BaseCurrency, string QuoteCurrency);


    }
}