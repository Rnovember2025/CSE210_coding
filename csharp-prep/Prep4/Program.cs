using System;

class Program
{
    static void Main(string[] args)
    {
        int number_entered;
        List<int> numbers = new List<int>();
        int total = 0;
        int max = 0;
        int positive_min = 0;

        Console.WriteLine("Enter your numbers. Terminate by typing 0.");

        while (true) {
            Console.Write(">>> ");
            number_entered = int.Parse(Console.ReadLine());
            if (number_entered == 0) { //User exited loop
                break;
            }
            if (positive_min == 0 && number_entered > 0) { //initialise positive_min
                positive_min = number_entered;
            }
            if (number_entered > 0 && positive_min > number_entered) { //update positive_min
                positive_min = number_entered;
            }
            if (number_entered > max | max == 0) { //update max or initialze max
                max = number_entered;
            }

            numbers.Add(number_entered);
            total += number_entered;
        }
        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is: {(float)total/numbers.Count}");
        Console.WriteLine($"The largest number is: {max}");
        if (positive_min != 0) {
            Console.WriteLine($"The smallest positive number was {positive_min}");
        }
        else {
            Console.WriteLine("You did not enter any positive numbers");
        }

    }
}