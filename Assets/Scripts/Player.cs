using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private List<GameObject> hand = new List<GameObject>();
    // public event Action<bool> OnCardOnHandChanged;

    public GameObject pickedCard;
    // private int cats = 0;

    public HandDisplay handDisplay;
    public Board board;
    public Deck deck;

    bool hasCardBeenPicked = false;

    public void CardPicked(GameObject card)
    {
        GameObject selectedCard = card;
        hand.Remove(card);
        handDisplay.RemoveCardFromHand(selectedCard);
        selectedCard.GetComponent<HandCardInteraction>().IsOnHand = false;
        hasCardBeenPicked = true;
        pickedCard = selectedCard;
    }

    public IEnumerator PickCardToPlayCoroutine()
    {
        // Reset this variable
        hasCardBeenPicked = false;

        // Subscribe to the event
        HandCardInteraction.CardSelected += CardPicked;

        // Wait until the card has been picked
        while (!hasCardBeenPicked)
        {
            yield return null;
        }

        // Unsubscribe from the event
        HandCardInteraction.CardSelected -= CardPicked;
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

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }
}
