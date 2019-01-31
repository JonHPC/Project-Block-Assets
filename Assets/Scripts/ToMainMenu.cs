using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainMenu : MonoBehaviour
{



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount == 1)
        {
            SceneManager.LoadScene("MainMenu");//loads the MainMenu scene from the Title screen once any key is presed
        }
    }
}
