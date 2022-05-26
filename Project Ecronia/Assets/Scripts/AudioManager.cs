using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] AudioClip MainMusic;

    private void Start()
    {
        List<AudioManager> audioManagers = FindObjectsOfType<AudioManager>().ToList();
        if (audioManagers.Count > 1)
            Destroy(this.gameObject);

        else
            DontDestroyOnLoad(this.gameObject);
    }

    public IEnumerator PlaySound(AudioClip audioClip, float delay = 0)
    {
        yield return new WaitForSecondsRealtime(delay);
        AudioSource.PlayClipAtPoint(audioClip, mainCam.transform.position);
    }
}
