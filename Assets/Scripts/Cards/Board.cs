using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Deck deck;
    public float verticalPadding;
    public float horizontalPadding;
    void Start()
    {
        deck.InitializeDeck();
        SetupBoard();
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space)) 
    }
    void SetupBoard()
    {
        for (int i = 0; i < 4; i++) 
        {
            GameObject card = deck.DrawRandomCard();
            if (card != null)
            {
                Vector3 cardPosition = new Vector3(transform.position.x - horizontalPadding * 2.5f, 1f, transform.position.z - i * verticalPadding);

                card.transform.position = cardPosition;
                card.SetActive(true);
            }
        }
    }

    void DisplayCard(GameObject card)
    {
        if (card != null) 
        {
            card.transform.position = transform.position;
            card.SetActive(true);
        }
    }
}
