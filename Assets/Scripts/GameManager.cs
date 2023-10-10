using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public HandDisplay handDisplay;
    public Board board;
    public Deck deck;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DealHand(5);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            handDisplay.SetCardPositions();
        }
    }

    public void DealHand(int amountOfCards)
    {
        for (int i = 0; i < amountOfCards; i++)
        {
            player.AddCardToHand(deck.DrawRandomCard());
        }
    }
}
