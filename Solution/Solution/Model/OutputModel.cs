using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Model
{
    class OutputModel
    {
        public string ErrorMessage { get; set; }
        public IEnumerable<KeyValuePair<int, int>> HolidayRightsPerYearList { get; set; }
    }
}
