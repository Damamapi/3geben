using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<GameObject> hand = new List<GameObject>();
    // public event Action<bool> OnCardOnHandChanged;

    // private int cats = 0;

    public HandDisplay handDisplay;
    public Board board;
    public Deck deck;

    public GameObject PickCardToPlay(GameObject card)
    {
        GameObject selectedCard = card;
        hand.Remove(card);
        handDisplay.RemoveCardFromHand(selectedCard);
        selectedCard.GetComponent<HandCardInteraction>().IsOnHand = false;
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
        card.GetComponent<HandCardInteraction>().IsOnHand = true;
    } 
}
