using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManger : MonoBehaviour {

    public AudioSource ambient;

    public AudioClip[] soundArray;

    void Awake()
    {
        ambient = GetComponent<AudioSource>();
    }

    void Start ()
    {
        ambient.clip = soundArray[Random.Range(0,soundArray.Length)];
        ambient.PlayOneShot(ambient.clip);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
