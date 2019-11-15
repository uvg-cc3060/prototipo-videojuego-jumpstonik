using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public int kills = 0;
    public Text Timer;
    public Text KillCont;
    public Image HealtBar;
    public Image MagicBar;
    public ThirdPersonCharacter player;
    public float secondsCount = 19;
    public int minuteCount = 0;
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
        if (minuteCount <= 0 && secondsCount <= 0)
        {
            EndScreen();
        }
        //set timer UI
        secondsCount -= Time.deltaTime;
        if (secondsCount <= 0 && minuteCount >0)
        {
            minuteCount--;
            secondsCount = 59;
        }
        if (secondsCount <10)
        {
            Timer.text = "0" + minuteCount + ":0" + (int)secondsCount;
        }
        else { 
        Timer.text = "0" + minuteCount + ":" + (int)secondsCount;
        }

       
    }
    public void CountOfKills()
    {
        kills += 1;
        KillCont.text = kills + "";
    }
    public void EndScreen()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene("EndLevelScene");
    }
}
