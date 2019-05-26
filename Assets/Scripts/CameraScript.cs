using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class CameraScript : MonoBehaviour {
    Vector3 v;
    public bool move;
    private void Start()
    {
        v = transform.position;
    }
    void Update ()
    {
        Movement movement = GameObject.Find("UserObject").GetComponent<Movement>();
        if (Input.GetKey(KeyCode.Escape) && movement.quickMenu==true && transform.position.y<=30)
        {
            move = true;
            movement.movement = true;
            GameObject.Find("TimeSpentData").GetComponent<TimeScript>().timer = false;
        }
       
        if (move == true)
        {
            if (v.y>=93.5)
            {
                move = false;
                GameObject.Find("ReturnToGame").GetComponent<Button>().interactable = true;
                if (GameObject.Find("ReturnToGame").GetComponentInChildren<Text>().text != "END GAME")
                {
                    GameObject.Find("ReturnToMenu").GetComponent<Button>().interactable = true;
                }               
                v = transform.position;
            }  
            else
            {
                v.y += Time.deltaTime * 90f;
                transform.position = v;
            }
        }
    }
}
