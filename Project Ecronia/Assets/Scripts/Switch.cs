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

        [SerializeField] AudioClip activationSound;
        [SerializeField] AudioClip deactivationSound;

        [SerializeField] bool activateOnTrigger = true;

        ActivateableGameObject thisActivatabelGameObject;

        AudioManager audioManager;


        private void Awake()
        {
            thisActivatabelGameObject = GetComponent<ActivateableGameObject>();
        }

        private void Start()
        {
            audioManager = FindObjectOfType<AudioManager>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {

            foreach (var activator in Activators)
            {
                if (switchTrigger.IsTouching(activator.GetCollider()))
                {
                    thisActivatabelGameObject.SetFixedState(activateOnTrigger);
                    SetActivatables(activateOnTrigger);
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
            thisActivatabelGameObject.SetFixedState(!activateOnTrigger);
            SetActivatables(!activateOnTrigger);
        }

        void SetActivatables(bool state)
        {
            if (state)
            {
                StartCoroutine(audioManager.PlaySound(activationSound));
            }
            else
            {
                StartCoroutine(audioManager.PlaySound(deactivationSound));
            }

            foreach (var AG in ActivateableGameObjects)
            {
                AG.SetState(state);
            }
        }
    }
}