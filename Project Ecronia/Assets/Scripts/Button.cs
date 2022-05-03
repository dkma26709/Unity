using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Collider2D))]
[RequireComponent(typeof(ActivateableGameObject))]

public class Button : MonoBehaviour
{
    [SerializeField] List<ActivateableGameObject> ActivateableGameObjects;
    [SerializeField] List<Activator> Activators;
    [SerializeField] Collider2D trigger;

    ActivateableGameObject ag;


    private void Awake() 
    {
        ag = GetComponent<ActivateableGameObject>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        ag.SetFixedState(true);

        foreach (var activator in Activators)
        {
            if (trigger.IsTouching(activator.GetCollider()))
            {
                SetActivatables(true);
            }
            break;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        foreach (var activator in Activators)
        {
            if (trigger.IsTouching(activator.GetCollider()))
            {
                return;
            }
        }
        ag.SetFixedState(false);
        SetActivatables(false);
    }

    void SetActivatables(bool state)
    {
        foreach (var AG in ActivateableGameObjects)
        {
            AG.SetState(state);
        }
    }
}
