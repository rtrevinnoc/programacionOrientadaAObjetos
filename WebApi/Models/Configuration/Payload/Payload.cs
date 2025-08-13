using System;

namespace WebApi.Models.Configuration.Payload
{
    public class Payload
    {
        public string Message { get; }
        
        public Code Code { get; }
        
        public string Type { get; }

        
        public Payload(string message,Code code)
        {
            Message = message;
            Code = code;
            Type = Enum.GetName(typeof(Code),code);
        }
        
    }
    
}