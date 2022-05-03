using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step : MonoBehaviour
{
    [SerializeField] Step NextStep;

    [SerializeField] Step PriorStep;

    [SerializeField] Collider2D ActivationCollider;

    [SerializeField] bool InitialStep = false;

    Collider2D[] StepColliders;
    SpriteRenderer StepSprite;

    private void Awake()
    {
        StepColliders = GetComponents<Collider2D>();
        StepSprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.Equals(ActivationCollider))
        {
            if (NextStep != null)
            {
                NextStep.SetStepState(true);
            }

            if (PriorStep != null)
            {
                PriorStep.SetStepState(true);
                
                if (PriorStep.PriorStep != null)
                {
                    if (!PriorStep.PriorStep.InitialStep)
                    {
                        PriorStep.PriorStep.SetStepState(false);
                    }
                }
            }
        }
    }

    public void SetStepState(bool state)
    {
        for(int i = 0; i < StepColliders.Length; i++)
        {
            StepColliders[i].enabled = state;
        }
         StepSprite.enabled = state;
    }
}
