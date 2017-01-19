using UnityEngine;
using System.Collections;

public class EnemyWeapon : MonoBehaviour {

    Slime enemyStats;
    float power;

	// Use this for initialization
	void Start () {

        enemyStats = GetComponentInParent<Slime>();
        power = enemyStats.power;
	
	}

    void OnTriggerEnter(Collider col) {

        if (col.tag == "Player" && col.GetComponent<CharacterHealth>().CurrentHealth > 0) {

            col.GetComponent<CharacterHealth>().DealDamage(power);

        }

    }
}
