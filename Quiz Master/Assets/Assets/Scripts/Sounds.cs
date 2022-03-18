using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{

    [SerializeField] AudioClip ButtonSound;

public void PlayButtonSound()
{
    GetComponentInChildren<AudioSource>().PlayOneShot(ButtonSound);
}
}
