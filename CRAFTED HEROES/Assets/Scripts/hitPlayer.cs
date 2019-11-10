using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class hitPlayer : MonoBehaviour
{
    public int damage = 0;
    //public GameObject target;
    // Start is called before the first frame update
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("me golpeo");
        if (collision.gameObject.tag == "Player")
        {
            ThirdPersonCharacter player = collision.gameObject.GetComponent<ThirdPersonCharacter>();
            Debug.Log("me golpeo el golem");
            if(player != null)
            {
                player.life_Points -= damage;
            }
        }
    }
}
