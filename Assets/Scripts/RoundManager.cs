using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private List<GameObject> selectedCards = new List<GameObject>();
    private List<Player> players = new List<Player>();

    private Board board;

    private void Start()
    {
        board = GetComponentInParent<Board>();
    }

    public void SelectCard(GameObject card)
    { 
        selectedCards.Add(card);
    }

    public void StartRound()
    {
        foreach (Player player in players)
        {
            foreach (GameObject card in player.GetHand())
            {
                if (card != null)
                {
                    if (card.GetComponent<HandCardInteraction>().IsSelected)
                    {
                        SelectCard(card);
                        player.PickCardToPlay(card);
                        break;
                    }
                }
            }
        }

        selectedCards.Sort(Card.SortByCardID);

        
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }
}
