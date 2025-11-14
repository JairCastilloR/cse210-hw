using System;
using System.Collections.Generic;

public class ScriptureLibrary
{
    private List<Scripture> _scriptures;

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>
        {
            new Scripture(new Reference("Proverbs", 3, 5), 
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding."),
            new Scripture(new Reference("John", 3, 16), 
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Philippians", 4, 13), 
                "I can do all things through Christ which strengtheneth me."),
            new Scripture(new Reference("Romans", 8, 28), 
                "And we know that all things work together for good to them that love God, to them who are the called according to his purpose.")
        };
    }

    public Scripture GetRandomScripture()
    {
        Random random = new Random();
        int index = random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}
