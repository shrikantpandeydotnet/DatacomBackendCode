using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class PaymentCalc
    {

        public string EmployeeMonthlyPaySlip(string input)
        {
            StringBuilder output = new StringBuilder();
            var inputValues = input.Split(",");

           output.Append(string.Concat(inputValues[0], " ", inputValues[1], ","));


            // Get last day of month for Pay Period. 
            var lastDayOfMonth = TaxHelper.LastDayOfMonth(inputValues[4]);

            output.Append(string.Concat("01 ", inputValues[4], " - ", lastDayOfMonth, " ", inputValues[4], ","));

            var annualSalary = Convert.ToDouble(inputValues[2]);

            // Get Gross Income
            var grossIncome = (annualSalary / 12);

            // Calculate Income Tax.
            var incomeTax = TaxHelper.CalculateIncomeTax(annualSalary);

            var netIncome =  grossIncome - incomeTax;

            // Calculate Super and remove last character from string to remove "%" character.
            var super = grossIncome * Convert.ToInt32(inputValues[3].Remove(inputValues[3].Length - 1, 1));

            output.Append(String.Concat(grossIncome.ToString("F"), ","));
            output.Append(String.Concat(incomeTax.ToString("F"), ","));
            output.Append(String.Concat(netIncome.ToString("F"), ","));
            output.Append(super.ToString("F"));

            return output.ToString();
        }
    }
}
