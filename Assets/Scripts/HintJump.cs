using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintJump : MonoBehaviour {

    public GameObject hintJump;

    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            return;
        }

        hintJump.gameObject.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            return;
        }
        hintJump.gameObject.SetActive(false);
    }


}
