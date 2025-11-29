public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _Comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public void AddComment(Comment newComment)
    {
        _Comments.Add(newComment);
    }

    public int GetNumberOfComments()
    {
        return _Comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");

        foreach (Comment comment in _Comments)
        {
            comment.DisplayAll();
        }

        Console.WriteLine();
    }
}
