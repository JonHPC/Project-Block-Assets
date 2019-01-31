using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour {

    public GameObject world1;//references the world1 buttons
    public GameObject world2;//references the world2 buttons
    public GameObject world3;//references the world3 buttons

    public GameObject oneToTwo;//references these buttons
    public GameObject twoToThree;//references these buttons
    public GameObject twoToOne;//references these buttons
    public GameObject threeToTwo;//references these buttons





    private int worldSelection;//stores the world selection

    // Use this for initialization
	void Start () {
        worldSelection = PlayerPrefs.GetInt("World", 1);//gets the world selection, 1 by default, puts it into this variable
        world1.gameObject.SetActive(false);//sets this to be inactive by default
        world2.gameObject.SetActive(false);//sets this to be inactive by default
        world3.gameObject.SetActive(false);//sets this to be inactive by default
    }
	
	// Update is called once per frame
	void Update () {
		if(worldSelection == 1)
        {
            world1.gameObject.SetActive(true);//if world 1 was selected, show these buttons
            oneToTwo.gameObject.SetActive(true);

            world2.gameObject.SetActive(false);//disables these
            world3.gameObject.SetActive(false);//disables these
            twoToThree.gameObject.SetActive(false);//disables these
            threeToTwo.gameObject.SetActive(false);//disables these
            twoToOne.gameObject.SetActive(false);//disables these
        }
        else if(worldSelection == 2)
        {
            world2.gameObject.SetActive(true);//if world 1 was selected, show these buttons
            twoToThree.gameObject.SetActive(true);//disables these
            twoToOne.gameObject.SetActive(true);//disables these

            world1.gameObject.SetActive(false);//disables these
            world3.gameObject.SetActive(false);//disables these
            oneToTwo.gameObject.SetActive(false);
            threeToTwo.gameObject.SetActive(false);//disables these

        }
        else if(worldSelection == 3)
        {
            world3.gameObject.SetActive(true);//if world 1 was selected, show these buttons
            threeToTwo.gameObject.SetActive(true);//disables these

            world1.gameObject.SetActive(false);//disables these
            world2.gameObject.SetActive(false);//disables these
            oneToTwo.gameObject.SetActive(false);
            twoToOne.gameObject.SetActive(false);//disables these
            twoToThree.gameObject.SetActive(false);//disables these
        }
	}

    public void OnetoTwo()
    {
        PlayerPrefs.SetInt("World", 2);//sets the player pref "World" to 2
        worldSelection = PlayerPrefs.GetInt("World");//gets the player pref
    }

    public void TwotoThree()
    {
        PlayerPrefs.SetInt("World", 3);//sets the player pref "World" to 3
        worldSelection = PlayerPrefs.GetInt("World");//gets the player pref
    }

    public void TwotoOne()
    {
        PlayerPrefs.SetInt("World", 1);//sets the player pref "World" to 1
        worldSelection = PlayerPrefs.GetInt("World");//gets the player pref
    }

    public void ThreetoTwo()
    {
        PlayerPrefs.SetInt("World", 2);//sets the player pref "World" to 2
        worldSelection = PlayerPrefs.GetInt("World");//gets the player pref
    }

    public void Level1_1Start()
    {
        PlayerPrefs.SetInt("Level", 1);//sets the player pref for "Level" to 1
        SceneManager.LoadScene("1_1");//loads 1_1 scene
    }

    public void Level1_2Start()
    {
        PlayerPrefs.SetInt("Level", 2);
        SceneManager.LoadScene("1_2");//loads 1_2 scene
    }

    public void Level1_3Start()
    {
        PlayerPrefs.SetInt("Level", 3);
        SceneManager.LoadScene("1_3");
    }

    public void Level1_4Start()
    {
        PlayerPrefs.SetInt("Level", 4);
        SceneManager.LoadScene("1_4");
    }

    public void Level1_5Start()
    {
        PlayerPrefs.SetInt("Level", 5);
        SceneManager.LoadScene("1_5");
    }

    public void Level1_6Start()
    {
        PlayerPrefs.SetInt("Level", 6);
        SceneManager.LoadScene("1_6");
    }

    public void Level1_7Start()
    {
        PlayerPrefs.SetInt("Level", 7);
        SceneManager.LoadScene("1_7");
    }

    public void Level1_8Start()
    {
        PlayerPrefs.SetInt("Level", 8);
        SceneManager.LoadScene("1_8");
    }

    public void Level1_9Start()
    {
        PlayerPrefs.SetInt("Level", 9);
        SceneManager.LoadScene("1_9");
    }

    public void Level1_10Start()
    {
        PlayerPrefs.SetInt("Level", 10);
        SceneManager.LoadScene("1_10");
    }

    public void Level1_11Start()
    {
        PlayerPrefs.SetInt("Level", 11);
        SceneManager.LoadScene("1_11");
    }

    public void Level1_12Start()
    {
        PlayerPrefs.SetInt("Level", 12);
        SceneManager.LoadScene("1_12");
    }


    public void LevelToWorld()
    {
        SceneManager.LoadScene("WorldSelect");//goes back to the world select
    }
}
