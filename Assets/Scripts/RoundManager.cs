using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    private List<GameObject> selectedCards = new List<GameObject>();
    public List<Player> players = new List<Player>();

    private Board board;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GetComponentInParent<GameManager>();
        if (gameManager != null)
        {
            board = gameManager.board;
        }
    }

    public void SelectCard(GameObject card)
    { 
        selectedCards.Add(card);
    }

    public void StartRound()
    {
        StartCoroutine(RoundCoroutine());
    }

    IEnumerator RoundCoroutine()
    {
        Debug.Log("Round has started, getting players card");

        // Await the picking of all player cards before proceeding
        yield return StartCoroutine(GetPlayersCardCoroutine());

        Debug.Log("Cards selected");
        selectedCards.Sort(Card.SortByCardID);

        // Continue with the rest of your logic
    }


    IEnumerator GetPlayersCardCoroutine()
    {
        foreach (Player player in players)
        {
            // This will now halt execution of this coroutine until the player has picked a card
            yield return StartCoroutine(player.PickCardToPlayCoroutine());
            Debug.Log("Player picked a card" + player.pickedCard.ToString());
            board.PlayCard(player.pickedCard);
        }
    }

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }
}
