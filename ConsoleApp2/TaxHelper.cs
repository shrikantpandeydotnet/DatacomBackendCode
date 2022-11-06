using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class TaxHelper
    {
        public static double CalculateIncomeTax(double annualSalary)
        {
            var incomeTax = 0.0;
            var remainingSalary = annualSalary;
            int index = 0;
            var taxSlab = new List<Tuple<int, double>>() {
                                                            new Tuple<int, double>(14000, 10.5/100),
                                                            new Tuple<int, double>(48000, 17.5/100),
                                                            new Tuple<int, double>(70000, 30.0/100),
                                                            new Tuple<int, double>(180000, 33.0/100),
                                                            new Tuple<int, double>(int.MaxValue, 39.0/100),
                                                          };

            var previousSlab = 0.0;

            while ((remainingSalary >= taxSlab[index].Item1 || (remainingSalary < taxSlab[index].Item1 && (index == -1 || remainingSalary > taxSlab[index - 1].Item1))) && index < taxSlab.Count)
            {
                // Calculate Current taxable Slab.
                var currentSlab = remainingSalary > taxSlab[index].Item1 ? taxSlab[index].Item1 : remainingSalary;

                incomeTax += (currentSlab - previousSlab) * taxSlab[index].Item2;
                previousSlab = taxSlab[index].Item1;
                index++;
            }

            return incomeTax / 12;
        }

        public static int LastDayOfMonth(string monthName)
        {
            int monthValue = DateTime.ParseExact(monthName, "MMMM", CultureInfo.CurrentCulture).Month;

            if (new[] { 1, 3, 5, 7, 8, 10, 12 }.Contains(monthValue))
            {
                return 31;
            }
            else if (monthValue == 2)
            {
                return 28; // For February returning 28 only as We are not passing year so not considering leap years in current scenario.
            }
            else
            {
                return 30;
            }
        }
    }
}
