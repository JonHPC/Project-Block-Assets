﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPref1_8 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("World", 1);
        PlayerPrefs.SetInt("Level", 8);
	}
	
	
}
