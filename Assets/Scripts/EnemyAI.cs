using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public float distanceFromTarget;
    public float distanceFromBase;
    public float resetDistance;
    public float aggroDistance;
    public Vector3 spawnLocation;
    public Transform target;
    private NavMeshAgent navComponent;
    public bool returning;
    public bool isMoving;
    public bool isDead;
    public GameObject model;
    Slime enemyStats;
    public Texture2D attackCursorTexture;
    public Texture2D pointCursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

	// Use this for initialization
	void Start () {

        target = GameObject.FindGameObjectWithTag("Player").transform;
        navComponent = this.gameObject.GetComponent<NavMeshAgent>();
        spawnLocation = transform.position;
        resetDistance = 15f;
        aggroDistance = 10f;
        returning = false;
        isMoving = false;
        isDead = false;
        enemyStats = GetComponent<Slime>();
	}
	
	// Update is called once per frame
	void Update () {

        distanceFromTarget = Vector3.Distance(target.position, transform.position);
        distanceFromBase = Vector3.Distance(spawnLocation, transform.position);

        if (distanceFromBase < 1 && isDead == false)
        {

            returning = false;
            isMoving = false;
            model.GetComponent<Animation>().CrossFade("combat_idle");

        }

        if (distanceFromTarget < aggroDistance && returning == false && isDead == false)
        {

            Chase();
        }

        if (distanceFromBase > resetDistance && returning == false && isDead == false)
        {

            navComponent.stoppingDistance = 0;
            returnToSpawn();

        }

        if (enemyStats.currentHealth <= 0) {

            Die();
        }

    }

    void returnToSpawn() {

        returning = true;
        isMoving = true;
        enemyStats.resetHealthtoFull();
        navComponent.SetDestination(spawnLocation);

    }

    void Chase() {

        model.transform.LookAt(target.position);
        navComponent.SetDestination(target.position);
        navComponent.stoppingDistance = 2f;

        if ((distanceFromTarget - 0.5f) <= navComponent.stoppingDistance && target.GetComponent<CharacterHealth>().CurrentHealth > 0)
        {

            isMoving = false;
            model.GetComponent<Animation>().CrossFade("attack4");

        }

        else if ((distanceFromTarget - 0.5f) <= navComponent.stoppingDistance && target.GetComponent<CharacterHealth>().CurrentHealth <= 0) {

            model.GetComponent<Animation>().CrossFade("combat_idle");

        }

        else
        {

            isMoving = true;
            model.GetComponent<Animation>().CrossFade("run");

        }


    }

    void Die() {

        isDead = true;
        model.GetComponent<Animation>()["death"].wrapMode = WrapMode.ClampForever;
        model.GetComponent<Animation>().CrossFade("death");
        Destroy(gameObject, enemyStats.deathDelay);


    }

    void OnMouseOver() {


        if (isDead == false)
        {
            target.GetComponent<PlayerWeaponController>().opponent = gameObject;
            Cursor.SetCursor(attackCursorTexture, hotSpot, cursorMode);

        }

        if (isDead == true) {

            Cursor.SetCursor(pointCursorTexture, hotSpot, cursorMode);

        }

    }

    void OnMouseExit() {

        target.GetComponent<PlayerWeaponController>().opponent = null;
        Cursor.SetCursor(pointCursorTexture, hotSpot, cursorMode);
    }

}