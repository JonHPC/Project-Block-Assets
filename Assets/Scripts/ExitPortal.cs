using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPortal : MonoBehaviour {

    public GameObject levelEndMenu;

    void Start()
    {
        levelEndMenu.gameObject.SetActive(false);//makes sure the levelEndMenu is disabled at first
        Time.timeScale = 1f;//resumes normal time at the beginning of the stage
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.gameObject.layer != LayerMask.NameToLayer("Player"))//if objects other than the player touch this trigger, do nothing
        {
            return;
        }

        levelEndMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;//pauses the game when this triggers
        //bring up levelEnd UI menu
    }
}
