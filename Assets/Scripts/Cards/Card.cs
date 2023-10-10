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
