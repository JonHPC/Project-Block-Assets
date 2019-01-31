using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchStepDisappear : MonoBehaviour {

    public bool stepUp;//checks to see if the switch is up
    public GameObject disappearBlocks;//appear blocks object


    private Animator animator;//references the Animator component
    private AudioSource switchSound;//sound the switch makes when stepped on
    private AudioClip soundClip;//the sound clip of the audio source
    private float soundDuration;//length of sound clip


    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();//initializes this component
        switchSound = GetComponent<AudioSource>();//initializes the audio source
        soundClip = switchSound.clip;//gets the sound clip from the audio source
        stepUp = true;//switch is up by default
        animator.SetBool("stepUp", stepUp);//initializes the switch up
        soundDuration = soundClip.length;//sets this variable to the length of the audio clip
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))// makes sure the player is the one colliding with this switch
        {
            return; //do nothing
        }
        //Debug.Log("on");
        if (stepUp == true)
        {
            switchSound.Play();//plays the switch sound
        }
        stepUp = false;
        animator.SetBool("stepUp", stepUp);//plays the switch down animation when player collides with this

        StartCoroutine(delayAppear());//spawns appear blocks after set period of time
    }

    IEnumerator delayAppear()//causes the appear blocks to appear delayed after switch is pressed
    {
        yield return new WaitForSeconds(soundDuration);
        disappearBlocks.gameObject.SetActive(false);//makes appear blocks disappear
    }








}

