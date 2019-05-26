using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class btnScript : MonoBehaviour {
    private bool move;
    Vector3 v;
    private GameObject gameButton, menuButton, mainCamera;
    void Start ()
    {
        gameButton = GameObject.Find("ReturnToGame");
        menuButton = GameObject.Find("ReturnToMenu");
        mainCamera = GameObject.Find("MainCamera");
        xScript xScript = GameObject.Find("Global").GetComponent<xScript>();
        Text overallPoints = GameObject.Find("OverallPointsData").GetComponent<Text>();
        gameButton.GetComponent<Button>().onClick.AddListener(Game);
        menuButton.GetComponent<Button>().onClick.AddListener(Menu);
        if (xScript.allData[xScript.choice, 6] == "") { overallPoints.text = "0 Points"; }
        else { overallPoints.text = xScript.allData[xScript.choice, 6] + " Points"; }
        GameObject.Find("ProfileData").GetComponent<Text>().text= xScript.allData[xScript.choice, 0];       
    }
	
	void Menu()
    {
        AudioSource audio = GameObject.Find("MusicObject").GetComponent<AudioSource>();
        LevelSettings lvlSettings = GameObject.Find("UserObject").GetComponent<LevelSettings>();
        menuButton.GetComponent<Button>().interactable = false;
        gameButton.GetComponent<Button>().interactable = false;
        if (lvlSettings.level != 0)
            audio.Play();
        SceneManager.LoadScene("Main Menu");
    }
    void Game()
    {
        AudioSource audio = GameObject.Find("MusicObject").GetComponent<AudioSource>();
        if (gameButton.GetComponentInChildren<Text>().text == ">>>Next Level<<<" )
        {
            xScript xScript = GameObject.Find("Global").GetComponent<xScript>();
            switch (GameObject.Find("UserObject").GetComponent<LevelSettings>().level)
            {
                case 0:
                    SceneManager.LoadScene("Level 1");
                    break;
                case 1:
                    SceneManager.LoadScene("Level 2");
                    break;
                case 2:
                    SceneManager.LoadScene("Level 3");
                    break;
                case 3:
                    SceneManager.LoadScene("Level 4");
                    break;
                case 4:
                    SceneManager.LoadScene("Level 5");
                    break;
                case 5:
                    SceneManager.LoadScene("Final Level");
                    break;
            }                       
        }
        else if (gameButton.GetComponentInChildren<Text>().text == "Return to Game")
        {
            move = true;
            menuButton.GetComponent<Button>().interactable = false;
            gameButton.GetComponent<Button>().interactable = false;
            v = mainCamera.GetComponent<Transform>().position;
        }
        else
        {
            audio.Play();
            SceneManager.LoadScene("Ending Scene");
        }
    }
    void Update()
    {
        if (mainCamera.GetComponent<Transform>().position.y >= 93.5 && Input.GetKey(KeyCode.Escape) && GameObject.Find("UserObject").GetComponent<Movement>().quickMenu==true)
        {
            move = true;
            menuButton.GetComponent<Button>().interactable = false;
            gameButton.GetComponent<Button>().interactable = false;
            v = mainCamera.GetComponent<Transform>().position;
        }
        
        if (move == true)
        {
            if (v.y <= 30)
            {
                move = false;
                GameObject.Find("UserObject").GetComponent<Movement>().movement = false;
                GameObject.Find("TimeSpentData").GetComponent<TimeScript>().timer = true;
            }
            else
            {
                v.y -= Time.deltaTime * 90f;
                mainCamera.GetComponent<Transform>().position = v;
            }
        }
    }
}