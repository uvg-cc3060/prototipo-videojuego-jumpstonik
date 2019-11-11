using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesHealtBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image HealtBar;
    public GameObject enemy;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemy.tag == "Golem")
        {
            HealtBar.fillAmount = enemy.GetComponent<EnemyIAGolem>().lifePoints / 100.0f;
        }
        if (enemy.tag == "Flyer")
        {
            HealtBar.fillAmount = enemy.GetComponent<EnemyIAFlyer>().lifePoints / 100.0f;
        }
        if (enemy.tag == "Skeleton")
        {
            HealtBar.fillAmount = enemy.GetComponent<EnemyIASkeleton>().lifePoints / 100.0f;
        }
        
    }
}
