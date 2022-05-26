using System.Collections.Generic;
using UnityEngine;

public class ButtonBarrierActivator : MonoBehaviour
{
    [SerializeField] List<GameObject> barriers;
    bool barriersEnabaled = true;

    [SerializeField] Collider2D ButtonPressCollider;
    [SerializeField] Collider2D Player1Collider;
    [SerializeField] Collider2D Player2Collider;

    private void Update()
    {
        BarrierCheck();
    }

    void BarrierCheck()
    {
        if ((ButtonPressCollider.IsTouching(Player1Collider) || ButtonPressCollider.IsTouching(Player2Collider)) && barriersEnabaled)
            SetBarrierState(false);

        else if (!ButtonPressCollider.IsTouching(Player1Collider) && !ButtonPressCollider.IsTouching(Player2Collider) && !barriersEnabaled)
            SetBarrierState(true);
    }
    void SetBarrierState(bool state)
    {
        barriersEnabaled = state;
        foreach (var barrier in barriers)
        {
            barrier.GetComponent<SpriteRenderer>().enabled = state;
            barrier.GetComponent<Collider2D>().enabled = state;
        }
    }

    //-------------------------------------------------------------- Old Code ----------------------------------------- 
    // ---- Keeping it just for reference of other possible solutions




    // Bounds buttonColliderBounds;
    // private void Awake() 
    // {
    //     buttonColliderBounds = gameObject.GetComponent<Collider2D>().bounds;
    // }

    // private void Update() 
    // {
    //     // Button Vectors
    //     Vector3 ButtonCenter = gameObject.transform.position;
    //     Vector3 ButtonUpperLeftCorner = ButtonCenter - new Vector3(buttonColliderBounds.extents.x, 0 ,0) + new Vector3(0,buttonColliderBounds.extents.y,0);
    //     Vector3 ButtonUpperRighttCorner = ButtonCenter + new Vector3(buttonColliderBounds.extents.x, 0 ,0) + new Vector3(0,buttonColliderBounds.extents.y,0);

    //     // Ray Attributes
    //     Vector3 RayDirection = Vector2.right;
    //     float RayLength = (ButtonUpperRighttCorner - ButtonUpperLeftCorner).magnitude;
    //     Vector3 RayOrigin = ButtonUpperLeftCorner + new Vector3(0,0.1f,0) - new Vector3(RayLength,0,0);

    //     // Make the ray
    //     RaycastHit2D hit  = Physics2D.Raycast(RayOrigin, RayDirection, RayLength*2);

    //     // Draw the ray
    //     Debug.DrawLine(RayOrigin, RayOrigin + new Vector3( RayLength*2, 0,0), Color.red);

    //     // Barriers
    //     if (hit.collider != null)
    //     {
    //         if (hit.collider.tag == "Player" && barriersEnabaled)
    //         {
    //             barriersEnabaled = false;
    //             foreach (var barrier in barriers)
    //             {
    //                 barrier.GetComponent<SpriteRenderer>().enabled = false;
    //                 barrier.GetComponent<Collider2D>().enabled = false;
    //             }
    //         }
    //     }
    //     else
    //     {
    //         if (!barriersEnabaled)
    //         {
    //             barriersEnabaled = true;
    //             foreach (var barrier in barriers)
    //             {
    //                 barrier.GetComponent<SpriteRenderer>().enabled = true;
    //                 barrier.GetComponent<Collider2D>().enabled = true;
    //             }
    //         }
    //     }
    // }




    // private void OnCollisionEnter2D(Collision2D other) 
    // {
    //     if (other.gameObject.tag == "Player" && barriersEnabaled)
    //     {
    //         barriersEnabaled = false;
    //         foreach (var barrier in barriers)
    //         {
    //             barrier.GetComponent<SpriteRenderer>().enabled = false;
    //             barrier.GetComponent<Collider2D>().enabled = false;
    //         }
    //     }
    // }

    // private void OnCollisionExit2D(Collision2D other) 
    // {
    //     if (other.gameObject.tag == "Player" && !barriersEnabaled)
    //     {
    //         barriersEnabaled = true;
    //         foreach (var barrier in barriers)
    //         {
    //             barrier.GetComponent<SpriteRenderer>().enabled = true;
    //             barrier.GetComponent<Collider2D>().enabled = true;
    //         }
    //     }
    // }
}
