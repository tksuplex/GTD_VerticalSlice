using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// Unless denoted by a commented out link, TK wrote literally everything here

public class EnemyObject : MonoBehaviour
{
    public SavePrefs prefs;
    public PlayerObject player;
    public MoveSetScript moveSet;

    public Image HPbar;

    [HideInInspector]
    public int PlayerRank, MaxHP, HP, MaxSP, SP, PWR, SPD, TGH;

    // DEF = % of enemy attack damage can be mitigated by player
    // DMG = % of attacks base damage can be used by player
    // EVA = % chance of evading enemy attack
    // LCK = % chance of a critical attack (DMG*1.5)
    // REC = % of HP/SP recovered when using Recovery Move
    // CounterChance = % chance of generating a counter
    [HideInInspector]
    public float HPpercent, DMG, DEF, EVA, LCK, REC, CounterChance;

    // Special abilities player can learn by ranking up & spending EXP
    public bool SundayPunch;
    public bool ButterBee;
    public bool DynamiteBlow;

    // I might have to change/move these idk...
    public int Guard;
    public int Evasion;
    public int Miss;
    public int Dazed;
    public bool KO;

    // Stores player's previous moves including things like missing the enemy;
    public int prevMove;

    // Start is called before the first frame update
    void Start()
    {
        // Call function to populate Player Object with correct values
        populateEnemyObject();
        displayEnemyStats();
    }

    public void populateEnemyObject()
    {
        prevMove = -1; // Previous move doesn't exist because just started
        if (prefs.GetPrefBool("Sparring"))
        {
            // If training, populate with player's stats -1 each
            populateSparringEnemyObject();
        }
        else
        {
            PlayerRank = prefs.GetPref("PlayerRank");
            if (PlayerRank >= 3)
            {
                populateRank2EnemyObject();
            }
            if (PlayerRank == 2)
            {
                populateRank1EnemyObject();
            }
            else
            {
                populateRankCEnemyObject();
            }
        }
    }

    void populateRank2EnemyObject()
    {
        PWR = 10;
        SPD = 4;
        TGH = 7;

        player.populateDerivedValues();

        SundayPunch = true;
        ButterBee = false;
        DynamiteBlow = false;
    }

    void populateRank1EnemyObject()
    {
        PWR = 6;
        SPD = 10;
        TGH = 6;

        player.populateDerivedValues();

        SundayPunch = false;
        ButterBee = true;
        DynamiteBlow = false;
    }

    void populateRankCEnemyObject()
    {
        PWR = 10;
        SPD = 3;
        TGH = 12;

        player.populateDerivedValues();

        SundayPunch = false;
        ButterBee = false;
        DynamiteBlow = true;
    }

    public void populateSparringEnemyObject()
    {
        PWR = prefs.GetPref("PlayerPower");
        SPD = prefs.GetPref("PlayerSpeed");
        TGH = prefs.GetPref("PlayerTough");
        PWR--;
        SPD--;
        TGH--;

        player.populateDerivedValues();

        SundayPunch = false;
        ButterBee = false;
        DynamiteBlow = false;
    }

    void displayEnemyStats()
    {
        Debug.Log("Enemy Values:");
        player.consoleStats();
    }

    public void updateEnemyBar()
    {
        HPpercent = (float)HP / MaxHP;

        HPbar.fillAmount = HPpercent;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
