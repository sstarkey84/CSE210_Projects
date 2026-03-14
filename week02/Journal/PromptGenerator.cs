using System;
using System.Collections.Generic;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one thing I learned today?",
        "What is something I am grateful for today?"
    };
    private int _lastIndex = -1;
    public string GetRandomPrompt()
    {
        Random rand = new Random();
        int index;
        do
        {
            index = rand.Next(_prompts.Count);
        }
        while (index == _lastIndex);
        _lastIndex = index;
        return _prompts[index];
    }
}