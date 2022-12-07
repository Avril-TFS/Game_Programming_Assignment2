using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    private float fallDelay = 2f;
    private Animator anim;
    private Rigidbody2D rg2d;
 
    void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }
    
    private IEnumerator Fall()
    {
        anim.Play("flashFall");
        yield return new WaitForSeconds(fallDelay);
        rg2d.bodyType = RigidbodyType2D.Dynamic;
    }
}
