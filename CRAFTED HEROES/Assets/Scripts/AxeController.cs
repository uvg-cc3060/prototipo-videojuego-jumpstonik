using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{
    private Animator controlAnimator;
    public shootingController theGun;
    // Start is called before the first frame update
    void Start()
    {
        controlAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                controlAnimator.SetBool("fire", true);
                theGun.tipo = 1;
                theGun.isFiring = true;

            }
            else
            {
                controlAnimator.SetBool("fire", false);
                theGun.isFiring = false;

                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    controlAnimator.SetBool("ice", true);
                    theGun.tipo = 2;
                    theGun.isFiring = true;
                }
                else
                {
                    controlAnimator.SetBool("ice", false);
                    theGun.isFiring = false;
                }
            }

            

        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                controlAnimator.SetBool("verAttack", true);
            }
            else
            {
                controlAnimator.SetBool("verAttack", false);
            }

            if (Input.GetKey(KeyCode.Mouse1))
            {
                controlAnimator.SetBool("horAttack", true);
            }
            else
            {
                controlAnimator.SetBool("horAttack", false);
            }
        }
    }

    private void shooting(int num)
    {

    }
}
