using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPressure : MonoBehaviour
{

    public bool pressureUp;//checks to see if the switch is up
    public GameObject appearBlocks;//appear blocks object


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


    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer !=LayerMask.NameToLayer("Player") && other.gameObject.layer != LayerMask.NameToLayer("PushBlock"))// makes sure the player is the one colliding with this switch
        {
            return; //do nothing
        }

        pressureUp = false;
        animator.SetBool("pressureUp", pressureUp);//plays the switch down animation when player collides with this
        switchSound.Play();//plays the switch sound
        appearBlocks.gameObject.SetActive(false);//makes appear blocks disappear

    }





    void OnTriggerExit2D(Collider2D other)//used for pressure switch. When player/pushblock leaves the switch, run this code
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player") && other.gameObject.layer != LayerMask.NameToLayer("PushBlock"))// makes sure the player is the one colliding with this switch
        {
            return; //do nothing
        }



        StartCoroutine(delayAppear());//spawns appear blocks after set period of time
        //appearBlocks.gameObject.SetActive(true);//turns these on

    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("PushBlock"))// makes sure the block is the one colliding with this switch
        {
            return; //do nothing
        }

        pressureUp = false;
        animator.SetBool("pressureUp", pressureUp);//plays the switch down animation when block collides with this
        switchSound.Play();//plays the switch sound
        appearBlocks.gameObject.SetActive(false);//makes appear blocks disappear

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
        appearBlocks.gameObject.SetActive(true);//turns these on

    }

    //the below can be used for the timer switch, just run StartCoroutine(delayAppear()); to run this function
    /*IEnumerator delayAppear()//causes the appear blocks to appear delayed after switch is released
    {
        yield return new WaitForSeconds(0.5f);
        pressureUp = true;
        animator.SetBool("pressureUp", pressureUp);
        switchSound.Play();//plays the switch sound
        appearBlocks.gameObject.SetActive(true);//makes appear blocks spawn
       
    }*/
}
