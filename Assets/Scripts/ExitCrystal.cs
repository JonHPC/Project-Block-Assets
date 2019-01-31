using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCrystal : MonoBehaviour {

    public CrystalManager crystalManager;//references this script
    public GameObject hintExitCrystal;

    public AudioSource getSound;//gets the audio component 

    // Use this for initialization
	void Start () {

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))// makes sure the player is the one colliding with this switch
        {
            return; //do nothing
        }

        if(crystalManager.heartCrystal == true)//if the player already has the heart crystal when colliding with the exit crystal...
        {
            getSound.Play();//plyas the sound
            gameObject.SetActive(false);//sets the exitcrystal to inactive
            //Destroy(gameObject);//destroys this game object if heart crystal is already obtained
        }
        else
        {
            hintExitCrystal.gameObject.SetActive(true);//if the player collides with the exit crystal prior to getting the heart crystal, this text appears
        }


    }

    void OnTriggerExit2D(Collider2D other)//when player collider exits 
    {
        if(other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            return;
        }

        hintExitCrystal.gameObject.SetActive(false);//turns off this hint text when player leaves the trigger
    }
}
