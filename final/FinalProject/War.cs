using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;

public class War: Game{
    protected Deck _player2Cards = new Deck (new List<Card>());
    protected Deck _middlePile = new Deck(new List<Card>());

    public War(){
        SplitDeck();
        _player1Cards.Shuffle();
        _player2Cards.Shuffle();

    }

    public void SplitDeck()
    {
        for (int i = 0; i<26;i++)
        {
            _player2Cards.AddNew(_player1Cards.GetCards()[i]);
            _player1Cards.RemoveCardAt(i);
        }
    }

    public int GetCardRank(string face)
    {
        int rank = -1;
        if(face == "A")
            rank = 14;
        else if(face == "K")
            rank = 13;
        else if(face == "Q")
            rank = 12;
        else if(face == "J")
            rank = 11;
        else
            rank = Int32.Parse(face);
        
        return rank;
    }


}