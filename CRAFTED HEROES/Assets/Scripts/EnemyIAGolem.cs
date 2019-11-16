using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyIAGolem : MonoBehaviour
{
    [Header("Enemy_Status")]
    public Rigidbody rb;
    public int lifePoints = 100;
    private bool alive = true;
    public GameObject hitBox;
    public Animator controlAnimator;

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
    public bool Atacar;
    public bool run;
    public bool death;
    public int Estado = 1;
    public int RandTime;

    [Header("Nav_Ajustes")]
    public GameObject Target;
    public NavMeshAgent agent;
    public float distance;

    [Header("Nav_Ajustes")]
    private Canvas UI;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UI = GameObject.FindWithTag("UI").GetComponent<UnityEngine.Canvas>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //agent.speed = 0;
        tiempo += 1;
        if (lifePoints <= 0)
        {
            changeStates(3);
            updateAnimations();
            if(alive == true) { 
                spawnPotions();
                UI.GetComponent<UIController>().CountOfKills();
            }
            Destroy(gameObject,0.5f);
        }

        if (Vector3.Distance(Target.transform.position, transform.position) < distance)
        {
            changeStates(1);
            updateAnimations();
            agent.SetDestination(Target.transform.position);
            agent.speed = 3;

            if (Vector3.Distance(Target.transform.position, transform.position) <= agent.stoppingDistance)
            {
                changeStates(2);
                updateAnimations();
            }

        }
        else if (run == true)
        {
            updateAnimations();
            transform.Rotate(new Vector3(0, y, 0));
            rb.velocity = transform.forward * speed;
            

            if (tiempo >= Random.Range(100, 2500))
            {
                Girar();
                tiempo = 0;

                Tiempodegiro = true;
            }

            if (Tiempodegiro == true)
            {
                if (tiempo >= Random.Range(50, 100))
                {
                    y = 0;
                    //RandTime = 0;
                    Tiempodegiro = false;
                }
            }
        }
        else
        {
            changeStates(1);
            updateAnimations();
        }
        if (controlAnimator.GetCurrentAnimatorStateInfo(0).IsName("atack") == true )
        {
            hitBox.SetActive(true);
            hitBox.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            hitBox.SetActive(false);
            hitBox.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void Girar()
    {
        y = Random.Range(-3, 3);
    }

    public void updateAnimations()
    {
        anim.SetBool("run", run);
        anim.SetBool("attack", Atacar);
        anim.SetBool("die", death);
    }

    public void changeStates(int state)
    {
        //Debug.Log(state);
        if (state == 1)
        {
            run = true;
            Atacar = false;
        }
        else if (state == 2)
        {
            run = false;
            Atacar = true;
        }
        else if (state == 3)
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
        }
        else if (posibility >= 25 && posibility < 50)
        {
            Instantiate(lifePotion, spawnZone.position, spawnZone.rotation);
        }
        else if (posibility >= 50 && posibility < 75)
        {
            Instantiate(magicPotion, spawnZone.position, spawnZone.rotation);
        }

    }
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "fireBall")
        {
            lifePoints -= 15;
        }
        if (collision.gameObject.tag == "iceBall")
        {
            lifePoints -= 15;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "metalHit")
        {
            lifePoints -= 2;
        }
        if(other.tag == "mangoHit")
        {
            lifePoints -= 1;
        }
        other.gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}