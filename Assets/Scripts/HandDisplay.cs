using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDisplay : MonoBehaviour
{
    public Transform handTransform;
    private List<GameObject> displayedCards = new List<GameObject>();

    public float cardSpacing;

    public void AddCardToHand(GameObject card)
    {
        displayedCards.Add(card);
        card.SetActive(true);
        card.transform.SetParent(handTransform);
        card.transform.localPosition = Vector3.zero;
        card.transform.localRotation = Quaternion.identity;

        SetCardPositions();
    }


    public void RemoveCardFromHand(GameObject card)
    {
        displayedCards.Remove(card);
        card.transform.SetParent(null);
        SetCardPositions();
    }

    public void SetCardPositions()
    {
        // Debug.Log("Setting cards");
        int numCards = displayedCards.Count;
        float totalWidth = (numCards - 1) * cardSpacing;
        Vector3 leftmostPosition = handTransform.position - new Vector3(totalWidth / 2f, 0f, 0f);

        for (int i = 0; i < numCards; i++)
        {
            GameObject card = displayedCards[i];
            Vector3 cardPosition = leftmostPosition + new Vector3(i * cardSpacing, 0f, 0f);

            // Preserve the current y and z positions, but set x to the calculated value
            cardPosition.y = card.transform.localPosition.y;
            cardPosition.z = card.transform.localPosition.z;
            card.transform.rotation = Quaternion.Euler(0, 0, -2f);

            card.transform.localPosition = cardPosition;

            // Debug.Log("Card " + i + " Position: " + card.transform.position);
        }
    }
}
