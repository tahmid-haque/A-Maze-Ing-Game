using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelSettings : MonoBehaviour {
    public Vector3 respawn;
    public float lengthX,lengthY,speedX,speedW,speedY;
    public int level;
    public int[] scoreValues = new int[8];
    void Start ()
    {
        switch (GameObject.Find("CurrentLevelData").GetComponent<Text>().text)
        {
            case "Level 1 (Fast Orb)":
                level = 1;
                scoreValues[0] = 30; 
                scoreValues[1] = 400;
                scoreValues[2] = 90;
                scoreValues[3] = 5;
                scoreValues[4] = 3;
                scoreValues[5] = 200;
                scoreValues[6] = 60;
                scoreValues[7] = 300;
                lengthX = 25.5f;
                speedX = 2f;
                respawn = new Vector3(5, 7, -5);
                break;
            case "Level 2 (Frozen Orb)":
                level = 2;
                scoreValues[0] = 40; 
                scoreValues[1] = 600;
                scoreValues[2] = 120;
                scoreValues[3] = 7;
                scoreValues[4] = 5;
                scoreValues[5] = 300;
                scoreValues[6] = 60;
                scoreValues[7] = 450;
                lengthY = 27f;
                speedY = 4f;
                respawn = new Vector3(3.63f, 57.39f, -5);
                break;
            case "Level 3 (Camera Orb)":
                level = 3;
                scoreValues[0] = 40; 
                scoreValues[1] = 800;
                scoreValues[2] = 120;
                scoreValues[3] = 6;
                scoreValues[4] = 6;
                scoreValues[5] = 400;
                scoreValues[6] = 60;
                scoreValues[7] = 600;
                speedW = 60f;
                respawn = new Vector3(5.5f, 4.9f, -4f);               
                break;
            case "Level 4 (Controls Orb)":
                level = 4;
                scoreValues[0] = 70;
                scoreValues[1] = 1000;
                scoreValues[2] = 240;
                scoreValues[3] = 4;
                scoreValues[4] = 10;
                scoreValues[5] = 500;
                scoreValues[6] = 50;
                scoreValues[7] = 750;
                respawn = new Vector3(5.9f, 5.5f, -5);
                break;
            case "Level 5 (Dim Orb)":
                level = 5;
                scoreValues[0] = 70; 
                scoreValues[1] = 1200;
                scoreValues[2] = 300;
                scoreValues[3] = 4;
                scoreValues[4] = 10;
                scoreValues[5] = 600;
                scoreValues[6] = 60;
                scoreValues[7] = 900;
                speedW = 20f;
                speedY = 3f;
                lengthY = 4.5f;                          
                respawn = new Vector3(25.44f, 25.97f, -5);
                break;
            case "Final Level":
                level = 6;
                scoreValues[0] = 120; 
                scoreValues[1] = 1600;
                scoreValues[2] = 360;
                scoreValues[3] = 4;
                scoreValues[4] = 15;
                scoreValues[5] = 800;
                scoreValues[6] = 50;
                scoreValues[7] = 1200;
                lengthX = 27.5f;
                speedX = 1.5f;
                lengthY = 10f;
                speedY = 2f;
                speedW = 10f;
                respawn = new Vector3(69.2f, 50.3f, -5);
                break;
            case "Tutorial":
                level = 0;
                lengthY = 4.25f;
                speedY = 2f;
                respawn = new Vector3(72, 37, -5);
                break;
        }
    }

}
