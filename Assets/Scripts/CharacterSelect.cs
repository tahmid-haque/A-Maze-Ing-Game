using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterSelect : MonoBehaviour {
    void Start()
    {
        string btn;
        xScript xScript = GameObject.Find("Global").GetComponent<xScript>();
        btn = "Block" + xScript.allData[xScript.choice,3];
        GameObject.Find(btn).GetComponent<Button>().Select();
    }
}
