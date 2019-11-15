using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataScript : MonoBehaviour
{
    public static int kills = 0;
    public static int minutes = 0;
    public static float seconds = 0f;
    public Canvas UI;

    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.FindWithTag("UI").GetComponent<UnityEngine.Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (UI != null)
        {
        PlayerPrefs.SetInt("kills", UI.GetComponent<UIController>().kills);
        PlayerPrefs.SetInt("minutesLeft", UI.GetComponent<UIController>().minuteCount);
        PlayerPrefs.SetFloat("secondsLefts", UI.GetComponent<UIController>().secondsCount);

        }
    }
}
