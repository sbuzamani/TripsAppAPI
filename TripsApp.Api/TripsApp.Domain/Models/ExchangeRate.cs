using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripsApp.Domain.Models
{
    public class ExchangeRate
    {
        public int CountryId { get; set; }

        public decimal Rate { get; set; }

        public string Currency { get; set; }
    }
}
