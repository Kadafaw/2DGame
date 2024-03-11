using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    public float damageAmount;

    public bool shouldKnockback;

    public bool damageOverTime;
    public float timeBetweenDamage;
    private float damageCounter;
    private List<EnemyController> enemiseInRange = new List<EnemyController>();

    public float lifeTime = 5f;
    public bool destroyOnCountact;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(damageOverTime)
        {
            if (collision.CompareTag("Enemy"))
            {
                print("Zone Weapon Take Damage on Enemy");
                enemiseInRange.Add(collision.GetComponent<EnemyController>());
            }
        }
        else
        {
            if (collision.CompareTag("Enemy"))
            {
                print("Take Damage on Enemy");
                collision.GetComponent<EnemyController>().TakeDamage(damageAmount, shouldKnockback);

                if(destroyOnCountact)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(damageOverTime)
        {
            if(collision.CompareTag("Enemy"))
            {
                enemiseInRange.Remove(collision.GetComponent<EnemyController>());
            }
        }
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;

        if(lifeTime < 0)
        {
            Destroy(gameObject);
        }

        if(damageOverTime)
        {
            damageCounter -= Time.deltaTime;


            if(damageCounter <=0)
            {
                damageCounter = timeBetweenDamage;

                for(int i=0;i<enemiseInRange.Count;i++)
                {
                    if(enemiseInRange[i] !=null)
                    {
                        enemiseInRange[i].TakeDamage(damageAmount, shouldKnockback);
                    }
                    else
                    {
                        enemiseInRange.RemoveAt(i);
                        i--;
                    }
                }
            }
        }
    }
}
