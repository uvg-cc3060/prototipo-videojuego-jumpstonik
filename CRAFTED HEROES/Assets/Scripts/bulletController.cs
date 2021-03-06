﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(gameObject, 3);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terreno" /*|| collision.gameObject.tag == "Golem" || collision.gameObject.tag == "Skeleton" || collision.gameObject.tag == "Flyer"*/)
        {
            Destroy(gameObject);
        }
    }
    
}
