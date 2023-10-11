using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Deck deck;
    public float verticalPadding;
    public float horizontalPadding;

    private int numRows = 4;

    private List<List<GameObject>> boardRows = new List<List<GameObject>>();

    void Awake()
    {
        deck.InitializeDeck();

        for (int i = 0; i < numRows; i++)
        {
            boardRows.Add(new List<GameObject>());
        }

        SetupBoard();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(GetLowestValue());
            UpdateBoardPosition();
        }
    }

    public void AddCardToRow(GameObject card, List<GameObject> row)
    {
        if (row.Count <= 5)
        {
            row.Add(card);
        }
    }

    (int id, int row) GetLowestValue()
    {
        int id = 104, row = 0;

        for (int i = 0; i < boardRows.Count; i++)
        {
            Card card = boardRows[i][boardRows[i].Count - 1].GetComponent<Card>();
            if (card.GetCardID() < id)
            {
                id = card.GetCardID();
                row = i;
            }
        }
        return (id, row);
    }

    void UpdateBoardPosition()
    {
        for (int i = 0; i < boardRows.Count; i++)
        {
            for (int j = 0; j < boardRows[i].Count; j++)
            {
                GameObject card = row[i];
                Vector3 cardPosition = new Vector3(transform.position.x - horizontalPadding * 3f, 1f, transform.position.z - i * verticalPadding);
                card.transform.position = cardPosition;
            }
        }
    }

    void SetupBoard()
    {
        for (int i = 0; i < numRows; i++) 
        {
            GameObject card = deck.DrawRandomCard();
            if (card != null)
            {
                Vector3 cardPosition = new Vector3(transform.position.x - horizontalPadding * 3f, 1f, transform.position.z - i * verticalPadding);

                AddCardToRow( i, card);
                card.transform.position = cardPosition;
                card.SetActive(true);
            }
        }
    }

    public void AddCardToRow(int row, GameObject card)
    {
        if (row >= 0 && row < numRows)
        {
            boardRows[row].Add(card);
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
