using MySoftwareCode;
using System;

class Program
{
    static void Main(string[] args)
    {
        IDiscountService discountService = new DiscountService();
        InsuranceService insuranceService = new InsuranceService(discountService);

        double premium = insuranceService.CalcPremium(25, "rural");
        Console.WriteLine($"Premium: {premium}");
    }
}
