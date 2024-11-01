using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider StaminaSlider;
    public float maxStamina;
    public float stamina;

    private void Start()
    {
        stamina = maxStamina;
    }

    private void Update()
    {
        if (StaminaSlider.value != stamina)
        {
            StaminaSlider.value = stamina;
        }
        if (stamina > 9)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                useStamina(10);
            }
        }
    }
    void useStamina(float damage)
    {
        stamina -= damage;
    }
}
