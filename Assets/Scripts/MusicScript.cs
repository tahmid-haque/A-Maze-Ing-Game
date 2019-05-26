using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicScript : MonoBehaviour {

	void Start ()
    {
        xScript xScript = GameObject.Find("Global").GetComponent<xScript>();
        if (xScript.music == 0)
        {
            DontDestroyOnLoad(GameObject.Find("MusicObject"));
            xScript.music = 1;
        }
        else { Destroy(gameObject); }
        
	}
}
