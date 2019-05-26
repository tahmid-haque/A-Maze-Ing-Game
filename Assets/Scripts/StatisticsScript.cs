using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class StatisticsScript : MonoBehaviour {
    private string time;
	void Start () {
        xScript xScript = GameObject.Find("Global").GetComponent<xScript>();
        for (int i = 0; i < (xScript.size-1); i++)
        {
            GameObject.Find("ProfileList").GetComponent<Dropdown>().options.Add(new UnityEngine.UI.Dropdown.OptionData() { text = xScript.allData[i+1, 0] });
        }
    }

    public void ShowData()
    {
        int value;
        GameObject.Find("TimeData").GetComponent<Text>().text = "";
        GameObject.Find("triesData").GetComponent<Text>().text = "";
        GameObject.Find("ScoreData").GetComponent<Text>().text = "";
        xScript xScript = GameObject.Find("Global").GetComponent<xScript>();
        value = (gameObject.GetComponent<Dropdown>().value+1);
        for (int i = 7; i < 23; i+=3)
        {           
            xScript.CalculateTime(ref time, float.Parse(xScript.allData[value, i+1]));
            GameObject.Find("TimeData").GetComponent<Text>().text += " " + time + Environment.NewLine;
            GameObject.Find("triesData").GetComponent<Text>().text += xScript.allData[value, i + 2] + " Tries" + Environment.NewLine;
            GameObject.Find("ScoreData").GetComponent<Text>().text += xScript.allData[value, i] + " Points" + Environment.NewLine;
        }
        time = "";
        xScript.CalculateTime(ref time, float.Parse(xScript.allData[value, 4]));
        GameObject.Find("TimeData").GetComponent<Text>().text += " " + time + Environment.NewLine;
        GameObject.Find("triesData").GetComponent<Text>().text += xScript.allData[value, 5] + " Tries" + Environment.NewLine;
        GameObject.Find("ScoreData").GetComponent<Text>().text += xScript.allData[value, 6] + " Points" + Environment.NewLine;
    }
    public void You()
    {
        gameObject.GetComponent<Dropdown>().value = (GameObject.Find("Global").GetComponent<xScript>().choice-1);
    }	
}
