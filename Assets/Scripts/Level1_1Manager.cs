using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_1Manager : MonoBehaviour {

    public bool heartCrystal;//checks to see if heart crystal is obtained
    public bool puzzleCrystal;//checks to see if the puzzle crystal is obtained
    public bool jumpCrystal;//checks to see if the jump crystal is obtained

    // Use this for initialization
	void Start () {
        heartCrystal = false;
        puzzleCrystal = false;
        jumpCrystal = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
