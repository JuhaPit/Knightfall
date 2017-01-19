using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent playerAgent;
    private bool hasInteracted;
    private Animation anim;

    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        hasInteracted = false;
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 3f;
        playerAgent.destination = this.transform.position;
        anim = GameObject.FindGameObjectWithTag("PlayerModel").transform.GetComponent<Animation>();
    }

    void Update()
    {
        if (!hasInteracted && playerAgent != null && !playerAgent.pathPending) {

            if (playerAgent.remainingDistance <= playerAgent.stoppingDistance) {

                anim.CrossFade("Idle1");
                Interact();
                hasInteracted = true;
            }

        }

    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with base class.");
    }
}
