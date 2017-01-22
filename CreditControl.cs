using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditControl : MonoBehaviour {

    public GameObject creditmenu;
    public GameObject soundManager;

    public void ToggleCredits()
    {
        if (creditmenu.activeInHierarchy)
        {
            creditmenu.SetActive(false);
            soundManager.GetComponent<AudioSource>().clip = soundManager.GetComponent<MusicHandler>().audioClip[0];
            soundManager.GetComponent<AudioSource>().Play();
        }
        else
        {
            creditmenu.SetActive(true);

            soundManager.GetComponent<AudioSource>().clip = soundManager.GetComponent<MusicHandler>().audioClip[1];
            soundManager.GetComponent<AudioSource>().Play();
        }
    }
}
