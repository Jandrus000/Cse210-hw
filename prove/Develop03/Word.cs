class Word{
    private bool _shown;
    private  string _word;

    public Word(string newWord)
    {
        _word = newWord;
        _shown = true;
    }

    public void HideWord()
    {
        // Inside this if statement is what decides if Words are hidden. If the Word is already hidden then it is skipped. 
        if(_shown)
        {
            Random rnd = new Random();
            if(rnd.Next(1,11)==10){
                _shown = false;
            }
        }
    }

    public void PrintWord()
    {
        Console.Write(_word);
    }

    public string GetWord()
    {
        return _word;
    }

    public void SetWord(string newWord)
    {
        _word = newWord;
    }

    public bool GetShown()
    {
        return _shown;
    }

    public void SetShown(bool shown)
    {
        _shown = shown;
    }


}