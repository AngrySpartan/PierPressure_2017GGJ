using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHitPlayAudio : MonoBehaviour {

    public MusicHandler musicHandler;

	void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.layer == 10)
        {
            musicHandler.PickRandomAudio();
        }
            
    }
}
