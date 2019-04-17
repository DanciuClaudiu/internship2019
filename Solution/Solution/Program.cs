using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solution.Logic;
using Solution.Model;
using Newtonsoft.Json;

namespace Solution
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(Environment.CurrentDirectory, @"..\..\", "input.json");
            InputModel inputModel = JsonHandler<InputModel>.ReadJson(path);

            // Calculates how many days were suspende per year
            var suspendedDaysPerYear = LogicHandler.GetSuspendedDaysPerYear(inputModel.SuspensionPeriodList);

            foreach (var period in suspendedDaysPerYear)
            {
                Console.WriteLine($"{period.Key} -> {period.Value} days");
            }
            var holidayDaysPerYear = LogicHandler.GetDaysOffPerYear(suspendedDaysPerYear, inputModel.EmploymentStartDate.Year);

            foreach (var period in holidayDaysPerYear)
            {
                Console.WriteLine($"{period.Key} -> {period.Value} days");
            }

            var outputModel = new OutputModel
            {
                ErrorMessage = "No Error!",
                HolidayRightsPerYearList = holidayDaysPerYear
            };

            JsonHandler<OutputModel>.WriteJson(path, outputModel);

            Console.Read();
        }
    }
}
