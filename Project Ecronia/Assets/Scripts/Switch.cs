using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider2D), typeof(Collider2D))]
    [RequireComponent(typeof(ActivateableGameObject))]
    public class Switch : MonoBehaviour
    {
        [SerializeField] List<ActivateableGameObject> ActivateableGameObjects;
        [SerializeField] List<Activator> Activators;
        [SerializeField] Collider2D switchTrigger;

        ActivateableGameObject thisActivatabelGameObject;


        private void Awake()
        {
            thisActivatabelGameObject = GetComponent<ActivateableGameObject>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {

            foreach (var activator in Activators)
            {
                if (switchTrigger.IsTouching(activator.GetCollider()))
                {
                    thisActivatabelGameObject.SetFixedState(true);
                    SetActivatables(true);
                    break;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            foreach (var activator in Activators)
            {
                if (switchTrigger.IsTouching(activator.GetCollider()))
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
}