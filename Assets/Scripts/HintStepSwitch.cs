using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintStepSwitch : MonoBehaviour {

    public GameObject hintStepSwitch;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            return;
        }

        hintStepSwitch.gameObject.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            return;
        }
        hintStepSwitch.gameObject.SetActive(false);
    }
}
