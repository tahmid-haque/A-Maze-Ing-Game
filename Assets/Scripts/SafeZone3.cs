using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SafeZone3 : MonoBehaviour {
    public bool pickup = true;

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
        if (pickup == true)
        {
            GameObject.Find("Instructions").GetComponent<Text>().text = "Orbs provide a special ability for 3 seconds. An orange orb randomly selects an ability. The effects of one orb must be completed to collect another. 2 orbs must be collected to finish.";
        }
    }
}
