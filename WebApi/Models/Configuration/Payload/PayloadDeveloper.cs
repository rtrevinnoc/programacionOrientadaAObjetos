namespace WebApi.Models.Configuration.Payload
{
    public class PayloadDeveloper : Payload
    {
        public string InternalMessage { get; set; }


        public PayloadDeveloper(string error, Code code,string internalError) : 
            base(error, code)
        {
            InternalMessage = internalError;
        }
    }
}