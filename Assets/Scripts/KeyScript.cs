using UnityEngine;
using System.Collections;

public class KeyScript : MonoBehaviour {
    private Vector3 start;
    void Start()
    {
        start = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 v;
        {
            if (transform.position==start)
            {
                GameObject.Find("UserObject").GetComponent<Movement>().keyCount += 1;
                v = start;
                v.z = 1;
                transform.position = v;
            }
        }
    }
}
