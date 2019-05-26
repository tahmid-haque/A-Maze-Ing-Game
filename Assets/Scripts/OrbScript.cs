using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OrbScript : MonoBehaviour {
    private Vector3 start;
    void Start()
    {
        start = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Movement movement = GameObject.Find("UserObject").GetComponent<Movement>();
        Vector3 v;
        LevelSettings lvlSettings = GameObject.Find("UserObject").GetComponent<LevelSettings>();
        if (movement.animate == false && transform.position==start)
        {
            movement.animate = true;
            movement.orbCount += 1;
            if (lvlSettings.level == 0 || lvlSettings.level == 6)
            {
                movement.orb = Random.Range(1, 6);
            }
            else { movement.orb = GameObject.Find("UserObject").GetComponent<LevelSettings>().level; }
            switch (movement.orb)
            {
                case 1:
                    movement.speed = 0.9f;
                    break;
                case 2:
                    movement.disable = true;
                    break;                    
                case 3:                    
                    GameObject.Find("MainCamera").GetComponent<Transform>().rotation = Quaternion.Euler(180, 180, 0);
                    movement.speed = -0.45f;
                    break;
                case 4:
                    movement.speed = -0.45f;
                    break;                    
                case 5:
                    GameObject.Find("DimScreen").GetComponent<Transform>().position = new Vector3(40, 30, -30);
                    break;
            }
            v = start;
            v.z = 1;
            transform.position = v;
        }
    }
}

