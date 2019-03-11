using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Unless denoted by a commented out link, TK wrote literally everything here

public class MatchTurnPlayer : MonoBehaviour
{
    public MatchTurn turn;
    // add movesetscript shit here

    // Certain player buttons will be disabled if not player turn
    // or player does not have that ability

    public GameObject allButtonsObj;
    public GameObject counterButton;
    public GameObject sundayButton;
    public GameObject butterButton;

    public Button jabButton;


    public void doPlayerTurn()
    {
        Debug.Log("You are inside Player's turn!");


        // Start by enabling all buttons

        // Do whatever setup needs to be done for player turn
        // enabling player buttons for example...


        // Decide which button to select:
        // if counter, counter
        // else jab

//        counterButton.GetComponent<Button>().Select();

    }

    public void playerSelect(int moveNum)
    {
        // DOES THE SELECTED ACTION WOO

        // disable all buttons object

        // do yield playerturn
        // after done all the stuff; set Playerturn to falso

    }

    public void yieldPlayerTurn()
    {
        turn.PlayerTurn = false;
        turn.EnemyTurn = true;
    }
}
