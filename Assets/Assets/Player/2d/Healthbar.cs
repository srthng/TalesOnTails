using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider healthSlider;
    public float maxHealth;
    public float health;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            takeDamage(10);
        }
    }
    void takeDamage(float damage)
    {
        health -= damage;
    }

}
