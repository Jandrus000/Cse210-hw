using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

public class Deck
{
    private List<Card> _cards;

    public Deck()
    {
        _cards= new List<Card>(){new Card("♠","A"),new Card("♣","A"),new Card("♥","A"),new Card("♦","A"),new Card("♠","2"),new Card("♣","2"),
        new Card("♥","2"),new Card("♦","2"),new Card("♠","3"),new Card("♣","3"),new Card("♥","3"),new Card("♦","3"),new Card("♠","4"),
        new Card("♣","4"),new Card("♥","4"),new Card("♦","4"), new Card("♠","5"),new Card("♣","5"),new Card("♥","5"),new Card("♦","5"),
        new Card("♠","6"),new Card("♣","6"),new Card("♥","6"),new Card("♦","6"),new Card("♠","7"),new Card("♣","7"),new Card("♥","7"),
        new Card("♦","7"),new Card("♠","8"),new Card("♣","8"),new Card("♥","8"),new Card("♦","8"),new Card("♠","9"),new Card("♣","9"),
        new Card("♥","9"),new Card("♦","9"),new Card("♠","10"),new Card("♣","10"),new Card("♥","10"),new Card("♦","10"),new Card("♠","J"),
        new Card("♣","J"),new Card("♥","J"),new Card("♦","J"),new Card("♠","Q"),new Card("♣","Q"),new Card("♥","Q"),new Card("♦","Q"),
        new Card("♠","K"),new Card("♣","K"),new Card("♥","K"),new Card("♦","K")};
    }

    public void Shuffle()
    {
        Random random = new Random();

        List<Card> cardsToBeShuffled = _cards;
        List<Card> newDeck = new List<Card>(); 
        while(cardsToBeShuffled.Count>0)
        {
            int removedCard = random.Next(0,cardsToBeShuffled.Count);
            newDeck.Add(cardsToBeShuffled[removedCard]);
            cardsToBeShuffled.RemoveAt(removedCard);
        }
        _cards = newDeck;

    }

    public List<Card> GetCards()
    {
        return _cards;
    }

    public void SetCards(List<Card> cards)
    {
        _cards = cards;
    }
}