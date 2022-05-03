using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Collider2D))]
[RequireComponent(typeof(ActivateableGameObject))]

public class Button : MonoBehaviour
{
    [SerializeField] List<ActivateableGameObject> ActivateableGameObjects;
    [SerializeField] List<Activator> Activators;
    [SerializeField] Collider2D buttonTrigger;

    ActivateableGameObject thisActivatabelGameObject;


    private void Awake() 
    {
        thisActivatabelGameObject = GetComponent<ActivateableGameObject>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        thisActivatabelGameObject.SetFixedState(true);

        foreach (var activator in Activators)
        {
            if (buttonTrigger.IsTouching(activator.GetCollider()))
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
            if (buttonTrigger.IsTouching(activator.GetCollider()))
            {
                return;
            }
        }
        thisActivatabelGameObject.SetFixedState(false);
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
