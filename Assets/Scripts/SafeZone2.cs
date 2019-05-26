using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SafeZone2 : MonoBehaviour {

    void OnTriggerStay2D(Collider2D collision)
    {
        GameObject.Find("UserObject").GetComponent<Movement>().quickMenu = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        GameObject.Find("UserObject").GetComponent<Movement>().quickMenu = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("Instructions").GetComponent<Text>().text = "Avoid the obstacles and move to safe zone 3.";
    }
}
