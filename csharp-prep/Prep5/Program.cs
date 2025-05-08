using System;

class Program
{
    static void Main(string[] args)
    {
        displayWelcome();
        string name = promptUserName();
        int number = promptUserNumber();
        number = squareNumber(number);
        displayResult(name,number);
    }
    static void displayWelcome() {
        Console.WriteLine("Welcome to the Program");
    }
    static string promptUserName() {
        Console.Write("Please enter your name >>> ");
        string name = Console.ReadLine();
        return name;
    }
    static int promptUserNumber() {
        Console.Write("Please enter your favorite integer >>> ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
    static int squareNumber(int number) {
        return number*number;
    }
    static void displayResult(string name, int number) {
        Console.WriteLine($"\nHello, {name}!");
        Console.WriteLine($"The square of your favorite integer is {number}");
    }
}