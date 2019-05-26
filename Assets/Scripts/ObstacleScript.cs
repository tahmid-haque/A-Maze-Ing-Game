using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour
{
    private Vector3 start;
    void Start()
    {
        start = transform.position;
    }

    void FixedUpdate()
    {
        LevelSettings lvlSettings = GameObject.Find("UserObject").GetComponent<LevelSettings>();
        if (GameObject.Find("UserObject").GetComponent<Movement>().disable == false)
        {
            Vector3 v = start;
            {
                if (gameObject.tag == "OddX")
                {
                    v.x -= lvlSettings.lengthX * Mathf.Sin(Time.time * lvlSettings.speedX);
                }
                else if (gameObject.tag == "EvenX")
                {
                    v.x += lvlSettings.lengthX * Mathf.Sin(Time.time * lvlSettings.speedX);
                }
                else if (gameObject.tag == "EvenY")
                {
                    v.y += lvlSettings.lengthY * Mathf.Sin(Time.time * lvlSettings.speedY);
                }
                else if (gameObject.tag == "OddY")
                {
                    v.y -= lvlSettings.lengthY * Mathf.Sin(Time.time * lvlSettings.speedY);
                }
            }
            transform.position = v;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.Find("UserObject").GetComponent<Movement>().ResetObject();
    }
}