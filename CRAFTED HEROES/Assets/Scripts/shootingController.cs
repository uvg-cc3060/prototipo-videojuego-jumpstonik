using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring)
        {
            Debug.Log("esta disparando");
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = timeBetweenShots;
                Debug.Log("sali");
                if (tipo == 1)
                {
                    
                    bulletController newBullet = Instantiate(bullet1, firePoint.position, firePoint.rotation) as bulletController;
                    newBullet.speed = bulletSpeed;
                }
                if (tipo == 2)
                {
                    bulletController newBullet = Instantiate(bullet2, firePoint.position, firePoint.rotation) as bulletController;
                    newBullet.speed = bulletSpeed;
                }
            }
            else
            {
                shotCounter = 0;
            }

        }
    }
}
