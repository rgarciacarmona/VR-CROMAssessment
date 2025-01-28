using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource audioS;
    [HideInInspector] public float aLength;
    [HideInInspector] public static float _aLength;

    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayAudio(int index)
    {
        audioS.clip = clips[index];
        audioS.Play();
        aLength = audioS.clip.length;
        _aLength = aLength;

        Debug.Log("Audio: " + _aLength);

    }
}
