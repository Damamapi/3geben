using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<GameObject> hand = new List<GameObject>();
    
    private int cats = 0;

    public HandDisplay handDisplay;
    public Board board;
    public Deck deck;

    public GameObject PickCardToPlay(int positionInHand)
    {
        GameObject selectedCard = hand[positionInHand];
        hand.RemoveAt(positionInHand);
        handDisplay.RemoveCardFromHand(selectedCard);
        return selectedCard;
    }

    public List<GameObject> GetHand()
    {
        return hand;
    }

    public void AddCardToHand(GameObject card) 
    {
        hand.Add(card);
        handDisplay.AddCardToHand(card);
    } 
}
