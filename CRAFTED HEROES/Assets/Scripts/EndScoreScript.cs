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
    public GameObject Data;
    private int calcul;
    private int total;

    // Start is called before the first frame update
    void Start()
    {
        Data = GameObject.FindWithTag("data");
        score();

        //Data = FindObjectOfType<DataScript>();
    }

    private void score()
    {
        if (Data != null)
        { /*
            calcul = Data.GetComponent<DataScript>().kills * 1000;
            total += calcul;
            killPoints.text = "1000 x " + Data.GetComponent<DataScript>().kills + " = " + calcul;
            calcul = Data.GetComponent<DataScript>().minutes * 5000;
            total += calcul;
            minutePoints.text = "1000 x " + Data.GetComponent<DataScript>().minutes + " = " + calcul;
            calcul = (int)Data.GetComponent<DataScript>().seconds * 50;
            total += calcul;
            secondsPoints.text = "1000 x " + (int)Data.GetComponent<DataScript>().seconds + " = " + calcul;
            totalScore.text = total.ToString();
            */
        }
    }
    public void LoadMenu()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene("SelectLevels");
    }

}
