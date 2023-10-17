class Reference
{
    private string _book;
    private int _chapter;
    private List<int> _verses = new List<int>();

    public Reference(string book, int chapter, List<int> verses)
    {
        _book = book;
        _chapter = chapter;
        _verses = verses;
    }

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verses.Add(verse);
    }

    public void PrintReference()
    {
        if(_verses.Count()>1)
            Console.WriteLine($"{_book} {_chapter}:{_verses[0]}-{_verses[_verses.Count()-1]}");
        else if(_verses.Count() == 1)
            Console.WriteLine($"{_book} {_chapter}:{_verses[0]}");
        else
            Console.WriteLine("uh oh brokey");
            
        
    }

    public string GetBook()
    {
        return _book;
    }

    public void SetBook(string book)
    {
        _book = book;
    }

    public int GetChapter()
    {
        return _chapter;
    }

    public void SetChapter(int chapter)
    {
        _chapter = chapter;
    }

    public List<int> GetVerses()
    {
        return _verses;
    }

    public void SetVerses(List<int> verses)
    {
        _verses = verses;
    }

    public void SetVerses(int verses)
    {
        _verses[0] = verses;
    }



    
}