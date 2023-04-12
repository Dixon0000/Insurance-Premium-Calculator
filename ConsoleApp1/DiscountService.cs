using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoftwareCode
{
    public class DiscountService : IDiscountService
    {
        public double GetDiscount()
        {
            // Implement your discount logic here
            return 0.9; // For example, a 10% discount
        }
    }
}
