using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class xScript : MonoBehaviour {
    public int choice,size,music;
    public string[,] allData = new string[101, 26];
    private string[] tempData,tempLine;
    private StreamReader readFile;
    private StreamWriter saveFile;
    private int[] totalData=new int[3];

    void Start ()
    {
        choice = -1;
        DontDestroyOnLoad(gameObject);
        loadProfile();
    }

    public void Data(int score)
    {
        int num;
                
        LevelSettings lvlSettings = GameObject.Find("UserObject").GetComponent<LevelSettings>();
        Movement movement = GameObject.Find("UserObject").GetComponent<Movement>();
        num = ((lvlSettings.level - 1) * 3) + 7;
        if (int.Parse(allData[choice, num]) < score && choice!=0)
        {
            totalData[0] -= int.Parse(allData[choice, num + 1]);
            totalData[1] -= int.Parse(allData[choice, num + 2]);
            totalData[2] -= int.Parse(allData[choice, num]);
            allData[choice, num] = score.ToString();
            allData[choice, num+1] = Mathf.RoundToInt(GameObject.Find("TimeSpentData").GetComponent<TimeScript>().time).ToString();
            allData[choice, num+2] = movement.tries.ToString();
            totalData[0]= int.Parse(allData[choice, num + 1]) + int.Parse(allData[choice, 4]);
            totalData[1] = int.Parse(allData[choice, num + 2]) + int.Parse(allData[choice, 5]);
            totalData[2] = int.Parse(allData[choice, num]) + int.Parse(allData[choice, 6]);
            allData[choice, 4] = totalData[0].ToString();
            allData[choice, 5] = totalData[1].ToString();
            allData[choice, 6] = totalData[2].ToString();
            totalData[0] = 0;
            totalData[1] = 0;
            totalData[2] = 0;
            GameObject.Find("OverallPointsData").GetComponent<Text>().text = allData[choice, 6] + " Points";
            writeFile();
        }
    }
    public void loadProfile()
    {
        allData[0, 0] = "Developer";
        allData[0, 1] = "ExecAccess";
        allData[0, 2] = "6";
        allData[0, 3] = "1";
        allData[0, 6] = "-10";
        allData[0, 25] = "60";
        if (File.Exists("data.txt"))
        {
            for (int i = 0; i < 26; i++)
            {
                if (allData[0, i] == null) { allData[0, i] = "0"; }
            }
            tempData = File.ReadAllLines("data.txt");
            size = tempData.Length + 1;
            for (int i = 0; i < (size - 1); i++)
            {
                tempLine = tempData[i].Split(',');
                for (int h = 0; h < tempLine.Length; h++)
                {
                    allData[i + 1, h] = tempLine[h];
                }
            }
        }
        else { size = 1; }      
    }
    public void writeFile()
    {
        if (File.Exists("data.txt")) { File.Delete("data.txt"); }
        saveFile =File.CreateText("data.txt");
        for (int w = 0; w < (size-1); w++)
        {
            for (int a = 0; a < 26; a++)
            {
                if (a == 25)
                {
                    saveFile.Write(allData[w+1, a]);
                }
                else { saveFile.Write(allData[w+1, a] + ","); }
            }
            if (w != (size-2)) { saveFile.WriteLine(); } 
        }
        saveFile.Close();
    }
    public void CalculateTime(ref string txtTime, float timeX)
    {
        int minutes, hours, seconds;
        hours = Mathf.RoundToInt(timeX) / 3600;
        minutes = (Mathf.RoundToInt(timeX) - (hours * 3600)) / 60;
        seconds = Mathf.RoundToInt(timeX) % 60;
        if (timeX >= 3600)
        {
            txtTime = hours + " h, " + minutes + " m, " + seconds + " s";
        }
        else if (timeX >= 60)
        {
            txtTime = minutes + " m, " + seconds + " s";
        }
        else
        {
            txtTime = seconds + " s";
        }
    }
}
