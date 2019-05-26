using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaypointScript : MonoBehaviour
{
    private Transform waypoint;
    private int num;
    private string wP;
    void Start()
    {
        if (GameObject.Find("CurrentLevelData").GetComponent<Text>().text=="Level 3 (Camera Orb)")
        {
            if (transform.localPosition.y == 2.7f)
            {
                waypoint = GameObject.Find("Waypoint2").GetComponent<Transform>();
                num = 2;
            }
            else if (transform.localPosition.x == 27f)
            {
                waypoint = GameObject.Find("Waypoint3").GetComponent<Transform>();
                num = 3;
            }
            else if (transform.localPosition.y == -22.25f)
            {
                waypoint = GameObject.Find("Waypoint4").GetComponent<Transform>();
                num = 4;
            }
            else
            {
                waypoint = GameObject.Find("Waypoint1").GetComponent<Transform>();
                num = 1;
            }
        }
        else if (GameObject.Find("CurrentLevelData").GetComponent<Text>().text == "Level 5 (Dim Orb)")
        {
            if (transform.localPosition.y == -4f)
            {
                waypoint = GameObject.Find("Waypoint2").GetComponent<Transform>();
                num = 2;
            }
            else if (transform.localPosition.x == -18f)
            {
                waypoint = GameObject.Find("Waypoint3").GetComponent<Transform>();
                num = 3;
            }
            else if (transform.localPosition.y == -20.25)
            {
                waypoint = GameObject.Find("Waypoint4").GetComponent<Transform>();
                num = 4;
            }
            else
            {
                waypoint = GameObject.Find("Waypoint1").GetComponent<Transform>();
                num = 1;
            }
        }
        else
        {
            if (gameObject.name=="Obstacle2W")
            {
                waypoint = GameObject.Find("Waypoint3").GetComponent<Transform>();
                num = 3;
            }
            else
            {
                waypoint = GameObject.Find("Waypoint1").GetComponent<Transform>();
                num = 1;
            }
        }
    }       
    void FixedUpdate()
    {
        if (GameObject.Find("UserObject").GetComponent<Movement>().disable == false)
        {
            LevelSettings lvlSettings = GameObject.Find("UserObject").GetComponent<LevelSettings>();
            transform.position = Vector3.MoveTowards(transform.position, waypoint.position, lvlSettings.speedW * Time.deltaTime);

            if (transform.position == waypoint.position)
            {
                num += 1;
                if (num == 5) { num = 1; }
                wP = "Waypoint" + num;
                waypoint = GameObject.Find(wP).GetComponent<Transform>();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("UserObject").GetComponent<Movement>().ResetObject();   
    }
}
