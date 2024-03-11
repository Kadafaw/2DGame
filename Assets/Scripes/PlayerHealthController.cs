using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    private float currentHealth;
    public float maxHealth;

    public Slider healthSlider;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentHealth = maxHealth;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10f);
            print("current health:" + currentHealth);
        }
    }

    public void TakeDamage(float damdgeToTake)
    {
        currentHealth -= damdgeToTake;

        if(currentHealth <=0)
        {
            gameObject.SetActive(false);

            Destroy(gameObject);
        }

        healthSlider.value = currentHealth;
    }
}
