using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCardInteraction : MonoBehaviour
{
    private bool isOnHand = false;
    private bool isHovered = false;
    public Card card;

    public delegate void CardSelectedHandler(GameObject card);

    public static event CardSelectedHandler CardSelected;

    private bool isSelected = false;
    private Material originalMaterial;

    private void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        if (isOnHand)
        {
            // if (isSelected)
            // {
             //    transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            // }
            if (isHovered)
            {
                transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            }
            else
            {
                transform.localScale = Vector3.one;
            }
        }
    }

    public bool IsOnHand
    {
        get { return isOnHand; }
        set { isOnHand = value; }
    }

    public bool IsSelected
    {
        get { return isSelected; }
    }
    // Handle mouse hover
    private void OnMouseEnter()
    {
        if (isOnHand)
        {
            isHovered = true;
        }
    }

    private void OnMouseExit()
    {
        if (isOnHand)
        {
            isHovered = false;
        }
    }

    // Handle card selection
    private void OnMouseDown()
    {
        if (isOnHand)
        {
            CardSelected?.Invoke(gameObject);
        }
    }
}
