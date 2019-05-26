using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public int orb, orbCount,keyCount,tries;
    public float speed, timeCount;
    public bool disable, movement, quickMenu, animate;

	void Start ()
    {
        AudioSource audio = GameObject.Find("MusicObject").GetComponent<AudioSource>();
        AudioSource gameAudio = GameObject.Find("Music").GetComponent<AudioSource>();
        audio.Stop();
        gameAudio.Play();
        string character="Block";
        xScript xScript = GameObject.Find("Global").GetComponent<xScript>();
        character += xScript.allData[xScript.choice, 3];
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(character);
    }

	void FixedUpdate()
	{
		if (movement==false)
		{
			transform.Translate(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0);
		}
	}
    void Update()
    {
        GameObject action = GameObject.Find("actionObject");
        if (animate == true)
        {
            timeCount += Time.deltaTime;
            if (timeCount >= 3f)
            {
                ResetScreen();
            }
            else
            {
                action.GetComponent<Transform>().transform.localPosition = new Vector3(0f, 0f, -1f);
                switch (orb)
                {
                    case 1:
                        {
                            action.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.5f);
                            break;
                        }
                    case 2:
                        {
                            action.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, 0.5f);
                            break;
                        }
                    case 3:
                        {
                            action.GetComponent<SpriteRenderer>().color = new Color(0, 1, 0, 0.5f);
                            break;
                        }
                    case 4:
                        {
                            action.GetComponent<SpriteRenderer>().color = new Color(1f, 0.92f, 0.016f, 0.5f);
                            break;
                        }
                    case 5:
                        {
                            action.GetComponent<SpriteRenderer>().color = new Color(1, 0, 1, 0.5f);
                            break;
                        }
                }
            }
        }
    }

    public void ResetScreen()
    {
        speed = 0.45f;
        disable = false;
        animate = false;
        GameObject.Find("MainCamera").GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
        GameObject.Find("actionObject").GetComponent<Transform>().transform.localPosition = new Vector3(0f, 0f, 1f);
        timeCount = 0f;
        GameObject.Find("DimScreen").GetComponent<Transform>().position = new Vector3(40, 30, 30);
    }

    public void ResetObject()
    {
        Transform orb1 = GameObject.Find("Orb1").GetComponent<Transform>();
        Transform orb2 = GameObject.Find("Orb2").GetComponent<Transform>();
        orb1.position = new Vector3(orb1.position.x, orb1.position.y, -1);
        orb2.position = new Vector3(orb2.position.x, orb2.position.y, -1);
        
        transform.position = GetComponent<LevelSettings>().respawn;
        orbCount = 0;
        keyCount = 0;
        tries += 1;
        if (gameObject.GetComponent<LevelSettings>().level == 0)
        {
            Transform key1 = GameObject.Find("Key1").GetComponent<Transform>();
            Transform key2 = GameObject.Find("Key2").GetComponent<Transform>();
            key1.position = new Vector3(key1.position.x, key1.position.y, -1);
            key2.position = new Vector3(key2.position.x, key2.position.y, -1);
        }
        else
        {
            Transform key = GameObject.Find("Key").GetComponent<Transform>();
            key.position = new Vector3(key.position.x, key.position.y, -1);
        }
        ResetScreen();
        Transform orb3 = GameObject.Find("Orb3").GetComponent<Transform>();
        orb3.position = new Vector3(orb3.position.x, orb3.position.y, -1);
    }
}
