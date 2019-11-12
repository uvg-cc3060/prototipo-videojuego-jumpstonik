using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComaBackMenu : MonoBehaviour
{
    public float countTime = 8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countTime -= Time.deltaTime;
        if(countTime <= 0)
        {
            back();
        }
    }

    public void back()
    {
        SceneManager.LoadScene("PantallaDeInicio");
    }
}
