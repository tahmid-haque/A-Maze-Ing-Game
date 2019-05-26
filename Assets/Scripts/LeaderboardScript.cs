using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;
using System;
public class LeaderboardScript : MonoBehaviour {
    private int[][] positionSort=new int[2][];
    private string[,] entries=new string[101,26];
    private string time;
    private int position,d;
    void Start () {
        
        xScript xScript = GameObject.Find("Global").GetComponent<xScript>();
        positionSort[0] = new int[xScript.size];
        positionSort[1] = new int[xScript.size];
        for (int i = 0; i < (xScript.size); i++)
        {
            positionSort[0][i] = i;
            positionSort[1][i] = int.Parse(xScript.allData[i, 6]);
        }
        Array.Sort(positionSort[1], positionSort[0]);
        for (int k = 0; k <xScript.size; k++)
        {
            for (int y = 0; y < 26; y++)
            {
                entries[k, y] = xScript.allData[positionSort[0][k], y];
            }
        }

        for (int count = (xScript.size-1); count > 0; count--)
        {
            GameObject.Find("PositionData").GetComponent<Text>().text +=(xScript.size-count).ToString()+Environment.NewLine;
            GameObject.Find("NameData").GetComponent<Text>().text += "   "+entries[count,0] + Environment.NewLine;
            xScript.CalculateTime(ref time, float.Parse(entries[count, 4]));
            GameObject.Find("TimeData").GetComponent<Text>().text += " " + time + Environment.NewLine;
            GameObject.Find("triesData").GetComponent<Text>().text += entries[count, 5]+ " Tries" + Environment.NewLine;
            GameObject.Find("OverallData").GetComponent<Text>().text += entries[count, 6]+ " Points" + Environment.NewLine;
        }
        if (xScript.choice != 0)
        {
            for (d = 0; d < xScript.size; d++)
            {
                if (entries[d, 0] == xScript.allData[xScript.choice, 0]) { break; }
            }
            position = xScript.size - d;
            GameObject.Find("UserPosition").GetComponent<Text>().text = "You are Position #" + position+".";
        }
        else { GameObject.Find("UserPosition").GetComponent<Text>().text = "You are a Developer."; }
    }
}


