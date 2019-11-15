using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScoreScript : MonoBehaviour
{
    public Text killPoints;
    public Text secondsPoints;
    public Text minutePoints;
    public Text totalScore;
    private int calcul;
    private int total;
    private float time = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
        score();

        //Data = FindObjectOfType<DataScript>();
    }

    private void score()
    {
     
        calcul = PlayerPrefs.GetInt("kills",0) * 1000;
        total += calcul;
        killPoints.text = "1000 x " + PlayerPrefs.GetInt("kills", 0) + " = " + calcul;
        calcul = PlayerPrefs.GetInt("minutesLeft", 0) * 5000;
        total += calcul;
        minutePoints.text = "5000 x " + PlayerPrefs.GetInt("minutesLeft", 0) + " = " + calcul;
        calcul = (int)PlayerPrefs.GetInt("secondsLeft", 0) * 50;
        total += calcul;
        secondsPoints.text = "50 x " + (int)PlayerPrefs.GetInt("secondsLeft", 0) + " = " + calcul;
        totalScore.text = total.ToString();
        PlayerPrefs.DeleteAll();
     
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            SceneManager.LoadScene("SelectLevels");
        }
    }


}
