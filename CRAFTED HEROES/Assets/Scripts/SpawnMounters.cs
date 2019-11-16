using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMounters : MonoBehaviour
{
    public Transform SpawnPosition;
    public GameObject Monster;
    private float time = 5f;
    private bool Stop = false;
    private int cont = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        time -= Time.deltaTime;
        if (Stop == true)
        {
            Destroy(gameObject);
        }
        if (time <= 0)
        {
            SpawnObject();
            cont += 1;
            if (cont == 5)
            {
                Stop = true;
            }
            time = 5;
        }
    }

    void SpawnObject()
    {
        Instantiate(Monster, SpawnPosition.position, SpawnPosition.rotation);
    }
}
