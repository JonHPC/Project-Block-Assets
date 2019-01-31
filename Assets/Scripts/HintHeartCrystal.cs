using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintHeartCrystal : MonoBehaviour {

    public GameObject hintHeartCrystal;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            return;
        }

        hintHeartCrystal.gameObject.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            return;
        }
        hintHeartCrystal.gameObject.SetActive(false);
    }
}
