using System;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        bool keep_playing = true;
        Console.WriteLine("Welcome to GUESS THE MAGIC NUMBER!");
        do {
            int attempts = 0;

            Random randomGenerator = new Random();
            int magic_number = randomGenerator.Next(1,100);
            int user_number = 0;

            Console.WriteLine("\n");

            while (user_number != magic_number) {
                Console.Write("Enter your guess >>> ");
                user_number = int.Parse(Console.ReadLine());

                if (user_number > magic_number) {
                    Console.WriteLine(">Lower");
                }
                else if (user_number < magic_number) {
                    Console.WriteLine(">Higher");
                }
                else {
                    Console.WriteLine("You guessed the magic number!");
                }

                attempts ++;
            }
            Console.WriteLine($"(With {attempts} attempts)");
            Console.Write("\nPlay Again? [y/n] >>> ");

            keep_playing = (Console.ReadLine()=="y");

        } while (keep_playing);
    }
}