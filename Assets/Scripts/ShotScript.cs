
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
  public int damage = 1;

    public bool isEnemyShot = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.Find("UserObject").GetComponent<Movement>().ResetObject();
    }
}
