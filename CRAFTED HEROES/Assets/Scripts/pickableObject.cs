using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickableObject : MonoBehaviour
{
    public bool isPickable = true;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerInteractionZone")
        {
            other.GetComponentInParent<pickUpObject>().ObjectToPickup = this.gameObject;
        }
    }
}
