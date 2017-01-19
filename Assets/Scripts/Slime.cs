using UnityEngine;
using System.Collections;
using System;

public class Slime : MonoBehaviour, IEnemy {

    public float currentHealth, power, toughness;
    public float maxHealth;
    public float deathDelay;

    void Start() {

        FloatingTextController.Initialize();
        currentHealth = maxHealth;
    }

    public void PerformAttack()
    {
        throw new NotImplementedException();
    }

    public void takeDamage(int amount)
    {

        if (currentHealth > 0)
        {
            FloatingTextController.CreateFloatingText(amount.ToString(), transform);

        }

        currentHealth -= amount;

    }

    public void resetHealthtoFull() {

        currentHealth = maxHealth;

    }

}
