using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SafeZone4 : MonoBehaviour {

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
        Movement movement = GameObject.Find("UserObject").GetComponent<Movement>();
        Text instructions = GameObject.Find("Instructions").GetComponent<Text>();
        if (movement.orbCount == 2 && instructions.text != "Collect all keys!")
        {
            instructions.text = "Keys give bonus points to the player. Collect the keys and move to the final zone.";
        }
        else if (movement.orbCount == 0 || movement.orbCount == 1)
        {
            GameObject.Find("SafeZone3").GetComponent<SafeZone3>().pickup = false;
            instructions.text = "Pick up all the orbs!";
            movement.tries += 1;
            collision.gameObject.transform.position = new Vector3(24, 23, -5);
        }
    }
}
