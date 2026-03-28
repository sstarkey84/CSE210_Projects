using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video();
        video1.Title = "Fishing for Trout";
        video1.Author = "Scott";
        video1.Length = 520;
        video1.Comments.Add(new Comment("Mike", "What bait were you using?"));
        video1.Comments.Add(new Comment("Jake", "Nice catch."));
        video1.Comments.Add(new Comment("Chris", "Goint to try this spot!"));
        video1.Comments.Add(new Comment("Tom", "Great tips."));

        Video video2 = new Video();
        video2.Title = "Elk hunting Gear List";
        video2.Author = "Ben";
        video2.Length = 750;
        video2.Comments.Add(new Comment("Ryan", "Looks like a great pack."));
        video2.Comments.Add(new Comment("Reid", "Great setup!"));
        video2.Comments.Add(new Comment("Andrew", "Good video."));
        video2.Comments.Add(new Comment("Dan", "Helpful insight."));

        Video video3 = new Video();
        video3.Title = "Camping with kids";
        video3.Author = "Natalie";
        video3.Length = 640;
        video3.Comments.Add(new Comment("Wesley", "This was helpful."));
        video3.Comments.Add(new Comment("Clayton", "Keeping it simple is key."));
        video3.Comments.Add(new Comment("Roxann", "Great ideas for kids!"));
        video3.Comments.Add(new Comment("Clara", "I'm going to try this next time."));

        List<Video> videos= new List<Video>();
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine("Title: " + video.Title);
            Console.WriteLine("Author: " + video.Author);
            Console.WriteLine("Length: " + video.Length + " seconds");
            Console.WriteLine("Number of Comments: " + video.GetCommentCount());

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine(comment.Name + ": " + comment.Text);
            }
            Console.WriteLine();
        }
    }
}