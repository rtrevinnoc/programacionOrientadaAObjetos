using System;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace WebApi.Models.Helpers.Http
{
    public class HttpBasicAuth
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public HttpBasicAuth(HttpContext httpContext)
        {
           var request = httpContext.Request.Headers["Authorization"];
           var authHeaderVal = AuthenticationHeaderValue.Parse(request);

           var encoding = Encoding.GetEncoding("iso-8859-1");
           var credentials = encoding.GetString(Convert.FromBase64String(authHeaderVal.Parameter));

           var separator = credentials.IndexOf(':');
           UserName = credentials.Substring(0, separator);
           Password = credentials.Substring(separator + 1);
        }
    }
}