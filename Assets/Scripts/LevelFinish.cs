using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelFinish : MonoBehaviour {
    private int score;
    void OnTriggerEnter2D(Collider2D collision)
    {
        xScript xScript = GameObject.Find("Global").GetComponent<xScript>();
        Movement movement = GameObject.Find("UserObject").GetComponent<Movement>();
        LevelSettings lvlSettings = GameObject.Find("UserObject").GetComponent<LevelSettings>();
        switch (GameObject.Find("CurrentLevelData").GetComponent<Text>().text)
        {
            case "Tutorial":
                if (movement.keyCount == 2) { Prepare(); }
                else
                {
                    GameObject.Find("Instructions").GetComponent<Text>().text = "Collect all keys!";
                    GameObject.Find("UserObject").GetComponent<Transform>().position = new Vector3(73, 7, -5);
                }
                break;
            case "Final Level":
                if (movement.orbCount == 2)
                {
                    GameObject.Find("TimeSpentData").GetComponent<TimeScript>().timer = false;
                    GameObject.Find("ReturnToGame").GetComponentInChildren<Text>().text = "END GAME";
                    GameObject.Find("Statistics").GetComponent<Text>().text = "End Statistics";
                    GameObject.Find("MainCamera").GetComponent<CameraScript>().move = true;
                    CalculateScore();
                }
                break;
            default:
                if (movement.orbCount == 2)
                    {
                        Prepare();
                    if (int.Parse(xScript.allData[xScript.choice, 2]) <(lvlSettings.level+1) && xScript.choice != 0)
                    { xScript.allData[xScript.choice, 2] = (lvlSettings.level + 1).ToString(); }
                        CalculateScore();
                    }
                    break;
                }
        }
    void Prepare()
    {
        GameObject.Find("TimeSpentData").GetComponent<TimeScript>().timer = false;
        GameObject.Find("ReturnToGame").GetComponentInChildren<Text>().text = ">>>Next Level<<<";
        GameObject.Find("Statistics").GetComponent<Text>().text = "End Statistics";
        GameObject.Find("MainCamera").GetComponent<CameraScript>().move = true;
    }
    void CalculateScore()
    {
        score = 0;
        TimeScript timeScript=GameObject.Find("TimeSpentData").GetComponent<TimeScript>();
        Movement movement = GameObject.Find("UserObject").GetComponent<Movement>();
        LevelSettings lvlSettings = GameObject.Find("UserObject").GetComponent<LevelSettings>();

        if (Mathf.RoundToInt(timeScript.time) <= lvlSettings.scoreValues[0])
        {
            score += lvlSettings.scoreValues[1];
        }
        else if (Mathf.RoundToInt(timeScript.time) <= lvlSettings.scoreValues[2])
        {
            score += (lvlSettings.scoreValues[2] - Mathf.RoundToInt(timeScript.time)) * lvlSettings.scoreValues[3];
        }
        if (movement.tries<= lvlSettings.scoreValues[4]) { score += lvlSettings.scoreValues[5] - (movement.tries * lvlSettings.scoreValues[6]); }
        if (movement.keyCount == 1) { score += 100; }
        score += lvlSettings.scoreValues[7];
        GameObject.Find("Profile").GetComponent<Text>().text = "Points earned: ";
        GameObject.Find("ProfileData").GetComponent<Text>().text = score + " Points";
        GameObject.Find("Global").GetComponent<xScript>().Data(score);
     }
}