using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class shootingController : MonoBehaviour
{
    public bool isFiring = false;
    public int tipo = 0;
    public bulletController bullet1;
    public bulletController bullet2;
    public float bulletSpeed;

    public float timeBetweenShots;
    private float shotCounter;

    public Transform firePoint;
    private ThirdPersonCharacter player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<ThirdPersonCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        shotCounter -= Time.deltaTime;
        if (isFiring)
        {
            Debug.Log(shotCounter);
            
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                //Debug.Log("sali");
                if (tipo == 1)
                {
                    if (player.magic_Points >= 5)
                    {
                        //Vector3 ajuste = new Vector3(1.2f, 0.0f, 0.0f);
                        Vector3 ajuste = new Vector3(0.0f, -2.0f, -0.2f);
                        bulletController newBullet = Instantiate(bullet1, firePoint.position + ajuste, firePoint.rotation) as bulletController;
                        newBullet.speed = bulletSpeed;
                        player.magic_Points -= 5;

                    }
                    //Debug.Log("fuego");
                }
                if (tipo == 2)
                {
                    if (player.magic_Points >= 10)
                    {
                        //Vector3 ajuste = new Vector3(0.7f, -1.0f, -1.1f);
                        Vector3 ajuste = new Vector3(0.0f, 0.0f, 0.0f);
                        bulletController newBullet = Instantiate(bullet2, firePoint.position + ajuste, firePoint.rotation) as bulletController;
                        newBullet.speed = bulletSpeed;
                        //Debug.Log("hielo");
                        player.magic_Points -= 10;

                    }
                }
            }
            else
            {
                shotCounter = 0;
            }

        }
    }
}
