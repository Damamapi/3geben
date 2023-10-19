using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<GameObject> hand = new List<GameObject>();
    // public event Action<bool> OnCardOnHandChanged;

    private float selectedRow;
    bool hasRowBeenPicked = false;

    public GameObject pickedCard;

    private int cats = 33;

    public HandDisplay handDisplay;
    public Board board;
    public Deck deck;
    public RowIndicator rowIndicator;

    bool hasCardBeenPicked = false;

    public void UpdateCats(int catsToDeduct)
    {
        cats += catsToDeduct;
        Debug.Log(cats);
    }

    public IEnumerator PickRowToEat(GameObject card)
    {
        hasRowBeenPicked = false;
        rowIndicator.gameObject.SetActive(true);
        Row.RowSelected += RowPicked;

        while (!hasRowBeenPicked)
        {
            yield return null;
        }

        rowIndicator.gameObject.SetActive(false);
        Row.RowSelected -= RowPicked;
        board.EatRow(selectedRow, card, this);
    }

    void RowPicked(float row)
    {
        selectedRow = row;
        hasRowBeenPicked = true;
    }

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
        hasCardBeenPicked = false;

        HandCardInteraction.CardSelected += CardPicked;

        while (!hasCardBeenPicked)
        {
            yield return null;
        }

        HandCardInteraction.CardSelected -= CardPicked;
    }


    public List<GameObject> GetHand()
    {
        return hand;
    }

    public void AddCardToHand(GameObject card) 
    {
        hand.Add(card);
        card.GetComponent<Card>().owner = this;
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
