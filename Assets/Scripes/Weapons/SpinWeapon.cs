using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWeapon : MonoBehaviour
{
    public float rotateSpeed;
    public Transform holder;
    public Transform fireballToSpawn;

    public int fireballAmount;

    private bool isFireBallGenerated = false;
    private void Update()
    {
        holder.rotation = Quaternion.Euler(0,0,holder.rotation.eulerAngles.z+(rotateSpeed*Time.deltaTime));
        if(!isFireBallGenerated)
        {
            for(int i =0;i< fireballAmount;i++)
            {
                float rot = 360f / fireballAmount * i;
                Instantiate(fireballToSpawn, fireballToSpawn.position,Quaternion.Euler(0f,0f,rot), holder).gameObject.SetActive(true);
            }

            isFireBallGenerated = true;
        }
    }
}
