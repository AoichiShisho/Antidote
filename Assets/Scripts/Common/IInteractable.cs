using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class IInteractable : MonoBehaviour
{
    public bool isPlayerInContact = false;
    private Vector3 InteractPosition;
    private bool InteractionOngoing;
    private static float MAX_INTERACTION_DISTANCE = .1f;
    private static float CHECK_LIVENESS_SECS = .5f;
    private IEnumerator LivenessCheck;

    private Vector3 GetPlayerPosition()
    {
        return GameObject.FindWithTag("Player").transform.position;
    }

    private IEnumerator CheckLiveness()
    {
        while (InteractionOngoing) {
            if (!isPlayerInContact && (GetPlayerPosition() - InteractPosition).magnitude > MAX_INTERACTION_DISTANCE) break;
            yield return new WaitForSeconds(CHECK_LIVENESS_SECS);
        }
        StopInteraction();
    }


    protected virtual bool IsPlayerInteracting()
    {
        return isPlayerInContact && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.E));
    }

    public virtual void Update()
    {
        if (IsPlayerInteracting()) 
        {
            DoInteraction();
        }
    }

    protected virtual void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInContact = true;
            InteractSign.Instance.Show();
        }
    }

    protected virtual void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInContact = false;
            InteractSign.Instance.Hide();
        }
    }

    public virtual void DoInteraction()
    {
        InteractionOngoing = true;
        InteractPosition = GetPlayerPosition();
        LivenessCheck = CheckLiveness();
        StartCoroutine(LivenessCheck);
    }

    public virtual void StopInteraction() {
        InteractionOngoing = false;
        StopCoroutine(LivenessCheck);
    }
}
