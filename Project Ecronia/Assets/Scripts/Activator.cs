using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Activator : MonoBehaviour
{
    Collider2D ActivationCollider;

    private void Awake()
    {
        ActivationCollider = GetComponent<Collider2D>();
    }

    public Collider2D GetCollider()
    {
        return ActivationCollider;
    }
}
