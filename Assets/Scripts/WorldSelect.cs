using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void World1Start()
    {
        PlayerPrefs.SetInt("World", 1);//stores the world selection
        SceneManager.LoadScene("LevelSelect");//loads the LevelSelect scene
    }

    public void World2Start()
    {
        PlayerPrefs.SetInt("World", 2);//stores the world selection
        SceneManager.LoadScene("LevelSelect");//loads the LevelSelect scene
    }

    public void World3Start()
    {
        PlayerPrefs.SetInt("World", 3);//store the world selection
        SceneManager.LoadScene("LevelSelect");//loads the LevelSelect scene
    }

    public void WorldMainMenu()
    {
        SceneManager.LoadScene("MainMenu");//goes back to the main menu
    }
}
