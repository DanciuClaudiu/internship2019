using Solution.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Logic
{
    public class LogicHandler
    {
        public static Dictionary<int, int> GetSuspendedDaysPerYear(IEnumerable<DateRange> suspensionPeriodList)
        {
            var suspendedDaysPerYear = new Dictionary<int, int>();

            foreach (var period in suspensionPeriodList)
            {
                var periodYear = period.StartDate.Year;
                var suspendedTimeSpan = (period.EndDate - period.StartDate).Days + 1;
                if (suspendedDaysPerYear.ContainsKey(periodYear))
                {
                    suspendedDaysPerYear[periodYear] = suspendedDaysPerYear[periodYear] + suspendedTimeSpan;
                }
                else
                {
                    suspendedDaysPerYear.Add(periodYear, suspendedTimeSpan);
                }
            }
            return suspendedDaysPerYear;
        }
        public static IEnumerable<KeyValuePair<int, int>> GetDaysOffPerYear(Dictionary<int, int> suspensionPeriodList, int startYear)
        {
           return suspensionPeriodList.Select(p => new KeyValuePair<int, int>(p.Key,  CalculateDaysOffFromSuspendedDays(startYear, p.Key, p.Value)));
        }
        protected static int CalculateDaysOffFromSuspendedDays(int startYear, int currentYear, int suspendedDays)
        {
            var availableDaysOff = (currentYear - startYear) < 4 ? 20 + (currentYear-startYear) : 24;
            return ((365 - suspendedDays)*availableDaysOff)/365;
        }
    }
}
