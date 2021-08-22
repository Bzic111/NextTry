using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextTry.Class
{
    public class Invoice
    {
        public int Id { get; set; }
        public decimal HourCost { get; set; }
        public List<int> Tasks { get; set; }
        public int EmployerId { get; set; }
        public int ContractId { get; set; }
        public bool IsClosed { get; set; }
    }
}
