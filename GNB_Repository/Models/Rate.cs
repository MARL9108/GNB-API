using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB_Repository.Models
{
    public class Rate
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal RateValue { get; set; }
    }
}
