using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    static AudioPlayer instance;

    AudioSource audioSource;

    [SerializeField] AudioClip mainMenuMusic;
    [SerializeField] AudioClip inGameMusic;
    [SerializeField] AudioClip gameOverMusic;
    void Awake()
    {
        ManageSingleton();
        audioSource = instance.GetComponent<AudioSource>();
    }
    private void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayAudioClip(AudioClip audio, float volume)
    {
        AudioSource.PlayClipAtPoint(audio, Camera.main.transform.position, volume);
    }

    public void PlayMainMenuMusic()
    {
        audioSource.Stop();
        audioSource.clip = mainMenuMusic;
        audioSource.Play();
        //PlayAudioClip(mainMenuMusic, 0.5f);
    }

    public void PlayGameOverMusic()
    {
                audioSource.Stop();
        audioSource.clip = gameOverMusic;
        audioSource.Play();
        //PlayAudioClip(gameOverMusic, 0.5f);
    }

    public void PlayInGameMusic()
    {
                audioSource.Stop();
        audioSource.clip = inGameMusic;
        audioSource.Play();
        //PlayAudioClip(inGameMusic, 0.5f);
    }
}
