using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApi.Models.Helpers.Http
{
    public class HttpRestService
    {
        public Uri Url { get; set; }

        public HttpMethod HttpMethod { get; set; }

        #region Constructors

        public HttpRestService(string uri,HttpMethod httpMethod)
        {
            Url=new Uri(uri);
            HttpMethod = httpMethod;
        }

        #endregion Constructors
        
        #region Methods
        
        #region Methods Restful 
        
        public async Task<HttpResponseMessage> SendAsync(List<KeyValuePair<string, string>> content)
        {
            var request = new HttpRequestMessage(HttpMethod, Url)
            {
                Content = new FormUrlEncodedContent(content) 
            };
            var client = new HttpClient();

            return await client.SendAsync(request);
        }
        
        public async Task<HttpResponseMessage> SendAsync(List<KeyValuePair<string, object>> keyValuePairs)
        {
            var content = ConvertValuePair(keyValuePairs);

            return await SendAsync(content);
        }
        
        public async Task<HttpResponseMessage> SendAsync(object contentInformation)
        {
            var content = ConvertValuePair(contentInformation);
            
            return await SendAsync(content);

        }

      

        #endregion

        #region Helpers 

        private List<KeyValuePair<string,string>> ConvertValuePair(List<KeyValuePair<string, object>> keyValuePairs)
        {
            var convertedKeyValueList = new List<KeyValuePair<string, string>>();
            
            foreach (var valuePair in keyValuePairs)
            {
                var convertedValuePair = new KeyValuePair<string,string>(valuePair.Key,valuePair.Value.ToString());
                convertedKeyValueList.Add(convertedValuePair);
            }

            return convertedKeyValueList;
        }
        
        private List<KeyValuePair<string, string>> ConvertValuePair(object keyValuePairs)
        {
            return new List<KeyValuePair<string, string>>();
        }

        #endregion
        
        #endregion Methods  

        

        
        
    }
}