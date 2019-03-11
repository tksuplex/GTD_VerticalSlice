using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Unless denoted by a commented out link, TK wrote literally everything here

public class PlayerObject : MonoBehaviour
{
    public SavePrefs prefs;
    public Image HPbar;
    public Image SPbar;
    float HPpercent;
    float SPpercent;

    public bool KO;

    public int MaxHP;
    public int HP;
    public int MaxSP;
    public int SP;
    public int PWR;
    public int SPD;
    public int TGH;

    // DEF = % of enemy attack damage can be mitigated by player
    // DMG = % of attacks base damage can be used by player
    // EVA = % chance of evading enemy attack
    // LCK = % chance of a critical attack (DMG*1.5)
    // REC = % of HP/SP recovered when using Recovery Move
    public float DMG;
    public float DEF;
    public float EVA;
    public float LCK;
    public float REC;

    // Special abilities player can learn by ranking up & spending EXP
    public bool SundayPunch;
    public bool ButterBee;
    public bool DynamiteBlow;

    // I might have to change/move these idk...
    public bool Guard;
    public bool Evasion;
    public bool Miss;
    public bool Dazed;

    // Set the default attack number for offensive moves
    public int baseJab;
    public int baseLightAttack; // 'Straight' on player menu
    public int baseHeavyAttack; // 'Hook' on player menu
    public int baseCounter;
    public int baseSunday;

    // Stores player's previous moves including things like missing the enemy;
    public string prevMove;

    // Start is called before the first frame update
    void Start()
    {
        // Call function to populate Player Object with correct values
        populatePlayerObject();
        displayPlayerStats();
    }

    public void populatePlayerObject()
    {
        PWR = prefs.GetPref("PlayerPower");
        SPD = prefs.GetPref("PlayerSpeed");
        TGH = prefs.GetPref("PlayerTough");
        SundayPunch = prefs.GetPrefBool("NewAbility1");
        ButterBee = prefs.GetPrefBool("NewAbility2");
        DynamiteBlow = false;

        populateDerivedValues();
    }

    void populateDerivedValues()
    {
        MaxSP = (int)(PWR * 10);
        SP = MaxSP;
        MaxHP = (int)((TGH * 100) / 2);
        HP = MaxHP;

        DMG = ((float)PWR * 10) / 100;
        DEF = ((float)TGH * 10) / 200;
        EVA = ((float)SPD * 10) / 300;
        LCK = ((float)PWR + TGH + (2 * SPD)) / 200;
        REC = (float)SPD / 200;
    }

    void displayPlayerStats()
    {
        Debug.Log("Player Values:");
        Debug.Log("HP: " + MaxHP);
        Debug.Log("SP: " + MaxSP);
        Debug.Log("PWR: " + PWR);
        Debug.Log("SPD: " + SPD);
        Debug.Log("TGH: " + TGH);
        Debug.Log("DMG %: " + DMG);
        Debug.Log("EVA %: " + EVA);
        Debug.Log("LCK %: " + LCK);
        Debug.Log("REC %: " + REC);

        Debug.Log("Sunday: " + SundayPunch);
        Debug.Log("ButterBee: " + ButterBee);
        Debug.Log("Dynamite: " + DynamiteBlow);
    }

    public void updatePlayerBar()
    {
        HPpercent = (float)HP / MaxHP;
        SPpercent = (float)SP / MaxSP;

        HPbar.fillAmount = HPpercent;
        SPbar.fillAmount = SPpercent;
    }

// Update is called once per frame
void Update()
    {
        // DELETE!
//        Debug.Log("Player HP: " + HP + "/" + MaxHP);
       
        
    }
}
