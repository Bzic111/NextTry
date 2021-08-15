using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextTry.Class
{
    public class Invoice
    {
        public int Id { get; set; }
        public int Cost { get; set; }
        public List<TimeSheet> ListOfTasks { get; set; }
    }
}
