using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# Abstraction in 10 Minutes", "CodeCraft Academy", 615);
        video1.AddComment(new Comment("Sarah Connor", "This explanation of abstraction made everything click for me!"));
        video1.AddComment(new Comment("John Doe", "Clear and concise, thank you."));
        video1.AddComment(new Comment("Alice Smith", "Could you do a follow-up on encapsulation?"));
        videos.Add(video1);

        Video video2 = new Video("Object-Oriented Programming Fundamentals", "DevMastery", 1240);
        video2.AddComment(new Comment("Bob Johnson", "Best OOP crash course on YouTube."));
        video2.AddComment(new Comment("Emma Watson", "The diagrams really helped visualize class responsibilities."));
        video2.AddComment(new Comment("Michael Brown", "Great pacing and real-world examples."));
        video2.AddComment(new Comment("Lucas Silva", "Watched this before my technical interview and passed!"));
        videos.Add(video2);

        Video video3 = new Video("Clean Code Architecture: Principles & Patterns", "Tech Lead Pro", 945);
        video3.AddComment(new Comment("David Miller", "KISS and YAGNI are principles everyone should practice."));
        video3.AddComment(new Comment("Sophia Taylor", "Super clean examples and well structured."));
        video3.AddComment(new Comment("Carlos Eduardo", "Subscribed! Looking forward to the next lesson."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetAuthorName()}: \"{comment.GetText()}\"");
            }

            Console.WriteLine("==================================================");
            Console.WriteLine();
        }
    }
}