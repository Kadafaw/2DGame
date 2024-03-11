using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    public Projectile projectile;

    public float shotInterval = 2f;
    private float shotCounter;

    public float weaponRange;
    public LayerMask whatIsEnemy;
    public int daggerAmount = 1;

    private void Update()
    {
        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0)
        {
            shotCounter = shotInterval;

            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position,weaponRange *10,whatIsEnemy);

            if(enemies.Length>0)
            {
                for(int i = 0; i<daggerAmount;i++)
                {
                    Vector3 targetPosition = enemies[Random.Range(0, enemies.Length)].transform.position;

                    Vector3 direction = targetPosition - transform.position;

                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                    angle -= 90;
                    projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                    Instantiate(projectile, PlayerController.Instance.transform.position, projectile.transform.rotation).gameObject.SetActive(true);
                }
            }
        }
    }
}
