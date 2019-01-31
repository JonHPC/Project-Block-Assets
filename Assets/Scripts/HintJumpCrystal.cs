using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintJumpCrystal : MonoBehaviour {

    public GameObject hintJumpCrystal;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            return;
        }

        hintJumpCrystal.gameObject.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            return;
        }
        hintJumpCrystal.gameObject.SetActive(false);
    }
}
