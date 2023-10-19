using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleTester : MonoBehaviour
{
    public Deck deck;
    public Player player;
    
    void Start()
    {
        deck.InitializeDeck();
    }

    public void DealHand(int amountOfCards)
    {
        for(int i = 0; i < amountOfCards; i++)
        {
            player.AddCardToHand(deck.DrawRandomCard());
        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DealHand(10);
            // 1foreach (GameObject card in player.GetHand()) Debug.Log(card.GetCardID());
            // for(int i = 0; i < 104; i++)
            // {
            //     Debug.Log(deck.DrawRandomCard().GetCardID());
            // }
        }
    }
}
