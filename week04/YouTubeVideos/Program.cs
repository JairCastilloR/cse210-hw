using System;

class Program
{
    static void Main(string[] args)
    {
        Video v1 = new Video("How to Prepare Ceviche", "FoodMaster", 520);
        v1.AddComment(new Comment("Great instructions, thanks!", "John"));
        v1.AddComment(new Comment("I tried it at home and it turned out amazing!", "Emily"));
        v1.AddComment(new Comment("Clear steps and well explained.", "Michael"));

        Video v2 = new Video("Great Peruvian Chess Players", "ChessWorld", 680);
        v2.AddComment(new Comment("Very informative!", "Sarah"));
        v2.AddComment(new Comment("I didn't know Peru had so many strong players!", "Daniel"));
        v2.AddComment(new Comment("Excellent historical overview.", "Rebecca"));

        Video v3 = new Video("Technology Applied to Construction", "BuildTech", 840);
        v3.AddComment(new Comment("This is the future of construction!", "Thomas"));
        v3.AddComment(new Comment("Amazing innovations, thanks for sharing.", "Laura"));
        v3.AddComment(new Comment("Very useful for my engineering studies.", "Kevin"));

        v1.Display();
        v2.Display();
        v3.Display();
    }
}
