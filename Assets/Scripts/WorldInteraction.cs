using UnityEngine;
using System.Collections;

public class WorldInteraction : MonoBehaviour
{

    NavMeshAgent playerAgent;
    public GameObject model;
    Animation anim;
    PlayerWeaponController playerWeaponController;
    public Texture2D pointCursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        Cursor.SetCursor(pointCursorTexture, hotSpot, cursorMode);
        playerAgent = GetComponent<NavMeshAgent>();
        anim = model.GetComponent<Animation>();
        playerWeaponController = GetComponent<PlayerWeaponController>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {

            GetInteraction();

        }

        if (!playerAgent.pathPending && playerAgent.remainingDistance == 0 && playerWeaponController.attacking == false)
        {

            anim.CrossFade("Idle1");
        }


    }

    void GetInteraction()
    {

        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit interactionInfo;

        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {

            GameObject interactedObject = interactionInfo.collider.gameObject;
            if (interactedObject.tag == "Interactable Object")
            {
                anim.CrossFade("Walk");
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            }

            else
            {
                anim.CrossFade("Walk");
                playerAgent.stoppingDistance = 0;
                playerAgent.destination = interactionInfo.point;
            }
        }
    }

}
