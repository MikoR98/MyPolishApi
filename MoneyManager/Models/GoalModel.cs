using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
    public class GoalModel
    {
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
