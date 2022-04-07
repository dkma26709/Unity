using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public void PlayAudioClip(AudioClip audio, float volume)
    {
        AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position, volume);
    }
}
