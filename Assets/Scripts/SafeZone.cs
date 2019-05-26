using UnityEngine;
using System.Collections;

public class SafeZone : MonoBehaviour {

    void OnTriggerStay2D(Collider2D collision)
    {
        GameObject.Find("UserObject").GetComponent<Movement>().quickMenu = true;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        GameObject.Find("UserObject").GetComponent<Movement>().quickMenu = false;
    }
}
