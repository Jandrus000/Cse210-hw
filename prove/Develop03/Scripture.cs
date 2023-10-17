class Scripture
{
    private Reference _reference;
    private List<Word> _text = new List<Word>();

    public Scripture(Reference reference, string text)
    {   
        _reference = reference;

        string[] unconvertedText = text.Split(" ");
        foreach(string word in unconvertedText){
            Word nextWord = new Word(word);
            _text.Add(nextWord);
        }
    }

    public void DisplayScripture()
    {
        Console.WriteLine();
        _reference.PrintReference();
        Console.WriteLine();

        foreach(Word word in _text)
        {
            if(word.GetShown())
                Console.Write(word.GetWord()+" ");
            else
            {
                for (int i=0; i < word.GetWord().Length; i++)
                {
                    Console.Write("_");
                }
                Console.Write(" ");
            }
        }
    }

    public void HideWords()
    {   
        // The variable oneHid is a variable initally set to false and the while loop while continue until it is set to true
        bool oneHid = false;
        while(!oneHid)
        {
            foreach (Word word in _text)
            {
                if(word.GetShown())
                {
                    word.HideWord();
                    if(!word.GetShown())
                        // oneHid exceeds assingment requirements by unsuring that at least one word will always be hidden when clicking enter. Once a word is hidden,
                        // oneHid will be set to true and the entire foreach loop is iterated through and the program can exit the while loop.
                        oneHid = true;
                }
            }
        }
    }

    public bool IsHidden()
    {
        foreach(Word word in _text)
        {
            if(word.GetShown())
                return false;
        }
        return true;
    }
}
