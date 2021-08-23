using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NextTry.Class
{
    public class Contract
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public bool Status { get; set; }
        public decimal FullCost { get; set; }
        public List<int> Invoices { get; set; }
    }
}
