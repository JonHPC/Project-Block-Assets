using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalManager : MonoBehaviour {

    public bool heartCrystal;//checks to see if heart crystal is obtained
    public bool puzzleCrystal;//checks to see if the puzzle crystal is obtained
    public bool jumpCrystal;//checks to see if the jump crystal is obtained

    public GameObject heartGet;//in Level End Menu, sets this active when heart crystal obtained
    public GameObject puzzleGet;//in Level End Menu, sets this active when puzzle crystal obtained
    public GameObject jumpGet;//in Level End Menu, sets this active when jump crystal obtained

    public GameObject heartUI;//on UI, sets this active when heart crystal is obtained
    public GameObject puzzleUI;// on UI, sets this active when puzzle crystal is obtained
    public GameObject jumpUI; //on UI, sets this active when jump crystal  is obtained

    // Use this for initialization
    void Start()
    {
        heartCrystal = false;
        puzzleCrystal = false;
        jumpCrystal = false;

        heartGet.gameObject.SetActive(false);
        puzzleGet.gameObject.SetActive(false);
        jumpGet.gameObject.SetActive(false);

        heartUI.gameObject.SetActive(false);
        puzzleUI.gameObject.SetActive(false);
        jumpUI.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (heartCrystal == true)//if you obtain the heart crystal, set these active
        {
            heartGet.gameObject.SetActive(true);//shows on LevelEnd menu
            heartUI.gameObject.SetActive(true);//shows on UI
        }

        if (puzzleCrystal == true)
        {
            puzzleGet.gameObject.SetActive(true);
            puzzleUI.gameObject.SetActive(true);
        }

        if (jumpCrystal == true)
        {
            jumpGet.gameObject.SetActive(true);
            jumpUI.gameObject.SetActive(true);
        }
    }
	
}
