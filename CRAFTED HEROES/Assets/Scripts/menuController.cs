using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour
{
    public void Tutorial()
    {
        SceneManager.LoadScene("LoadingScreen");
    }
    public void Level1()
    {
        //SceneManager.LoadScene("PantallaDeInicio");
    }
    public void Cooperativo()
    {
        //SceneManager.LoadScene("PantallaDeInicio");
    }
    public void back()
    {
        SceneManager.LoadScene("PantallaDeInicio");
    }
}
