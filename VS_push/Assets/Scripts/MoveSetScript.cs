using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// Unless denoted by a commented out link, TK wrote literally everything here

public class MoveSetScript : MonoBehaviour
{

    public EnemyObject enemy;
    public PlayerObject player;
    public MatchTurn turn;

    int[] moveSetDMG = new int[11];
    int[] moveSetCost = new int[11];

    // -----------------------------------------------------------------------//

    /*
     * LIST OF MOVES POSSIBLE:
     * 0 Counter
     * 1 Jab
     * 2 Straight / Light Attack
     * 3 Hook / Heavy Attack
     * 4 Sunday Punch / Crit chance
     * 5 Dynamite Blow / Dazes enemy
     * 6 Guard / Halves Damage 1 turn
     * 7 Recover / +% of HP & SP
     * 8 ButterBee +EVA for 3 turns, does not stack
     * 9 Miss / Missed Oponent
     * 10 Dazed / Dazed by enemy cannot attack
     */

    //      public int[] moveSetDMG = new int[11];
    //    List<int> moveSetDMG = new List<int>();
    //    List<int> moveSetCost = new List<int>();

    // -----------------------------------------------------------------------//

    // Start is called before the first frame update
    void Start()
    {
        setUpMoveSet();
    }

    public void setUpMoveSet()
    {
        moveSetDMG[0] = 20; // counter base damage
        moveSetDMG[1] = 5; // jab
        moveSetDMG[2] = 15; // straight / light
        moveSetDMG[3] = 25; // hook / heavy
        moveSetDMG[4] = 30; // sunday
        moveSetDMG[5] = 40; // dynamite
        moveSetDMG[6] = 0; // guard
        moveSetDMG[7] = 0; // recover
        moveSetDMG[8] = 0; // butterbee
        moveSetDMG[9] = 0; // miss
        moveSetDMG[10] = 0; // dazed

        moveSetCost[0] = 6; // counter
        moveSetCost[1] = 0; // jab
        moveSetCost[2] = 2; // straight /light
        moveSetCost[3] = 4; // hook / heavy
        moveSetCost[4] = 8; // sunday
        moveSetCost[5] = 10; // dynamite
        moveSetCost[6] = 2; // guard
        moveSetCost[7] = 4; // recover
        moveSetCost[8] = 6; // butterbee
        moveSetCost[9] = 0; // miss
        moveSetCost[10] = 0; // dazed

    }

public int getMoveBaseDMG(int moveNum)
    {
        if (moveNum < 6 && moveNum >= 0)
        {
            return moveSetDMG[moveNum];
        }
        else return 0;
    }

    public int getMoveSetCost(int moveNum)
    {
        if (moveNum < 10 && moveNum >= 0)
        {
            Debug.Log("in get move set cost for move number: " + moveNum);
            Debug.Log("the cost is : " + moveSetCost[2]);
            return moveSetCost[moveNum];
        }
        else return -1;
    }

    public int getHPrecover(int moveNum)
    {
        return 0;
    }

    public void doMove(int moveNum)
    {
        int baseDMG = getMoveBaseDMG(moveNum);
        int costSP = getMoveSetCost(moveNum);

        if (turn.PlayerTurn)
        {
            Debug.Log("it is player's turn!");
            player.HP -= baseDMG;
            enemy.HP -= baseDMG;
            player.SP -= costSP;
            player.updatePlayerBar();
            enemy.updateEnemyBar();
            turn.PlayerTurn = false;
            turn.EnemyTurn = true;
        }
        else
        {
            Debug.Log("it is enemy's turn!");
        }


    }




    public void testPunchPlayer()
    {
        // moveNum, false=enemyTurn, true=playerTurn
        doMove(0);

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
