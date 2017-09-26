using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour {
    public AudioSource source;
    public AudioClip clip;
    public void Awake()
    {
        source = GetComponent<AudioSource>();

    }

    public void OnTriggerEnter(Collider other)
    {
        source.Play();
    }
	
    public void OnTriggerExit(Collider other)
    {
        if (source.isPlaying)
        {
            source.Stop();
        }
    }
}
