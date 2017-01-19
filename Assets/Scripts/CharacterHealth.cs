using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour {

    public float CurrentHealth { get; set; }
    public float MaxHealth { get; set; }

    public Slider healthBar;

    // Use this for initialization
    void Start () {

        MaxHealth = 20f;
        CurrentHealth = MaxHealth;
        healthBar.value = CalculateHealth();
	
	}
	
    public void DealDamage(float damageValue) {

        CurrentHealth -= damageValue;
        healthBar.value = CalculateHealth();

        if (CurrentHealth <= 0) {

            Die();
        }

    }

    float CalculateHealth() {

        return CurrentHealth / MaxHealth;
    }

    void Die() {

        CurrentHealth = 0;
        Debug.Log("You are dead!");

    }
}
