using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Models.Helpers.Http
{
    public static class HttpHelper
    {
        
        /// <summary>
        /// Get ContentResult (IActionResult) status code with content in JSON
        /// </summary>
        /// <param name="content"></param>
        /// <param name="statusCode"></param>
        /// <returns>StatusCode with Content in JSON Format</returns>
        public static ContentResult ContentResult(object content,HttpStatusCode statusCode)
        {
            return new ContentResult()
            {
                Content = content.ToString(),
                StatusCode = (int?) statusCode,
                ContentType = "application/json"
            };
        }

        /// <summary>
        /// Get ContentResult (IActionResult) status code with content in JSON
        /// </summary>
        /// <param name="response"></param>
        /// <returns>StatusCode with Content in JSON Format</returns>
        public static ContentResult ContentResult(HttpResponseMessage response)
        {
            return new ContentResult()
            {
                Content = response.Content.ReadAsStringAsync().Result,
                StatusCode =  (int?) response.StatusCode,
                ContentType = "application/json"
            };
        }
        
    }
}