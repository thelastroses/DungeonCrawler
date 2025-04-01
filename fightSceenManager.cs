using System;
using TMPro;
using UnityEngine;

public class fightSceneManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject player;
    public GameObject monster;
    private Fight theFight;
    private float timer = 0f;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI monsterHealthText;


    void Start()
    {
        theFight = new Fight(playerHealthText, monsterHealthText);
        theFight.SetUpFight();
        theFight.Health();
    }

    // Update is called once per frame
    void Update()
    {
        if (theFight.fightIsOver) return;

        timer += Time.deltaTime;

        if (timer >= 2f)
        {
            theFight.startFight(player, monster, false);
            timer = 0f;

        }
        

        if (Input.GetKeyDown(KeyCode.H))
        {
            theFight.HealPlayer();
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            theFight.startFight(player, monster, true);
        }
        
        theFight.Health();
    }
}