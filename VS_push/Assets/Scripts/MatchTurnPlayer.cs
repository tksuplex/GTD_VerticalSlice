using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unless denoted by a commented out link, TK wrote literally everything here

public class MatchTurnPlayer : MonoBehaviour
{
    public MatchTurn turn;
    // add movesetscript shit here

    public void doPlayerTurn()
    {
        Debug.Log("You are inside Player's turn!");

        // Do whatever setup needs to be done for player turn
        // enabling player buttons for example...

        // after done all the stuff; set Playerturn to falso
    }

    public void playerSelect(int moveNum)
    {
        // DOES THE SELECTED ACTION WOO

    }

    public void yieldPlayerTurn()
    {
        turn.PlayerTurn = false;
        turn.EnemyTurn = true;
    }
}
