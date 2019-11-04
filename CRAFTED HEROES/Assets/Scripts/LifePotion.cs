﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class LifePotion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("estoy siendo tocado");
            if (other.gameObject.GetComponent<ThirdPersonCharacter>().life_Points >= 0 || other.gameObject.GetComponent<ThirdPersonCharacter>().life_Points <= 99)
            {
                other.gameObject.GetComponent<ThirdPersonCharacter>().life_Points += 10;
                if (other.gameObject.GetComponent<ThirdPersonCharacter>().life_Points > 100)
                {
                    other.gameObject.GetComponent<ThirdPersonCharacter>().life_Points = 100;
                }
            }

            Destroy(gameObject);
        }
    }
}