using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeScript : MonoBehaviour {
    public float time;
    public bool timer;
    private string data;
	void Start ()
    {
        timer = true;
	}
	
	void Update ()
    {
        if (timer == true) 
        {
            time += Time.deltaTime;
        }
        GameObject.Find("Global").GetComponent<xScript>().CalculateTime(ref data, time);
        gameObject.GetComponent<Text>().text = data.ToString();
    }
}
