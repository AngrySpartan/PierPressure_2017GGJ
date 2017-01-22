using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour {

    public AudioClip[] audioClip;

    public float delayStart;
    public bool bDelayStart;

    public bool randomAudioChoice;

	// Use this for initialization
	void Start () {
        if (randomAudioChoice)
        {

            var r = Random.Range(0, audioClip.Length);
            GetComponent<AudioSource>().clip = audioClip[r];

        }

        if (bDelayStart)
        {
            GetComponent<AudioSource>().PlayDelayed(delayStart);


        }




    }

    public void PlayAudioSelection(int i)
    {
        GetComponent<AudioSource>().clip = audioClip[i];
        GetComponent<AudioSource>().Play();
    }

    public void PickRandomAudio()
    {
        var r = Random.Range(0, audioClip.Length);

        GetComponent<AudioSource>().clip = audioClip[r];
        GetComponent<AudioSource>().Play();
    }
	
}
