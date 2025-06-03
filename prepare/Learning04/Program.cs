using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment math = new MathAssignment("Ronan Nash", "Directional Derivitives", "Section 4.6", "Problems 1-100");
        WritingAssignment paper = new WritingAssignment("Ronan Nash", "Research Paper", "AI's influence on Electrical Engineering");

        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());

        Console.WriteLine();

        Console.WriteLine(paper.GetSummary());
        Console.WriteLine(paper.GetWritingInformation());
    }
}