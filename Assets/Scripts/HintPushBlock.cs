using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintPushBlock : MonoBehaviour {

    public GameObject hintPushBlock;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            return;
        }

        hintPushBlock.gameObject.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            return;
        }
        hintPushBlock.gameObject.SetActive(false);
    }
}
