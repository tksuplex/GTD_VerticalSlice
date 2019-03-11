using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unless denoted by a commented out link, TK wrote literally everything here

public class MatchTurnEnemy : MonoBehaviour
{
    public MatchTurn turn;
    public EnemyObject enemy;
    public PlayerObject player;

    public void doEnemyTurn()
    {
        Debug.Log("You are inside Enemy turn!");

        // If enemy was defending last turn; turn it off
        enemy.Guard = false;


        // this function implements AI to decide which move to take
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
