using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPressureAppear : MonoBehaviour {

    public bool pressureUp;//checks to see if the switch is up
    public GameObject appearBlocks;//appear blocks object
    public GameObject disappearBlocks;


    private Animator animator;//references the Animator component
    private AudioSource switchSound;//sound the switch makes when stepped on



    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();//initializes this component
        switchSound = GetComponent<AudioSource>();//initializes the audio source

        pressureUp = true;//switch is up by default
        animator.SetBool("pressureUp", pressureUp);//initializes the switch up

    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("PushBlock"))// makes sure the block is the one colliding with this switch
        {
            return; //do nothing
        }

        pressureUp = false;
        animator.SetBool("pressureUp", pressureUp);//plays the switch down animation when block collides with this
        switchSound.Play();//plays the switch sound
        appearBlocks.gameObject.SetActive(true);//makes appear blocks appear
        disappearBlocks.gameObject.SetActive(false);

    }





    void OnTriggerExit2D(Collider2D other)//used for pressure switch. When pushblock leaves the switch, run this code
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("PushBlock"))// makes sure the block is the one colliding with this switch
        {
            return; //do nothing
        }


        pressureUp = true;
        animator.SetBool("pressureUp", pressureUp);
        switchSound.Play();//plays the switch sound
        appearBlocks.gameObject.SetActive(false);//turns these off
        disappearBlocks.gameObject.SetActive(true);

    }
}
