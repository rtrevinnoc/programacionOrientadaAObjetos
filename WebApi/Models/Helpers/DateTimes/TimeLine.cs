using System;
using System.Globalization;
using System.Linq;

namespace WebApi.Models.Helpers.DateTimes
{
    public class TimeLine
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public TimeLine()
        {
            
        }

        public TimeLine(string startDate , string endDate)
        {
            
            if (String.IsNullOrEmpty(startDate) ||  
                startDate.Length != 12 || 
                startDate.Any(char.IsLetter))
                StartDate = null;
            else
                StartDate = DateTime.ParseExact(startDate, "yyyyMMddHHmm",CultureInfo.InvariantCulture);
            
            
            if (String.IsNullOrEmpty(endDate) ||  
                endDate.Length != 12 || 
                endDate.Any(char.IsLetter))
                EndDate = null;
            else       
                EndDate = DateTime.ParseExact(endDate, "yyyyMMddHHmm",CultureInfo.InvariantCulture);
        }
    }
}