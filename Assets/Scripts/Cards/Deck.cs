using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<GameObject> cards = new List<GameObject>();

    public GameObject cardPrefab;


    public void InitializeDeck()
    {
        cards.Clear();

        for (int id = 1; id <= 104; id++)
        {
            int points = SetCardPoints();
            GameObject card = Instantiate(cardPrefab, transform);
            Card cardInfo = card.GetComponent<Card>();
            cardInfo.SetCardID(id);
            cardInfo.SetCats(points);
            card.SetActive(false);
            cards.Add(card);
        }
    }

    public GameObject DrawRandomCard() 
    {
        if (cards.Count == 0)
        {
            Debug.LogWarning("Deck is empty.");
            return null;
        }

        int randomIndex = Random.Range(0, cards.Count);
        GameObject drawnCard = cards[randomIndex];
        cards.RemoveAt(randomIndex);

        return drawnCard;
    }

    private int SetCardPoints()
    {
        return Random.Range(1, 5);
    }
}
