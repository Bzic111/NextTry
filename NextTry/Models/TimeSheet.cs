using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextTry.Class
{
    public class TimeSheet
    {
        public int Id { get; set; }
        public int EmployerId { get; set; }
        public string Title { get; set; }
        public int TotalHours { get; set; }
    }
}
