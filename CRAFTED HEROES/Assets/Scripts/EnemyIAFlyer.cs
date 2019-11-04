using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIAFlyer : MonoBehaviour
{
    [Header("Enemy_Status")]
    public int lifePoints = 100;
    private bool alive = true;

    [Header("Potions")]
    public GameObject lifePotion;
    public GameObject magicPotion;
    public Transform spawnZone;

    [Header("Movement_Ajustes")]
    public int tiempo;
    public float speed;
    //public Transform PuntoGuarida;
    public Animator anim;
    bool Tiempodegiro;
    float y;

    [Header("Estados")]
    public bool Idle;
    public bool Atacar;
    public bool walk;
    public bool hit;
    public bool death;
    public int Estado = 1;
    public int RandTime;

    [Header("Nav_Ajustes")]
    public GameObject Target;
    public NavMeshAgent agent;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //agent.speed = 0;
        tiempo += 1;
        RandTime += 1;
        if (RandTime <= Random.Range(500, 550))
        { 
            changeStates(2);
        }
        else
        {
            changeStates(1);
            updateAnimations();
            if (RandTime >= 651)
            {
                RandTime = 0;
            }
        }

        if (lifePoints <= 0)
        {
            changeStates(5);
            updateAnimations();
            if (alive == true)
            {
                spawnPotions();
            }
            Destroy(gameObject,1.5f);
        }
        if (Idle == true)
        {
            changeStates(1);
            updateAnimations();

        } else if (Vector3.Distance(Target.transform.position, transform.position) < distance)
        {
            changeStates(2);
            updateAnimations();
            agent.SetDestination(Target.transform.position);
            agent.speed = 3;

            if (Vector3.Distance(Target.transform.position, transform.position) <= agent.stoppingDistance)
            {
                changeStates(3);
                updateAnimations();
            }

        }else if (walk == true)
        {
            updateAnimations();
            transform.Translate(transform.forward * speed * Time.deltaTime);
            transform.Rotate(new Vector3(0, y, 0));

            if(tiempo >= Random.Range(100, 2500))
            {
                Girar();
                tiempo = 0;
                
                Tiempodegiro = true;
            }

            if (Tiempodegiro == true)
            {
                if (tiempo >= Random.Range(50,100))
                {
                    y = 0;
                    //RandTime = 0;
                    Tiempodegiro = false;
                }
            }
        }
    }

    public void Girar()
    {
        y = Random.Range(-3, 3);
    }

    public void updateAnimations()
    {
        anim.SetBool("idle", Idle);
        anim.SetBool("walk", walk);
        anim.SetBool("hit", hit);
        anim.SetBool("attack", Atacar);
        anim.SetBool("death", death);
    }

    public void changeStates(int state)
    {
        Debug.Log(state);
        if (state == 1)
        {
            Idle = true;
            Atacar = false;
            walk = false;
            hit = false;
        }
        else if (state == 2)
        {
            Idle = false;
            Atacar = false;
            walk = true;
            hit = false;
        }
        else if (state == 3)
        {
            Idle = false;
            Atacar = true;
            walk = false;
            hit = false;
        }
        else if (state == 4)
        {
            Idle = false;
            Atacar = false;
            walk = false;
            hit = true;
        }
        else if (state == 5)
        {
            death = true;
        }
    }

    private void spawnPotions()
    {
        int posibility = Random.Range(0, 100);
        alive = false;
        if (posibility < 25)
        {
            Instantiate(lifePotion, spawnZone.position, spawnZone.rotation);
            Instantiate(magicPotion, spawnZone.position, spawnZone.rotation);
        }else if (posibility >= 25 && posibility < 50)
        {
            Instantiate(lifePotion, spawnZone.position, spawnZone.rotation);
        }
        else if (posibility >= 50 && posibility < 75)
        {
            Instantiate(magicPotion, spawnZone.position, spawnZone.rotation);
        }

    }
}
