using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBarrierActivator : MonoBehaviour
{
    [SerializeField] List<GameObject> barriers;

    Bounds buttonColliderBounds;

    bool barriersEnabaled = true;

    private void Awake() 
    {
        buttonColliderBounds = gameObject.GetComponent<Collider2D>().bounds;
    }

    //bool playerIsTouching = false;

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
    

    private void Update() 
    {
        Vector3 ButtonCenter = gameObject.transform.position;
        Vector3 ButtonUpperLeftCorner = ButtonCenter - new Vector3(buttonColliderBounds.extents.x, 0 ,0) + new Vector3(0,buttonColliderBounds.size.y *1/2,0);
        Vector3 ButtonUpperRighttCorner = ButtonCenter + new Vector3(buttonColliderBounds.extents.x, 0 ,0) + new Vector3(0,buttonColliderBounds.size.y*1/2,0);

        Vector3 RayDirection = Vector2.right;
        float RayLength = buttonColliderBounds.center.x - buttonColliderBounds.extents.x - buttonColliderBounds.center.x + buttonColliderBounds.extents.x;
        RaycastHit2D hit  = Physics2D.Raycast(ButtonCenter , RayDirection, RayLength);
        Debug.DrawRay(ButtonCenter, RayDirection * hit.distance, Color.red, 2f);
        Debug.DrawLine(ButtonUpperLeftCorner, ButtonUpperRighttCorner, Color.red);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player" && barriersEnabaled)
            {
                barriersEnabaled = false;
                foreach (var barrier in barriers)
                {
                    barrier.GetComponent<SpriteRenderer>().enabled = false;
                    barrier.GetComponent<Collider2D>().enabled = false;
                }
            }
        }
        else
        {
            if (!barriersEnabaled)
            {
                barriersEnabaled = true;
                foreach (var barrier in barriers)
                {
                    barrier.GetComponent<SpriteRenderer>().enabled = true;
                    barrier.GetComponent<Collider2D>().enabled = true;
                }
            }
        }
    }
}
