using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCrystal : MonoBehaviour
{

    public CrystalManager crystalManager;//references this script

    public AudioSource getSound;//used to play the sound when the crystal is obtained

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))// makes sure the player is the one colliding with this switch
        {
            return; //do nothing
        }
        getSound.Play();//plays the audio
        crystalManager.heartCrystal = true;//sets the heartCrystal bool in the Level1_1Manager script to true
        gameObject.SetActive(false);//disables this game object


    }
}
