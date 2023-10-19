using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public HandDisplay handDisplay;
    public Board board;
    public Deck deck;
    public RoundManager roundManager;

    private void Start()
    {
        deck.InitializeDeck();
        // TODO update this method to have the players added from a different script to be used by the Lobby manager
        roundManager.players.Add(player);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            roundManager.StartDealRound();
        }
    }
}
