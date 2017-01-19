using UnityEngine;
using System.Collections;
using System;

public class PlayerWeaponController : MonoBehaviour {

    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }
    public float range;
    public GameObject opponent;
    IWeapon equippedWeapon;
    CharacterStats characterStats;
    public bool attacking;
    Animation anim;

    void Start() {

        characterStats = GetComponent<CharacterStats>();
        attacking = false;
        anim = GameObject.FindGameObjectWithTag("PlayerModel").transform.GetComponent<Animation>();

    }

    public void EquipWeapon(Item itemToEquip) {

        if (EquippedWeapon != null) {

            characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);

        }

        EquippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
        equippedWeapon.Stats = itemToEquip.Stats;
        EquippedWeapon.transform.SetParent(playerHand.transform);
        characterStats.AddStatBonus(itemToEquip.Stats);
        Debug.Log(equippedWeapon.Stats[0].GetCalculatedStatValue());
    }
 
    void Update() {


        if (equippedWeapon != null && attacking == false) {

            EquippedWeapon.GetComponent<BoxCollider>().enabled = false;

        }

        if (equippedWeapon != null && attacking == true) {

            EnableWeaponCollider();

        }

        if (Input.GetMouseButtonDown(1) && attacking == false && anim.IsPlaying("Idle1") && InRange() && opponent.GetComponent<EnemyAI>().isDead == false) {

            if (opponent != null) {

                TurnTowardsEnemy();
            }

            attacking = true;
            PerformWeaponAttack();
            
        }

        ResetAttackingBool();

    }

    private void ResetAttackingBool()
    {
        if (!anim.IsPlaying("Attack1h1"))
        {

            attacking = false;
        }

    }

    public void PerformWeaponAttack()
    {

        equippedWeapon.PerformAttack();


    }

    void EnableWeaponCollider() {

        EquippedWeapon.GetComponent<BoxCollider>().enabled = true;

    }

    void TurnTowardsEnemy() {

        transform.LookAt(opponent.transform.position);
    }

    bool InRange() {

        if (opponent != null && Vector3.Distance(opponent.transform.position, transform.position) <= range)
        {

            return true;

        }

        else {

            return false;
        }

    }
    
}
