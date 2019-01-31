using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour {

    public GameObject pauseMenu;//references the pause menu UI
    public bool gamePaused;//checks to see if game is paused
    public TextMeshProUGUI levelText;//references the level text
    public int world;//players pref for world selection
    public int level;//player pref for level selection


    // Use this for initialization
    void Start () {
        pauseMenu.gameObject.SetActive(false);//sets the pause menu to be disabled at first
        gamePaused = false;//initializes this to false

    }
	
	// Update is called once per frame
	void Update () {
        world = PlayerPrefs.GetInt("World");//gets the "World" Player Pref
        level = PlayerPrefs.GetInt("Level");//gets the "Level" Player Pref
        levelText.text = "Level " + world + "-" + level; //sets the UI level text according to the "World" and "Level" player prefs




		if (Input.GetKeyDown(KeyCode.Escape) && gamePaused == false)
        {
            Pause();
            
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && gamePaused == true)
        {
            Resume();
        }
	}

    public void Pause()//pauses the game
    {
        pauseMenu.gameObject.SetActive(true);//when the ESC key is pressed, bring up the pause menu
        gamePaused = true;//sets this bool to true
        Time.timeScale = 0f;//pauses time
    }

    public void Resume()//resumes the game
    {
        pauseMenu.gameObject.SetActive(false);//when esc is pressed when gamePaused is true, set pause menu inactive
        gamePaused = false;//sets this bool to false
        Time.timeScale = 1f;//resumes time at normal speed
    }

    public void Restart()//restarts the current level
    {
        Scene scene = SceneManager.GetActiveScene();//stores the current scene in this
        SceneManager.LoadScene(scene.name);//reloads this scene
    }

    public void NextLevel()
    {
        if(level <12)
        {
            SceneManager.LoadScene(world + "_" + (level + 1));//loads the next level
        }

        else if (level == 12)
        {
            SceneManager.LoadScene((world + 1) + "_" + (1));//if it is level 12, load the next world and level 1
        }
        else if (world == 3 && level == 12)
        {
            SceneManager.LoadScene("MainMenu");//loads the main menu if "next level" is pressed at world 3_12
        }

        
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");//loads the level select screen
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");//loads the Main Menu scene
    }
}
