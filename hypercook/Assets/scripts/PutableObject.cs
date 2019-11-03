using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutableObject : MonoBehaviour
{
    public bool CanIPut = true;
    public GameObject ObjectOn;
    public Transform place;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider any)
    {
        if (any.tag == "PlayerInteractionZone")
        {
            any.GetComponentInParent<pickUpObject>().Table = this.gameObject;
        }
    }
    private void OnTriggerExit(Collider any)
    {
        if (any.tag == "PlayerInteractionZone")
        {
            any.GetComponentInParent<pickUpObject>().Table = null;
        }
    }
}
    
