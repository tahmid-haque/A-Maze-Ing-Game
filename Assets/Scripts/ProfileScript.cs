using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ProfileScript : MonoBehaviour {

	void Start () {
        xScript xScript = GameObject.Find("Global").GetComponent<xScript>();
        if (xScript.choice!=-1)
        {
            gameObject.GetComponent<Text>().text = "Hello, " + xScript.allData[xScript.choice, 0];
            GameObject.Find("ReturnToMenu").GetComponent<Button>().interactable = true;
        }       
	}
}
