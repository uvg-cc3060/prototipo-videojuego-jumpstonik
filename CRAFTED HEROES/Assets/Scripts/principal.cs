using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class principal : MonoBehaviour
{

    public void SelectLevel()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene("SelectLevels");
    }

    public void Credits()
    {
        //Time.timeScale = 1f;
        SceneManager.LoadScene("CreditScreen");
    }

    public void Quit()
    {
        //SceneManager.LoadScene("PantallaDeInicio");
        Application.Quit();
    }
}
