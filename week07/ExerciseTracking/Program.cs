using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();
        activities.Add(new Running("03 Nov 2022", 30, 3.0));
        activities.Add(new Cycling("10 April 2023", 40, 29.5));
        activities.Add(new Swimming("30 Mar 2025", 20, 20));

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}