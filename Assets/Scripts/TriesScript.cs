using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TriesScript : MonoBehaviour {
	
	void Update ()
    {
        Movement movement = GameObject.Find("UserObject").GetComponent<Movement>();
        Text numTries = gameObject.GetComponent<Text>();
        numTries.text = movement.tries + " Tries";
    }
}
