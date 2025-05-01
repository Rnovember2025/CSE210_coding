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
        string name;
        Console.Write("Please enter your name >>> ");
        name = Console.ReadLine();
        return name;
    }
    static int promptUserNumber() {
        int number;
        Console.Write("Please enter your favorite integer >>> ");
        number = int.Parse(Console.ReadLine());
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