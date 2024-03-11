using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowWeapon : MonoBehaviour
{
    public float throwPower;
    private Rigidbody2D rigidBody2D;
    public float rotateSpeed;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

        rigidBody2D.velocity = new Vector2(Random.Range(-throwPower, throwPower), throwPower);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + (rotateSpeed * 360f * Time.deltaTime * Mathf.Sign(rigidBody2D.velocity.x)));
    }
}
