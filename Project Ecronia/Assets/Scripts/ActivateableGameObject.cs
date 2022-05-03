using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class ActivateableGameObject : MonoBehaviour
{
    Collider2D[] StepColliders;
    SpriteRenderer StepSprite;

    [SerializeField] bool fixedState = false;

    [SerializeField] public bool isInitial = false;

    private void Awake()
    {
        StepColliders = GetComponents<Collider2D>();
        StepSprite = GetComponent<SpriteRenderer>();
    }

    public void SetState(bool state)
    {
        if (!isInitial && !fixedState)
        {
            for(int i = 0; i < StepColliders.Length; i++)
            {
                StepColliders[i].enabled = state;
            }
            StepSprite.enabled = state;
        }
    }

    public void SetFixedState(bool state)
    {
        fixedState = state;
    }
}
