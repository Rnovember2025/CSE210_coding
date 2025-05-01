using System;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("THE AUTO LETTER GRADER !200045342FK3\n");

        Console.Write("Please enter your grade as a percentage >>> ");
        int grade_percent;
        grade_percent = int.Parse(Console.ReadLine());

        string letter;
        string suffix;

        letter = getLetter(grade_percent);
        suffix = getSuffix(grade_percent);
        
        Console.Write($"Your Letter Grade is [{letter}{suffix}]");

        if (grade_percent >= 70)
        {
            Console.WriteLine("!\nGreat Job! You passed the class.");
        }
        else
        {
            Console.WriteLine("...\nYou didn't pass. What happened?");
        }
    }
    static string getLetter(int grade_percent)
    {
        string letter;

        if (grade_percent >= 90)
        {
            letter = "A";
        }
        else if (grade_percent >= 80)
        {
            letter = "B";
        }
        else if (grade_percent >= 70)
        {
            letter = "C";
        }
        else if (grade_percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        return letter;
    }
    static string getSuffix(int grade_percent)
    {
        int last_digit = grade_percent % 10;
        string suffix;

        if ((last_digit >= 7) && (grade_percent < 90) && (grade_percent >= 60))
        {
            suffix = "+";
        }
        else if ((last_digit < 3) && (grade_percent >= 60))
        {
            suffix = "-";
        }
        else
        {
            suffix = "";
        }

        return suffix;
    }
}