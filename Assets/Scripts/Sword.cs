using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Sword : MonoBehaviour, IWeapon
{
    public List<BaseStat> Stats { get; set; }
    public float baseAttackCost;
    [HideInInspector]
    private Animation anim;
    public GameObject player;

    void Start() {

        anim = GameObject.FindGameObjectWithTag("PlayerModel").transform.GetComponent<Animation>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void PerformAttack()
    {
        if (player.GetComponent<CharacterStamina>().CurrentStamina > baseAttackCost) 
        {
            anim.CrossFade("Attack1h1");
            player.GetComponent<CharacterStamina>().ReduceStamina(baseAttackCost);
   
        }

        else if (player.GetComponent<CharacterStamina>().CurrentStamina < baseAttackCost && anim.IsPlaying("Idle1")) {

            LowStaminaNotification();

        }
    }

    void OnTriggerEnter(Collider col) {

        if (col.tag == "Enemy")
        {

            col.GetComponent<IEnemy>().takeDamage(Stats[0].GetCalculatedStatValue());
        }


    }

    void LowStaminaNotification() {

        FloatingTextController.CreateFloatingText("Low Stamina", transform);
    }

}
