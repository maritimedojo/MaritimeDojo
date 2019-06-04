using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class DateTimeExtensions
    {
        public static DateTime GetPreviousDayOfWeek(this DateTime date, DayOfWeek dayOfWeek)
        {
            // TODO
            // Implement GetPreviousDayOfWeek extension method:
            // (idea is to get the previous date from a given date and day of week) 
            // Examples:-
            // - If date = Tuesday 4th June, and dayOfWeek is DayOfWeek.Monday then the result returned should be Monday 3rd June
            // - If date = Tuesday 4th June, and dayOfWeek is DayOfWeek.Wednesday then the result returned should be Wednesday 29th May
            // - If date = Tuesday 4th June, and dayOfWeek is DayOfWeek.Tuesday then the result returned should be Tuesday 28th May

            throw new NotImplementedException();
        }

        public static DateTime GetNextDayOfWeek(this DateTime date, DayOfWeek dayOfWeek)
        {
            // TODO
            // Implement GetNextDayOfWeek extension method:
            // (idea is to get the next date from a given date and day of week) 
            // Examples:-
            // - If date = Tuesday 4th June, and dayOfWeek is DayOfWeek.Monday then the result returned should be Monday 10th June
            // - If date = Tuesday 4th June, and dayOfWeek is DayOfWeek.Wednesday then the result returned should be Wednesday 5th June
            // - If date = Tuesday 4th June, and dayOfWeek is DayOfWeek.Tuesday then the result returned should be Tuesday 11th June

            // TODO: Implement logic HERE
            throw new NotImplementedException();
        }
    }
}
