public class Comment
{
    private string _commentText;
    private string _personName;

    public Comment() { }

    public Comment(string text, string name)
    {
        _commentText = text;
        _personName = name;
    }

    public void createComment(string text, string name)
    {
        _commentText = text;
        _personName = name;
    }

    public void DisplayAll()
    {
        Console.WriteLine($"{_personName}: {_commentText}");
    }
}
