using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeWeapon : MonoBehaviour
{
    private float throwCounter;
    private float timeBetweenAttacks = 2f;
    public EnemyDamager axeDamager;
    public int axeAmount = 1;

    private void Update()
    {
        throwCounter -= Time.deltaTime;

        if(throwCounter <= 0)
        {
            throwCounter = timeBetweenAttacks;

            for(int i = 0;i < axeAmount;i++)
            {
                Instantiate(axeDamager, axeDamager.transform.position, axeDamager.transform.rotation).gameObject.SetActive(true);
            }
        }
    }
}
