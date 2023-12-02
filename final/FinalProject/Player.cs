public class Player{
    private string _name;
    private int _wins;

    public Player(string name)
    {
        _name = name;
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    public void IncrementWins()
    {
        _wins++;
    }

    public int GetWins()
    {
        return _wins;
    }
    public void SetWins(int wins)
    {
        _wins = wins;
    }

    public void SavePlayer()
    {
        using (var writer = new StreamWriter(@"players.txt", true))
        {
            writer.WriteLine($"{_wins},{_name}");
            writer.Close();
        }

    }

}