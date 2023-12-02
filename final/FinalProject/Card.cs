public class Card
{
    string _suite;
    string _face;
    bool _revealed;
    List<string> _displayLines;
    List<string> _displayBack = new List<string>(){"┌─────────┐",
                                                "│\\/\\/\\/\\/\\│",
                                                "│/\\/\\/\\/\\/│",
                                                "│\\/\\/\\/\\/\\│",
                                                "│/\\/\\/\\/\\/│",
                                                "│\\/\\/\\/\\/\\│",
                                                "│/\\/\\/\\/\\/│",
                                                "│\\/\\/\\/\\/\\│",
                                                "└─────────┘"};

    List<string> _displayEmpty = new List<string>(){"           ",
                                                    "           ",
                                                    "           ",
                                                    "           ",
                                                    "           ",
                                                    "           ",
                                                    "           ",
                                                    "           ",
                                                    "           "};

    public Card(string suite, string face)
    {
        _suite = suite;
        _face = face;
        _displayLines= new List<string>();
        if(_face == "A")
        {
            _displayLines.Add("┌─────────┐");
            _displayLines.Add("│A        │");
            _displayLines.Add("│         │");
            _displayLines.Add("│         │");
            _displayLines.Add($"│    {suite}    │");
            _displayLines.Add("│         │");
            _displayLines.Add("│         │");
            _displayLines.Add("│        A│");
            _displayLines.Add("└─────────┘");
        }
        else if(_face == "2")
        { 
            _displayLines.Add($"┌─────────┐");
            _displayLines.Add($"│2        │");
            _displayLines.Add($"│         │");
            _displayLines.Add($"│    {suite}    │");
            _displayLines.Add($"│         │");
            _displayLines.Add($"│    {suite}    │");
            _displayLines.Add($"│         │");
            _displayLines.Add($"│        2│");
            _displayLines.Add($"└─────────┘");
        }
        else if(_face == "3")
        {
            _displayLines.Add($"┌─────────┐");
            _displayLines.Add($"│3        │");
            _displayLines.Add($"│         │");
            _displayLines.Add($"│    {suite}    │");
            _displayLines.Add($"│    {suite}    │");
            _displayLines.Add($"│    {suite}    │");
            _displayLines.Add($"│         │");
            _displayLines.Add($"│        3│");
            _displayLines.Add($"└─────────┘");
        }
        else if(_face == "4")
        {
            _displayLines.Add($"┌─────────┐");
            _displayLines.Add($"│4        │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│         │");
            _displayLines.Add($"│         │");
            _displayLines.Add($"│         │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│        4│");
            _displayLines.Add($"└─────────┘");
        }
        else if(_face == "5")
        {
            _displayLines.Add($"┌─────────┐");
            _displayLines.Add($"│5        │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│         │");
            _displayLines.Add($"│    {suite}    │");
            _displayLines.Add($"│         │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│        5│");
            _displayLines.Add($"└─────────┘");
        }
        else if(_face == "6")
        {
            _displayLines.Add($"┌─────────┐");
            _displayLines.Add($"│6        │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│         │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│         │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│        6│");
            _displayLines.Add($"└─────────┘");
        }
        else if(_face == "7")
        {
            _displayLines.Add($"┌─────────┐");
            _displayLines.Add($"│7        │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│    {suite}    │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│         │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│        7│");
            _displayLines.Add($"└─────────┘");
        }
        else if(_face == "8")
        {
            _displayLines.Add($"┌─────────┐");
            _displayLines.Add($"│8        │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│    {suite}    │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│    {suite}    │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│        8│");
            _displayLines.Add($"└─────────┘");
        }
        else if(_face == "9")
        {
            _displayLines.Add($"┌─────────┐");
            _displayLines.Add($"│9        │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│    {suite}    │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│        9│");
            _displayLines.Add($"└─────────┘");
        }
        else if(_face == "10")
        {
            _displayLines.Add($"┌─────────┐");
            _displayLines.Add($"│10       │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│  {suite}   {suite}  │");
            _displayLines.Add($"│       10│");
            _displayLines.Add($"└─────────┘");
        }
        else if(_face == "J")
        {
            _displayLines.Add($"┌─────────┐");
            _displayLines.Add($"│J        │");
            _displayLines.Add($"│      {suite}{suite} │");
            _displayLines.Add($"│      {suite}{suite} │");
            _displayLines.Add($"│      {suite}{suite} │");
            _displayLines.Add($"│ {suite}{suite}   {suite}{suite} │");
            _displayLines.Add($"│  {suite}{suite}{suite}{suite}{suite}  │");
            _displayLines.Add($"│        J│");
            _displayLines.Add($"└─────────┘");
        }
        else if(_face == "Q")
        {
            _displayLines.Add($"┌─────────┐");
            _displayLines.Add($"│Q        │");
            _displayLines.Add($"│  {suite}{suite}{suite}{suite}   │");
            _displayLines.Add($"│ {suite}{suite}   {suite}{suite} │");
            _displayLines.Add($"│ {suite}{suite}   {suite}{suite} │");
            _displayLines.Add($"│   {suite}{suite}{suite}{suite}  │");
            _displayLines.Add($"│      {suite}{suite} │");
            _displayLines.Add($"│        Q│");
            _displayLines.Add($"└─────────┘");
        }
        else if(_face == "K")
        {
            _displayLines.Add($"┌─────────┐");
            _displayLines.Add($"│K        │");
            _displayLines.Add($"│  {suite}{suite}  {suite}{suite} │");
            _displayLines.Add($"│  {suite}{suite} {suite}{suite}  │");
            _displayLines.Add($"│  {suite}{suite}{suite}{suite}   │");
            _displayLines.Add($"│  {suite}{suite} {suite}{suite}  │");
            _displayLines.Add($"│  {suite}{suite}  {suite}{suite} │");
            _displayLines.Add($"│        K│");
            _displayLines.Add($"└─────────┘");
        }
    }

    public void SetSuite(string suite)
    {
        _suite = suite;
    }

    public string GetSuite()
    {
        return _suite;
    }
    public void SetFace(string face)
    {
        _face = face;
    }

    public string GetFace()
    {
        return _face;
    }

    public void SetRevealed(bool revealed)
    {
        _revealed = revealed;
    }

    public bool GetRevealed()
    {
        return _revealed;
    }

    public List<String> GetDisplay()
    {
        return _displayLines;
    }
    public List<String> GetBackDisplay()
    {
        return _displayBack;
    }


    public void DisplayCard()
    {
        foreach(var line in _displayLines)
        {
            System.Console.WriteLine(line);
        }
    }

    public void ChangeToEmpty()
    {
        _displayLines = _displayEmpty;
    }
}