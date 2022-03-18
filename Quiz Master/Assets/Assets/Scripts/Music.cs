using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{

    GameObject[] musicObject;

void Start() 
{
    musicObject = GameObject.FindGameObjectsWithTag("GameMusic");    

    if (musicObject.Length == 1)
    {
        //play audio
    }
    else
    {
        for (int i = 1; i < musicObject.Length; i++)
        {
            Destroy(musicObject[i]);
        }
    }
}

void Awake() 
{
    DontDestroyOnLoad(this.gameObject);
}

}
