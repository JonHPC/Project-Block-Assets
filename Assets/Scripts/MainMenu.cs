using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {



    public void StartGame()
    {
        Debug.Log("Start");
        SceneManager.LoadScene("WorldSelect");//loads the world select scene
    }

    public void Settings()
    {
        //blank for now


    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();//quits the game
    }
}
