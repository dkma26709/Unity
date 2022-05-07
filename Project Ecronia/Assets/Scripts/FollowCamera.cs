using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
//This things position (camera) should be the same as the object to follow

    [SerializeField] GameObject thingToFollow;
    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0,0,-30);
    }

    public void SetFollowObject(GameObject ga)
    {
        thingToFollow = ga;
    }
}
