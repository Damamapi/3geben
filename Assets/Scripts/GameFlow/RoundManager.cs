using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private List<GameObject> selectedCards = new List<GameObject>();
    public List<Player> players = new List<Player>();

    private Board board;
    private Deck deck;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GetComponentInParent<GameManager>();
        if (gameManager != null)
        {
            deck = gameManager.deck;
            board = gameManager.board;
        }
    }

    public void SelectCard(GameObject card)
    { 
        selectedCards.Add(card);
    }

    public void StartDealRound()
    {
        board.SetupBoard();
        foreach (Player player in players)
        {
            DealHand(7, player);
        }
        StartRound();
    }

    public void DealHand(int amountOfCards, Player player)
    {
        for (int i = 0; i < amountOfCards; i++)
        {
            player.AddCardToHand(deck.DrawRandomCard());
        }
    }

    public void StartRound()
    {
        StartCoroutine(PlayCardRound());
    }

    IEnumerator PlayCardRound()
    {
        // Await the picking of all player cards before proceeding
        yield return StartCoroutine(GetPlayersCardCoroutine());
        selectedCards.Sort(Card.SortByCardID);
        
        // Play the cards selected
        foreach (GameObject card in selectedCards)
        {
            board.PlayCard(card);
        }
        selectedCards.Clear();

        if (players[0].hand.Count > 0)
        {
            StartCoroutine(PlayCardRound());
        }
        else StartDealRound();
    }


    IEnumerator GetPlayersCardCoroutine()
    {
        foreach (Player player in players)
        {
            // Halt execution of this coroutine until the player has picked a card
            yield return StartCoroutine(player.PickCardToPlayCoroutine());
            SelectCard(player.pickedCard);
        }
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }
}
