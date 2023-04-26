using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB_Data.Request
{
    public class TransactionRequest
    {
        [Required(ErrorMessage = "Please select enter a valid Sku")]
        public string Sku { get; set; }
    }
}
