using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStick : MonoBehaviour
{
   
   void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            coll.transform.parent = this.transform;
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            coll.transform.parent = null;
        }
    }
}
