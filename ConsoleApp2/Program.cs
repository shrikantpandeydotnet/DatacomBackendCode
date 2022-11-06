// See https://aka.ms/new-console-template for more information

using ConsoleApp2;

PaymentCalc objPaymentCacl = new PaymentCalc();

Console.WriteLine("Please enter your comma separated input");

var input = Console.ReadLine();

var result = objPaymentCacl.EmployeeMonthlyPaySlip(input);

Console.WriteLine(result);
Console.ReadLine();
