using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    public float moveSpeed;
    private Transform target;

    public float health;

    public float knockBackTime = .5f;
    private float konckBackCounter;

    public float damage;
    public float hitWaitTime = 1f;
    private float hitCounter;

    private Vector3 PositiveVectorOne = new Vector3(1, 1, 1);
    private Vector3 NegativeVectorOne = new Vector3(-1, 1, 1);

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

        if(FindObjectOfType<PlayerController>() !=null)
        {
            target = FindObjectOfType<PlayerController>().transform;
        }
    }

    private void Update()
    {
        if(PlayerController.Instance !=null)
        {
            Vector3 direction = target.position - transform.position;

            if (direction.x < 0)
            {
                transform.localScale = PositiveVectorOne;
            }
            else
            {
                transform.localScale = NegativeVectorOne;
            }

            rigidBody2D.velocity = (target.position - transform.position).normalized * moveSpeed;

            if (hitCounter > 0f)
            {
                hitCounter -= Time.deltaTime;
            }

            if (konckBackCounter > 0)
            {
                konckBackCounter -= Time.deltaTime;

                if (moveSpeed > 0)
                {
                    moveSpeed = -moveSpeed * 2f;
                }

                if (konckBackCounter <= 0)
                {
                    moveSpeed = Mathf.Abs(moveSpeed * 0.5f);
                }
            }
        }
    }

        

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && hitCounter > 0)
        {
            DamageHappen();
            hitCounter = hitWaitTime;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")&& hitCounter<=0)
        {
            DamageHappen();
            hitCounter = hitWaitTime;
        }
    }

    public void TakeDamage(float damageToTake)
    {
        health -= damageToTake;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damageToTake,bool shouldKnockback)
    {
        TakeDamage(damageToTake);

        if(shouldKnockback)
        {
            konckBackCounter = knockBackTime;
        }
    }

    private void DamageHappen()
    {
        PlayerHealthController.instance.TakeDamage(damage);
    }
}
