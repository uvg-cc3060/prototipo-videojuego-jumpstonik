﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public int kills = 0;
    public Text Timer;
    public Text KillCont;
    public Image HealtBar;
    public Image MagicBar;
    public ThirdPersonCharacter player;
    private float secondsCount = 59;
    private int minuteCount = 9;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealtBar.fillAmount = player.life_Points / 100.0f;
        MagicBar.fillAmount = player.magic_Points / 100.0f;
        UpdateTimer();
    }
    public void UpdateTimer()
    {
        //set timer UI
        secondsCount -= Time.deltaTime;
        if (secondsCount <= 0)
        {
            minuteCount--;
            secondsCount = 59;
        }
        Timer.text = "0" + minuteCount + ":" + (int)secondsCount;

    }
    public void CountOfKills()
    {
        kills += 1;
        KillCont.text = kills + "";
    }
}