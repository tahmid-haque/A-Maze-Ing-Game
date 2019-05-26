using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ProgressScript : MonoBehaviour {

	void Start () {
        xScript xScript = GameObject.Find("Global").GetComponent<xScript>();
        Button level2 = GameObject.Find("Level2").GetComponent<Button>();
        Button level3 = GameObject.Find("Level3").GetComponent<Button>();
        Button level4 = GameObject.Find("Level4").GetComponent<Button>();
        Button level5 = GameObject.Find("Level5").GetComponent<Button>();
        Button finalLevel = GameObject.Find("FinalLevel").GetComponent<Button>();
        switch (xScript.allData[xScript.choice,2])
        {
            case "2":
                level2.interactable = true;
                break;
            case "3":
                level2.interactable = true;
                level3.interactable = true;
                break;
            case "4":
                level2.interactable = true;
                level3.interactable = true;
                level4.interactable = true;
                break;
            case "5":
                level2.interactable = true;
                level3.interactable = true;
                level4.interactable = true;
                level5.interactable = true;
                break;
            case "6":
                level2.interactable = true;
                level3.interactable = true;
                level4.interactable = true;
                level5.interactable = true;
                finalLevel.interactable = true;
                break;
        }
    }
}
