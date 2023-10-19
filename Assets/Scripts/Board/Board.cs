using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Deck deck;
    public RowIndicator rowIndicator;
    public float verticalPadding;
    public float horizontalPadding;

    private int numRows = 4;

    public Transform boardTransform;

    private List<List<GameObject>> boardRows = new List<List<GameObject>>();

    void Awake()
    {
        for (int i = 0; i < numRows; i++)
        {
            boardRows.Add(new List<GameObject>());
        }
    }

    public void PlayCard(GameObject card)
    {
        Card cardToPlay = card.GetComponent<Card>();
        (int dif, int row) check = CheckRows(cardToPlay);
        if (check.row > -1)
        {
            if (boardRows[check.row].Count < 5)
            {
                AddCardToRow(check.row, card);
            }
            else
            {
                EatRow(check.row, card, cardToPlay.owner);
            }    
        }
        else
        {
            StartCoroutine(cardToPlay.owner.PickRowToEat(card));
        }
    }

    public void EatRow(float row, GameObject card, Player player)
    {
        int cats = 0;

        foreach (GameObject c in boardRows[(int) row]) 
        {
            cats += c.GetComponent<Card>().GetCats();
            c.SetActive(false); 
        }
        boardRows[(int)row].Clear();
        AddCardToRow((int) row, card);
        player.UpdateCats(-cats);
    }

    (int dif, int row) CheckRows(Card card)
    {
        int dif = 105, row = -1;
        bool canBePlaced = false;

        Card lastCard;

        for (int i = 0; i < boardRows.Count; i++)
        {
            lastCard = boardRows[i][boardRows[i].Count - 1].GetComponent<Card>();
            int difference = card.GetCardID() - lastCard.GetCardID();

            if (difference > 0) 
            {
                if (difference < dif)
                {
                    dif = difference;
                    row = i;
                    canBePlaced = true;
                }
            }
        }
        return canBePlaced ? (dif, row) : (-1, -1);
    }

    void UpdateBoardPosition()
    {
        for (int i = 0; i < boardRows.Count; i++)
        {
            for (int j = 0; j < boardRows[i].Count; j++)
            {
                GameObject card = boardRows[i][j];
                float xPos = transform.position.x - horizontalPadding*2.5f + j * horizontalPadding;
                float zPos = transform.position.y + verticalPadding*2 - i * verticalPadding;
                card.transform.rotation = Quaternion.identity;
                card.transform.localScale = new Vector3(0.05714285f, 1, 0.1111111f);
                card.transform.position = new Vector3(xPos, 0.1f, zPos);
            }
        }
    }

    public void SetupBoard()
    {
        for (int i = 0; i < numRows; i++) 
        {
            GameObject card = deck.DrawRandomCard();
            if (card != null)
            {
                card.transform.SetParent(boardTransform);
                card.SetActive(true);
                AddCardToRow( i, card);
            }
        }
        UpdateBoardPosition();
    }

    public void AddCardToRow(int row, GameObject card)
    {
        if (row >= 0 && row < numRows)
        {
            boardRows[row].Add(card);
            card.SetActive(true);
            card.transform.SetParent(boardTransform);
            UpdateBoardPosition();
        }
    }
}
