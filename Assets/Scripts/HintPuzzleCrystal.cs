using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintPuzzleCrystal : MonoBehaviour {

    public GameObject hintPuzzleCrystal;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            return;
        }

        hintPuzzleCrystal.gameObject.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            return;
        }
        hintPuzzleCrystal.gameObject.SetActive(false);
    }
}
