using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterStamina : MonoBehaviour
{

    public float CurrentStamina { get; set; }
    public float MaxStamina { get; set; }
    public float rechargeRate;

    public Slider staminaBar;

    // Use this for initialization
    void Start()
    {

        MaxStamina = 20f;
        CurrentStamina = MaxStamina;
        rechargeRate = 0.02f;

        staminaBar.value = CalculateStamina();

    }

    // Update is called once per frame
    void Update()
    {

        if (CurrentStamina < MaxStamina) {

            CurrentStamina += rechargeRate;
            staminaBar.value = CalculateStamina();
        }

    }

    public void ReduceStamina(float value)
    {

        CurrentStamina -= value;
        staminaBar.value = CalculateStamina();

        if (CurrentStamina <= 0)
        {

            CurrentStamina = 0;
        }

    }

    float CalculateStamina()
    {

        return CurrentStamina / MaxStamina;
    }

}
