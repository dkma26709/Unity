using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]

public class ActivateableGameObject : MonoBehaviour
{
    Collider2D[] stepColliders;
    SpriteRenderer _stepSprite;
    Light2D _light;
    ShadowCaster2D _shadow;

    [SerializeField] bool setLightWithState;
    [SerializeField] bool setShadowWithState;

    [SerializeField] Collider2D trigger;

    [SerializeField] bool fixedState = false;

    [SerializeField] public bool isPermanent = false;

    private void Awake()
    {
        stepColliders = GetComponents<Collider2D>();
        _stepSprite = GetComponent<SpriteRenderer>();
        _light = GetComponent<Light2D>();
        _shadow = GetComponent<ShadowCaster2D>();
    }

    public void SetState(bool state)
    {
        if (!isPermanent && !fixedState)
        {
            for (int i = 0; i < stepColliders.Length; i++)
            {
                stepColliders[i].enabled = state;
            }
            _stepSprite.enabled = state;
            if (setLightWithState && _light != null)
                _light.enabled = state;
            if (setShadowWithState && _shadow != null)
                _shadow.enabled = state;
        }
    }

    public void SetFixedState(bool state)
    {
        fixedState = state;
    }

    public Collider2D GetTriggerCollider()
    {
        return trigger;
    }
}
