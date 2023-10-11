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

    public Transform boardTransform;

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
        }
    }

    public void PlayCard(GameObject card)
    {
        AddCardToRow(GetLowestValue().row, card);
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
                GameObject card = boardRows[i][j];
                float xPos = transform.position.x - horizontalPadding*2.5f + j * horizontalPadding;
                float zPos = transform.position.y + verticalPadding*2 - i * verticalPadding;
                card.transform.position = new Vector3(xPos, 0.1f, zPos);
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
                AddCardToRow( i, card);
                card.transform.SetParent(boardTransform);
                card.SetActive(true);
            }
        }
        UpdateBoardPosition();
    }

    public void AddCardToRow(int row, GameObject card)
    {
        if (row >= 0 && row < numRows)
        {
            if (boardRows[row].Count < 5)
            {
                boardRows[row].Add(card);
                card.SetActive(true);
                card.transform.SetParent(boardTransform);
                UpdateBoardPosition();
            }
        }
    }
}
