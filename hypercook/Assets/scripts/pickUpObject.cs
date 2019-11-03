using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpObject : MonoBehaviour
{
    public GameObject ObjectToPickup;
    public GameObject PickedObject;
    public GameObject Table;
    public Transform interactionZone;

    // Update is called once per frame
    void Update()
    {
        if (ObjectToPickup != null && ObjectToPickup.GetComponent<pickableObject>().isPickable == true && PickedObject == null)
        {
            
            if (Input.GetKeyDown(KeyCode.F))
            {
                PickedObject = ObjectToPickup;
                PickedObject.GetComponent<pickableObject>().isPickable = false;
                PickedObject.transform.SetParent(interactionZone);
                Vector3 post = new Vector3((float)0.0, (float)0.0, (float)-0.25);
                PickedObject.transform.position = interactionZone.position + post;
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
                if (Table != null && Table.GetComponent<PutableObject>().CanIPut == false)
                {
                    Table.GetComponent<PutableObject>().CanIPut = true;
                }
            }
        }
        else if(PickedObject != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (Table != null && Table.GetComponent<PutableObject>().CanIPut == true)
                {
                    
                    PickedObject.transform.SetParent(Table.GetComponent<PutableObject>().place);
                    Table.GetComponent<PutableObject>().ObjectOn = PickedObject;
                    PickedObject.GetComponent<pickableObject>().isPickable = true;
                    PickedObject.transform.position = Table.GetComponent<PutableObject>().place.position;
                    Table.GetComponent<PutableObject>().CanIPut = false;
                    PickedObject = null;
                }
                else { 
                PickedObject.GetComponent<pickableObject>().isPickable = true;
                PickedObject.transform.SetParent(null);
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                PickedObject = null;
            }

            }
        }
    }
}
