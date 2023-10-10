using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    private int cardID;
    private int cats = 1;

    public TextMeshProUGUI idText;
    public TextMeshProUGUI catsText;

    private void OnEnable()
    {
        UpdateCardText();
    }

    public static int SortByCardID(GameObject card1, GameObject card2)
    {
        // Assuming your Card script has a method to get the card ID
        Card cardScript1 = card1.GetComponent<Card>();
        Card cardScript2 = card2.GetComponent<Card>();

        if (cardScript1 != null && cardScript2 != null)
        {
            int cardID1 = cardScript1.GetCardID();
            int cardID2 = cardScript2.GetCardID();

            // Compare the card IDs
            return cardID1.CompareTo(cardID2);
        }
        else
        {
            // Handle the case where cardScript1 or cardScript2 is null
            return 0;
        }
    }

    void UpdateCardText()
    {
        idText.text = "" + cardID;
        catsText.text = "" + cats;
    }

    public void SetCardID(int id)
    {
        cardID = id;
    }

    public void SetCats(int points)
    {
        cats = points;
    }

    public int GetCardID() {
        return cardID;
    }

    public int GetCats() {
        return cats;
    }
}
