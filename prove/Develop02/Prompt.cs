using System;
class Prompt {
    public List<string> _allPrompts = new List<string>{"Who was the most interesting person I interacted with today?",
                                                       "What was the best part of my day?",
                                                       "How did I see the hand of the Lord in my life today?",
                                                       "What was the strongest emotion I felt today?",
                                                       "If I had one thing I could do over today, what would it be?",
                                                       "How did I overcome a challenge today?",
                                                       "What do you never want to forget about today?",
                                                       "What was the most out of the ordinary thing that happened today?"};

    public Random _rand = new Random();

    public List<string> GetResponse() {
        List<string> userResponse = [_allPrompts[_rand.Next(0,_allPrompts.Count())]];
        Console.WriteLine(userResponse[0]);
        Console.Write(">>> ");
        userResponse.Add(Console.ReadLine());

        Console.Write("\n\n");

        return userResponse;
    }
    
}